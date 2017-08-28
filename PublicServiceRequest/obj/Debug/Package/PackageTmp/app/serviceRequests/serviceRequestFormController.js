/// <reference path="../domain/request.ts"/>
var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestFormController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestFormController(dataAccessService, dataSharingService, serviceTypeResolved, requestPrioritiesResolved, requestResolved, requestTaxpayerPreferredLanguagesResolved, $scope, $timeout, $state, $stateParams, appSettings, $window, $uibModal) {
                this.dataAccessService = dataAccessService;
                this.dataSharingService = dataSharingService;
                this.serviceTypeResolved = serviceTypeResolved;
                this.requestPrioritiesResolved = requestPrioritiesResolved;
                this.requestResolved = requestResolved;
                this.requestTaxpayerPreferredLanguagesResolved = requestTaxpayerPreferredLanguagesResolved;
                this.$scope = $scope;
                this.$timeout = $timeout;
                this.$state = $state;
                this.$stateParams = $stateParams;
                this.appSettings = appSettings;
                this.$window = $window;
                this.$uibModal = $uibModal;
                this.invalidFolio = false;
                this.duplicateFolio = false;
                this.propertyType = 'Real Property Folio';
                this.requestCreateKendoUploadOptions = {};
                this.searchFolioNo = "";
                this.datePickerConfig = {};
                var onUploadOperationSuccess = this.OnUploadOperationSuccess;
                //datepicker options
                this.datePickerConfig = {
                    format: "MM/dd/yyyy"
                };
                //kendo ui upload widget parameters
                this.requestCreateKendoUploadOptions = {
                    async: {
                        saveUrl: this.appSettings.serverPath + "/Main/SaveUploadedFile",
                        removeUrl: this.appSettings.serverPath + "/Main/RemoveUploadedFile/?OutputDirectory=" +
                            angular.element('#ConfidentialUploadFileDirectory').val() +
                            "&TempID=" +
                            requestResolved.AttachmentTemporaryID,
                        autoUpload: true
                    },
                    upload: function (e) {
                        //all uploads initially go to Confidential File Directory and are stored in a temp file
                        //they are later moved to the appropriate directory once request is submitted
                        var tempDir = angular.element('#ConfidentialUploadFileDirectory').val();
                        //post parameters included with saveUrl
                        e.data = {
                            OutputDirectory: tempDir,
                            TempID: requestResolved.AttachmentTemporaryID
                        };
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
                    select: this.OnUploadFileSelection,
                    success: function (e) {
                        onUploadOperationSuccess(e, requestResolved, this);
                    }
                };
                //set delay for loading spinner
                this.setDelay();
            }
            //controller methods
            //set delay for loading spinner
            ServiceRequestFormController.prototype.setDelay = function () {
                var _this = this;
                this.blnDelay = true;
                this.$timeout(function () {
                    _this.blnDelay = false;
                }, 500);
            };
            //when anonymous flag check box is changed
            ServiceRequestFormController.prototype.RemainAnonymousFlagChanged = function () {
                if (this.requestResolved.RequestTaxpayerInfo.RemainAnonymousFlag) {
                    this.requestResolved.RequestTaxpayerInfo.FirstName = '';
                    this.requestResolved.RequestTaxpayerInfo.MiddleInitial = '';
                    this.requestResolved.RequestTaxpayerInfo.LastName = '';
                    this.requestResolved.RequestTaxpayerInfo.Email = '';
                    this.requestResolved.RequestTaxpayerInfo.PhoneNo = '';
                    this.requestResolved.RequestTaxpayerInfo.RequestTaxpayerPreferredLanguageID = null;
                }
            };
            ServiceRequestFormController.prototype.OpenModal = function (folio) {
                var folioList = this.requestResolved.FolioList;
                var baseURL = this.appSettings.serverPath;
                var dataAccessService = this.dataAccessService;
                var folioResolved = folio;
                var modalInstance = this.$uibModal.open({
                    animation: true,
                    templateUrl: baseURL + 'app/serviceRequests/serviceRequestFolioAlertModal.html',
                    backdrop: 'static',
                    controller: 'ServiceRequestFolioAlertController',
                    controllerAs: 'vm',
                    //bindToController: true,
                    size: 'lg',
                    resolve: {
                        requestFoliosResolved: function () {
                            var requestFolioResource = dataAccessService.getRequestFolioResource('/GetOpenRequestsByFolio');
                            return new requestFolioResource({ "FolioNo": folio.Folio }).$save().catch(function (reason) {
                                console.log(reason);
                            });
                        },
                        folioList: function () {
                            return folioList;
                        },
                        folioResolved: function () {
                            return folioResolved;
                        }
                    }
                });
            };
            //identical to OnActionUploadOperationSuccess function in serviceRequestAddActionController.ts, therefore any changes there should probably be done here
            //no time to refactor for now
            ServiceRequestFormController.prototype.OnUploadOperationSuccess = function (e, requestResolved, uploadWidget) {
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
                        requestResolved.RequestAttachments.push(attachment);
                    });
                }
                else if (e.operation == 'remove') {
                    angular.forEach(e.files, function (value, key) {
                        for (var i = requestResolved.RequestAttachments.length - 1; i >= 0; i--) {
                            if (requestResolved.RequestAttachments[i].RequestAttachmentClientID == value.uid) {
                                requestResolved.RequestAttachments.splice(i, 1);
                            }
                        }
                    });
                }
            };
            //check if files selected for upload meet size and file type criteria, otherwise cancel & alert user
            //nearly identical to OnActionUploadFileSelection function in serviceRequestAddActionController.ts, therefore any changes there should probably be done here
            //no time to refactor for now
            ServiceRequestFormController.prototype.OnUploadFileSelection = function (e) {
                //get approved file max size from hidden field
                var kBFileSizeLimit = angular.element('#UploadMaxSizeInKB').val();
                //get approved doc formats (convert to lower case) from hidden field and convert to array
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
            ServiceRequestFormController.prototype.ValidateFolio = function (propertyType, selectedYear) {
                var _this = this;
                this.invalidFolio = false;
                this.duplicateFolio = false;
                if (this.searchFolioNo == "") {
                    return;
                }
                if (this.searchFolioNo == undefined) {
                    this.invalidFolio = true;
                    this.duplicateFolio = false;
                    this.searchFolioNo = "";
                    angular.element("#txtFolioNo").focus().select();
                    return;
                }
                if (this.FolioIsDuplicate(this.searchFolioNo, selectedYear)) {
                    this.duplicateFolio = true;
                    this.invalidFolio = false;
                    angular.element("#txtFolioNo").focus().select();
                    return;
                }
                var requestFolioResource = this.dataAccessService.getRequestFolioResource('/ValidateFolio');
                var newRequestFolioResource = new requestFolioResource({ "FolioNo": this.searchFolioNo, "PropertyType": propertyType, "Year": selectedYear });
                newRequestFolioResource.$save({}, function (validatedFolio) {
                    //if folio has open PSR's show modal dialog
                    if (validatedFolio.HasOpenPSR == true) {
                        _this.OpenModal(validatedFolio);
                        _this.searchFolioNo = "";
                    }
                    else {
                        _this.AddFolio(validatedFolio);
                    }
                }, function (error) { console.log(error); });
            };
            ServiceRequestFormController.prototype.FolioIsDuplicate = function (folioNo, selectedYear) {
                var isDuplicate = false;
                for (var i = 0; i <= this.requestResolved.FolioList.length - 1; i++) {
                    if (this.requestResolved.FolioList[i].Folio == folioNo && this.requestResolved.FolioList[i].Year == selectedYear) {
                        isDuplicate = true;
                        break;
                    }
                }
                return isDuplicate;
            };
            ServiceRequestFormController.prototype.AddFolio = function (validatedFolio) {
                if (validatedFolio.Folio == undefined) {
                    //show invalid folio message
                    this.invalidFolio = true;
                    this.duplicateFolio = false;
                    angular.element("#txtFolioNo").focus().select();
                }
                else {
                    //hide invalid folio message and add newFolio to requestFolios list
                    this.invalidFolio = false;
                    this.duplicateFolio = false;
                    var newFolio = {
                        RequestFolioID: 0,
                        RequestFolioTypeID: validatedFolio.RequestFolioTypeID,
                        Folio: validatedFolio.Folio,
                        FormattedFolio: validatedFolio.FormattedFolio,
                        Confidential: validatedFolio.Confidential,
                        Cancelled: validatedFolio.Cancelled,
                        HasOpenPSR: validatedFolio.HasOpenPSR,
                        District: validatedFolio.District,
                        RequestID: null,
                        Year: validatedFolio.Year,
                        HistoryRunID: validatedFolio.HistoryRunID,
                        DORCode: validatedFolio.DORCode,
                        Owner: validatedFolio.Owner,
                        SiteAddress: validatedFolio.SiteAddress,
                        SiteCity: validatedFolio.SiteCity,
                        ZipCode: validatedFolio.ZipCode,
                        MailingAddress: null,
                        MailingCity: null,
                        MailingZipCode: null,
                        AdmIsActive: null,
                        AdmUserAdded: null,
                        AdmUserAddedFullName: null,
                        AdmDateAdded: null,
                        AdmUserModified: null,
                        AdmUserModifiedFullName: null,
                        AdmDateModified: null
                    };
                    this.requestResolved.FolioList.push(newFolio);
                    this.searchFolioNo = "";
                }
            };
            ServiceRequestFormController.prototype.RemoveFolio = function ($index) {
                this.requestResolved.FolioList.splice($index, 1);
            };
            ServiceRequestFormController.prototype.AddRequest = function () {
                //submit request only if form passes validation
                if (this.$scope.requestForm.$valid) {
                    //if the folio list is not populated and the ServiceTypeIncludePropertyInfoFlag is set to true
                    //confirm whether the user wants to submit a request with no folio
                    if (this.requestResolved.FolioList.length == 0 && this.serviceTypeResolved.ServiceTypeIncludePropertyInfoFlag) {
                        if (this.$window.confirm('Are you sure you want to submit this PSR with no folio added?')) {
                            this.SubmitRequest();
                        }
                    }
                    else {
                        this.SubmitRequest();
                    }
                }
            };
            ServiceRequestFormController.prototype.SubmitRequest = function () {
                var _this = this;
                //call generatenewrequest method which populates request info and folios
                var newRequest = this.GenerateNewRequest();
                var requestResource = this.dataAccessService.getRequestResource('/CreateRequest');
                var request = new requestResource({ "NewRequest": newRequest, "AssociatedServiceTypes": this.dataSharingService.associatedServiceTypeViewModel });
                request.$save({}, function (data) {
                    _this.GoToRequestWorkspace(data.value);
                }, function (error) { console.log(error); });
            };
            ServiceRequestFormController.prototype.GoToRequestWorkspace = function (requestID) {
                this.$state.go('Workspace', { 'Id': requestID });
            };
            ServiceRequestFormController.prototype.GenerateNewRequest = function () {
                //if the ServiceTypeIncludePropertyInfoFlag is false then set taxpayerid to -1; server will consider this a request with no property info.
                //getting the ServiceTypeIncludePropertyInfoFlag from the first[0]/Parent servicetype because it reflects true if any of the flags on the child servicetypes is true
                //see PSR.GetServiceTypeChildrenByParent table val function in database for more info on logic
                if (!this.dataSharingService.associatedServiceTypeViewModel.AssociatedServiceTypes[0].ServiceTypeIncludePropertyInfoFlag) {
                    this.requestResolved.RequestTaxpayerInfo.RequestTaxpayerID = -1;
                }
                var request = {
                    RequestID: this.requestResolved.RequestID,
                    ServiceTypeID: this.requestResolved.ServiceTypeID,
                    RequestTypeID: this.requestResolved.RequestTypeID,
                    RequestOriginID: this.requestResolved.RequestOriginID,
                    RequestPriorityID: this.requestResolved.RequestPriorityID,
                    RequestStatusID: this.requestResolved.RequestStatusID,
                    RequestResolutionID: this.requestResolved.RequestResolutionID,
                    RequestTaxpayerID: this.requestResolved.RequestTaxpayerID,
                    RequestCurrentWorkerID: this.requestResolved.RequestCurrentWorkerID,
                    RequestCurrentWorkerFullName: this.requestResolved.RequestCurrentWorkerFullName,
                    RequestYear: this.requestResolved.RequestYear,
                    RequestNumber: this.requestResolved.RequestNumber,
                    RequestSuffix: this.requestResolved.RequestSuffix,
                    FormattedRequestNumber: this.requestResolved.FormattedRequestNumber,
                    RequestDueDate: this.requestResolved.RequestDueDate,
                    RequestComments: this.requestResolved.RequestComments,
                    RequestCommentsInternal: this.requestResolved.RequestCommentsInternal,
                    RequestEffectiveDate: this.requestResolved.RequestEffectiveDate,
                    RequestCompletionDate: this.requestResolved.RequestCompletionDate,
                    RequestUpdateNotificationFlag: this.requestResolved.RequestUpdateNotificationFlag,
                    RequestUpdateNotificationEmail: this.requestResolved.RequestUpdateNotificationEmail,
                    AdmIsActive: this.requestResolved.AdmIsActive,
                    AdmUserAdded: this.requestResolved.AdmUserAdded,
                    AdmUserAddedFullName: this.requestResolved.AdmUserAddedFullName,
                    AdmDateAdded: this.requestResolved.AdmDateAdded,
                    AdmUserModified: this.requestResolved.AdmUserModified,
                    AdmUserModifiedFullName: this.requestResolved.AdmUserModifiedFullName,
                    AdmDateModified: this.requestResolved.AdmDateModified,
                    FolioList: this.requestResolved.FolioList,
                    RestrictToAutoSelection: this.requestResolved.RestrictToAutoSelection,
                    DisableProgressNotification: this.requestResolved.DisableProgressNotification,
                    RequestTaxpayerInfo: this.requestResolved.RequestTaxpayerInfo,
                    //temp id is used to name temp folder where uploaded files will be stored, until request is created
                    AttachmentTemporaryID: this.requestResolved.AttachmentTemporaryID,
                    RequestAttachments: this.requestResolved.RequestAttachments,
                    OutputDirectory: angular.element('#UploadFileDirectory').val(),
                    ConfidentialOutputDirectory: angular.element('#ConfidentialUploadFileDirectory').val()
                };
                return request;
            };
            return ServiceRequestFormController;
        }());
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestFormController.$inject = ['dataAccessService', 'dataSharingService',
            'serviceTypeResolved', 'requestPrioritiesResolved',
            'requestResolved', 'requestTaxpayerPreferredLanguagesResolved',
            '$scope', '$timeout', '$state',
            '$stateParams', 'appSettings', '$window', '$uibModal'];
        angular.module('serviceRequestApp')
            .controller('ServiceRequestFormController', ServiceRequestFormController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestFormController.js.map