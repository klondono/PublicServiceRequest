var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestAddActionController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestAddActionController(dataAccessService, $scope, $uibModalInstance, requestActionTypeResolved, requestWorkspaceResolved, appSettings) {
                this.dataAccessService = dataAccessService;
                this.$scope = $scope;
                this.$uibModalInstance = $uibModalInstance;
                this.requestActionTypeResolved = requestActionTypeResolved;
                this.requestWorkspaceResolved = requestWorkspaceResolved;
                this.appSettings = appSettings;
                //declare properties for class
                this.actionCreateKendoUploadOptions = {};
                this.datePickerConfig = {};
                this.SelectAllFlag = false;
                this.disableButton = false;
                this.saveButtonText = "Save";
                var onActionUploadOperationSuccess = this.OnActionUploadOperationSuccess;
                //datepicker options
                this.datePickerConfig = {
                    format: "MM/dd/yyyy"
                };
                //kendo ui upload widget parameters
                this.actionCreateKendoUploadOptions = {
                    async: {
                        saveUrl: this.appSettings.serverPath + "Main/SaveUploadedFile",
                        removeUrl: this.appSettings.serverPath + "Main/RemoveUploadedFile/?OutputDirectory=" + angular.element('#ConfidentialUploadFileDirectory').val() + "&TempID=" + requestActionTypeResolved.AttachmentTemporaryID,
                        autoUpload: true
                    },
                    upload: function (e) {
                        //all uploads initially go to Confidential File Directory and are stored in a temp file
                        //they are later moved to the appropriate directory once request is submitted
                        var tempDir = angular.element('#ConfidentialUploadFileDirectory').val();
                        //post parameters included with saveUrl
                        e.data = { OutputDirectory: tempDir, TempID: requestActionTypeResolved.AttachmentTemporaryID };
                    },
                    template: '<span class="k-progress"></span>' +
                        '<span class="k-icon k-i-txt"></span>' +
                        '<span class="k-filename">#=name#</span>' +
                        '<span class="k-filename">Size: #=size# bytes </span>' +
                        '<span class="k-filename"><span class="upload-file-list-label"><input id="#=name#" type="checkbox" class="upload-file-list-checkbox" />&nbsp;&nbsp;Confidential</input></span></span>' +
                        '<strong class="k-upload-status">' +
                        '<button type="button" class="k-button k-button-bare k-upload-action">' +
                        '<span class="k-icon k-i-close k-delete" title="Remove"></span>' +
                        '</button>' +
                        '</strong>',
                    localization: {
                        dropFilesHere: "<span>Drop Files Here</span>",
                        uploadSelectedFiles: "Upload Files"
                    },
                    select: this.OnActionUploadFileSelection,
                    success: function (e) {
                        onActionUploadOperationSuccess(e, requestActionTypeResolved, this);
                    }
                };
            }
            ;
            ServiceRequestAddActionController.prototype.DisableSaveButton = function () {
                this.disableButton = true;
                this.saveButtonText = "Saving";
            };
            ServiceRequestAddActionController.prototype.ToggleSelectAllFlag = function () {
                //set SelectAllFlag value to false if any AddAssocRequestFlag is false for any of the associated requests
                this.SelectAllFlag = true;
                for (var i = 0; i <= this.requestActionTypeResolved.AssociatedRequests.length - 1; i++) {
                    if (this.requestActionTypeResolved.AssociatedRequests[i].AddAssocRequestFlag === false) {
                        this.SelectAllFlag = false;
                        break;
                    }
                    ;
                }
            };
            ServiceRequestAddActionController.prototype.ToggleAssocRequestSelectAll = function (selectAllFlag) {
                //get whether this action changes the request status
                var blnActionChangesStatus = this.requestActionTypeResolved.ChangeRequestStatus;
                if (selectAllFlag == true) {
                    angular.forEach(this.requestActionTypeResolved.AssociatedRequests, function (value, key) {
                        //If the associated request list contains the root parent request and it has it's CloseWhenChildrenAreClosedFlag set to true, then prevent 
                        //users from changing the status of the request manually through the replication of the action.  
                        //The Root request is strictly opened or closed based on whether any dependant request is reopened or all dependant requests are closed.
                        if (blnActionChangesStatus && value.CloseWhenChildrenAreClosedFlag) {
                            value.AddAssocRequestFlag = false;
                        }
                        else {
                            value.AddAssocRequestFlag = true;
                        }
                    });
                }
                else {
                    angular.forEach(this.requestActionTypeResolved.AssociatedRequests, function (value, key) {
                        value.AddAssocRequestFlag = false;
                    });
                }
            };
            //When displayFieldValueInCommentsFlag == true for a custom select box, the value of the select box is added to the comments field
            ServiceRequestAddActionController.prototype.SelectListChange = function (selectListValue, displayFieldValueInCommentsFlag) {
                if (displayFieldValueInCommentsFlag) {
                    var comments = this.requestActionTypeResolved.Comments == null ? '' : this.requestActionTypeResolved.Comments;
                    this.requestActionTypeResolved.Comments = selectListValue + ". " + comments;
                }
            };
            //check if files selected for upload meet size and file type criteria, otherwise cancel & alert user
            //nearly identical to OnUploadFileSelection function in serviceRequestFormController.ts, therefore any changes there should probably be done here
            //no time to refactor for now
            ServiceRequestAddActionController.prototype.OnActionUploadFileSelection = function (e) {
                //get approved file max size from hidden field
                var kBFileSizeLimit = angular.element('#UploadMaxSizeInKB').val();
                //get approved doc formats from hidden field (convert to lower case) and convert to array
                var strDocFormats = angular.element('#UploadDocumentFormats').val().toLowerCase();
                var arrDocFormats = strDocFormats.split(';');
                var strFiletypeMsg = 'Invalid file types: ';
                var strFileSizeMsg = 'Exceeds file size limit of ' + kBFileSizeLimit + ' kb: ';
                var strFileNameMsg = 'File names cannot contain special characters and spaces (ex: & character is prohibited) : ';
                var showFileTypeMessage = false;
                var showFileSizeMessage = false;
                var showFileNameMessage = false;
                angular.forEach(e.files, function (value, key) {
                    //for each file, check if lower case file extension is in array
                    if (arrDocFormats.indexOf(value.extension.toLowerCase()) == -1) {
                        strFiletypeMsg = strFiletypeMsg + value.extension + '; ';
                        showFileTypeMessage = true;
                    }
                    //for each file, check if file size within approved limit
                    var ByteFileSizeLimit = (kBFileSizeLimit * 1024);
                    if (value.size > ByteFileSizeLimit) {
                        var fileSize = Math.round(value.size * 0.0009765625);
                        strFileSizeMsg = strFileSizeMsg + value.name + ' = ' + fileSize + ' kb; ';
                        showFileSizeMessage = true;
                    }
                    if (value.name.search(/[<>'\s+\"\/;`%]/) > 0) {
                        strFileNameMsg = strFileNameMsg + value.name + '; ';
                        showFileNameMessage = true;
                    }
                });
                if (showFileSizeMessage || showFileTypeMessage || showFileNameMessage) {
                    e.preventDefault();
                    var fileSizeMessage = showFileSizeMessage ? strFileSizeMsg : '';
                    var fileTypeMessage = showFileTypeMessage ? strFiletypeMsg : '';
                    var fileNameMsg = showFileNameMessage ? strFileNameMsg : '';
                    alert(fileSizeMessage + '\n' + fileTypeMessage + '\n' + fileNameMsg);
                }
            };
            //nearly identical to OnUploadOperationSuccess function in serviceRequestFormController.ts, therefore any changes there should probably be done here
            //no time to refactor for now
            ServiceRequestAddActionController.prototype.OnActionUploadOperationSuccess = function (e, requestActionTypeResolved, uploadWidget) {
                if (e.operation == 'upload') {
                    var _this = uploadWidget;
                    angular.forEach(e.files, function (value, key) {
                        var fileName = value.name;
                        //get input of type checkBox whose id matches file name
                        var checkBox = _this.wrapper.find("input[id='" + fileName + "']");
                        //determine if checkBox is checked
                        var isConfidential = checkBox.is(":checked");
                        var attachment = {
                            RequestAttachmentID: null,
                            RequestAttachmentClientID: value.uid,
                            RequestAttachmentName: value.name,
                            AttachmentTypeName: null,
                            RequestAttachmentComment: null,
                            SizeInKB: value.size,
                            FileExtension: value.extension,
                            AttachmentTypeID: null,
                            RequestAttachmentDate: null,
                            AttachmentAddedBy: null,
                            RequestAttachmentFriendlyName: null,
                            SubFolder: null,
                            ConfidentialAttachmentFlag: isConfidential
                        };
                        requestActionTypeResolved.RequestAttachments.push(attachment);
                    });
                }
                else if (e.operation == 'remove') {
                    angular.forEach(e.files, function (value, key) {
                        for (var i = requestActionTypeResolved.RequestAttachments.length - 1; i >= 0; i--) {
                            if (requestActionTypeResolved.RequestAttachments[i].RequestAttachmentClientID == value.uid) {
                                requestActionTypeResolved.RequestAttachments.splice(i, 1);
                            }
                        }
                    });
                }
            };
            ServiceRequestAddActionController.prototype.Save = function () {
                var _this = this;
                this.DisableSaveButton();
                var newRequestAction = this.GenerateAction();
                var requestActionResource = this.dataAccessService.getRequestActionResource('/CreateRequestAction');
                var requestAction = new requestActionResource({ 'NewAction': newRequestAction });
                requestAction.$save({}, function (data) {
                    //update requestWorkspaceModel with new refreshed data
                    _this.UpdateRequestWorkspace(data);
                    //close modal instance and return newly updated model to parent window
                    _this.$uibModalInstance.close(_this.requestWorkspaceResolved);
                }, function (error) { console.log(error); });
            };
            ;
            ServiceRequestAddActionController.prototype.UpdateRequestWorkspace = function (data) {
                this.requestWorkspaceResolved.ServiceTypeID = data.ServiceTypeID;
                this.requestWorkspaceResolved.ServiceTypeName = data.ServiceTypeName;
                this.requestWorkspaceResolved.RequestStatus = data.RequestStatus;
                this.requestWorkspaceResolved.RequestStatusColor = data.RequestStatusColor;
                this.requestWorkspaceResolved.Resolution = data.Resolution;
                this.requestWorkspaceResolved.CompletionDate = data.CompletionDate;
                this.requestWorkspaceResolved.CurrentlyAssignedWorker = data.CurrentlyAssignedWorker;
                this.requestWorkspaceResolved.BlnAsc = data.BlnAsc;
                this.requestWorkspaceResolved.SortBy = data.SortBy;
                this.requestWorkspaceResolved.RequestActions = data.RequestActions;
                this.requestWorkspaceResolved.RequestAttachments = data.RequestAttachments;
                this.requestWorkspaceResolved.AssociatedRequests = data.AssociatedRequests;
                this.requestWorkspaceResolved.RequestAvailableActions = data.RequestAvailableActions;
            };
            ServiceRequestAddActionController.prototype.GenerateAction = function () {
                var newRequestAction = {
                    RequestID: this.requestActionTypeResolved.RequestID,
                    ServiceTypeID: this.requestWorkspaceResolved.ServiceTypeID,
                    ServiceTypeName: this.requestWorkspaceResolved.ServiceTypeName,
                    RequestParentRootID: this.requestWorkspaceResolved.RequestParentRootID,
                    //value taken from requestWorkspaceResolved instead of requestActionTypeResolved to avoid additional query in GetRequestActionTypeViewModel server controller method 
                    FormattedRequestNumber: this.requestWorkspaceResolved.FormattedRequestNumber,
                    RequestUpdateNotificationFlag: this.requestWorkspaceResolved.NotifyOfProgress,
                    RequestUpdateNotificationEmail: this.requestWorkspaceResolved.RequestUpdateNotificationEmail,
                    RequestActionTypeID: this.requestActionTypeResolved.RequestActionTypeID,
                    SelectedOwnerGroup: this.requestActionTypeResolved.SelectedOwnerGroup,
                    SelectedUser: this.requestActionTypeResolved.SelectedUser,
                    SelectedStatus: this.requestActionTypeResolved.SelectedStatus,
                    SelectedServiceType: this.requestActionTypeResolved.SelectedServiceType,
                    AssignUserFlag: this.requestActionTypeResolved.AssignUserFlag,
                    UpdateServiceType: this.requestActionTypeResolved.UpdateServiceType,
                    UpdateRequestFolio: this.requestActionTypeResolved.UpdateRequestFolio,
                    RequestActionTypeName: this.requestActionTypeResolved.RequestActionTypeName,
                    BackgroundColor: null,
                    TextColor: null,
                    Comments: this.requestActionTypeResolved.Comments,
                    ChangeRequestStatus: this.requestActionTypeResolved.ChangeRequestStatus,
                    ReassignRequest: this.requestActionTypeResolved.ReassignRequest,
                    UploadDocument: this.requestActionTypeResolved.UploadDocument,
                    AllowReplication: this.requestActionTypeResolved.AllowReplication,
                    RequestActionCustomFields: this.requestActionTypeResolved.RequestActionCustomFields,
                    RequestAttachments: this.requestActionTypeResolved.RequestAttachments,
                    AssociatedRequests: this.requestActionTypeResolved.AssociatedRequests,
                    OutputDirectory: angular.element('#UploadFileDirectory').val(),
                    ConfidentialOutputDirectory: angular.element('#ConfidentialUploadFileDirectory').val(),
                    //temp id is used to name temp folder where uploaded files will be stored, until action is saved
                    AttachmentTemporaryID: this.requestActionTypeResolved.AttachmentTemporaryID,
                    ConcurrentCreationOfChildrenFlag: this.requestActionTypeResolved.ConcurrentCreationOfChildrenFlag,
                    AddActionPermission: this.requestActionTypeResolved.AddActionPermission,
                    UpdateActionPermission: this.requestActionTypeResolved.UpdateActionPermission,
                    DeleteActionPermission: this.requestActionTypeResolved.DeleteActionPermission,
                    CloseWhenChildrenAreClosedFlag: this.requestWorkspaceResolved.CloseWhenChildrenAreClosedFlag,
                    AddActionActiveDirectoryGroupName: null,
                    UpdateActionActiveDirectoryGroupName: null,
                    DeleteActionActiveDirectoryGroupName: null,
                    MaximumAllowedOcurrence: null,
                    ExceededMaximumAllowedOcurrence: null,
                    RequestActionUsers: [],
                    RequestActionOwnerGroups: [],
                    RequestActionStatuses: [],
                    ServiceTypes: []
                };
                return newRequestAction;
            };
            ServiceRequestAddActionController.prototype.Cancel = function () {
                this.$uibModalInstance.dismiss('cancel');
            };
            ;
            return ServiceRequestAddActionController;
        }());
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestAddActionController.$inject = ['dataAccessService', '$scope', '$uibModalInstance', 'requestActionTypeResolved', 'requestWorkspaceResolved', 'appSettings'];
        //register controller with the main angular module defined in app.ts
        angular.module('serviceRequestApp')
            .controller('ServiceRequestAddActionController', ServiceRequestAddActionController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestAddActionController.js.map