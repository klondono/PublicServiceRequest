var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestWorkspaceController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestWorkspaceController($scope, $stateParams, dataAccessService, $timeout, $uibModal, appSettings, $state) {
                this.$scope = $scope;
                this.$stateParams = $stateParams;
                this.dataAccessService = dataAccessService;
                this.$timeout = $timeout;
                this.$uibModal = $uibModal;
                this.appSettings = appSettings;
                this.$state = $state;
                //declare properties for class
                this.requestWorkspaceViewModel = null;
                this.openAttachments = false;
                this.openRequests = false;
                this.openActions = true;
                this.openGeneralInfo = true;
                this.filterValue = '10'; //Set initial value for number of request actions to show
                this.disableButton = false;
                this.saveButtonText = "Save";
                this.SelectAllFlag = false;
                this.actionCreateKendoUploadOptions = {};
                this.selectedRequestActionTypeID = null;
                this.showSpinner = true;
                this.CustomStatusConstraintMessage = "";
                this.contextMenu = {};
                this.datePickerConfig = {};
                //datepicker options
                this.datePickerConfig = {
                    format: "MM/dd/yyyy"
                };
                this.GetRequest();
            }
            ;
            ServiceRequestWorkspaceController.prototype.GenerateContextMenu = function (appSettings) {
                angular.element("#contextMenuRequestFolio").show();
                var contextMenu = angular.element("#contextMenuRequestFolio").kendoContextMenu({
                    target: "#gridRequestFolio",
                    filter: ".hasContextMenu",
                    orientation: 'vertical',
                    showOn: 'click',
                    select: function (e) {
                        // handle event
                        var folio = '';
                        var link = angular.element(e.item).find('a');
                        //get folio number
                        folio = e.target.innerHTML;
                        //get current href from link
                        var href = ''; //link.attr('href');
                        //if link is property search
                        if (link.attr('id') == 'propertySearch') {
                            //get folio type 1 for real, 2 for tpp
                            var folioType = angular.element(e.target).siblings('.hiddenFolioType').val();
                            //if folio type is tpp replace link href
                            if (folioType == '2') {
                                href = appSettings.tppSearchPath;
                            }
                            else {
                                href = appSettings.realPropertySearchPath;
                            }
                            //replace link href attribute with new href and folio number with no dashes
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        //if link is google maps get address from hidden field
                        if (link.attr('id') == 'googleMapSearch') {
                            var addressToSearch = angular.element(e.target).siblings('.hiddenAddress').val();
                            href = appSettings.googleMapPath;
                            //add address to end of link as parameter
                            link.attr("href", href + addressToSearch);
                        }
                        if (link.attr('id') == 'pictometrySearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.pictometryPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'taxCollectorSearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.taxCollectorPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'taxComparisonSearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.taxComparisonPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'taxComparableSalesSearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.comparableSalesPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'photoSearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.photosPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'trimNoticeSearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.trimNoticePath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'fieldCheckSearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.fieldCheckReportPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'propertyReportCardSearch') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.propertyReportCardPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'createAddressChangeLetter') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.addressChangeAppPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                        if (link.attr('id') == 'createDPALetter') {
                            //replace link href attribute with new href and folio number with no dashes
                            href = appSettings.dpaLetterAppPath;
                            link.attr("href", href + folio.replace(/-/g, ''));
                        }
                    }
                });
            };
            ////controller methods
            ServiceRequestWorkspaceController.prototype.GenerateRequestFolioGrid = function (appSettings) {
                //Destroy kendo grid from DOM, otherwise detailinit will not work
                if (angular.element('#gridRequestFolio').data().kendoGrid != undefined)
                    angular.element('#gridRequestFolio').data().kendoGrid.destroy();
                //Show customer info if it is anonymous, otherwise customer info remains hidden unless there are no confidential folios or if there are confidential folios,
                //then remains hidden until it is confirmed that user has permission to view confidential folios
                if (this.requestWorkspaceViewModel.TaxpayerID == 1) {
                    $(".customerInfo").show();
                }
                ;
                var generateContext = this.GenerateContextMenu(appSettings);
                var baseURL = this.appSettings.serverPath;
                var psrInterviewPath = this.appSettings.psrInterviewPath;
                var detailInit = this.DetailInit;
                var executeConfidentialFolioAndInterviewCleanUp = this.ExecuteConfidentialFolioAndInterviewCleanUp;
                var removeGridWhenNoData = this.RemoveGridWhenNoData;
                var requestURL = "odata/View_RequestFolioGrid?$filter=(RequestID eq " + this.requestWorkspaceViewModel.RequestParentRootID + ")";
                var dataSource = new kendo.data.DataSource({
                    type: "odata",
                    transport: {
                        read: {
                            //setting url AND dataType json removes additional paramaters that odata controller does not recognize
                            url: baseURL + requestURL,
                            dataType: "json"
                        }
                    },
                    schema: {
                        data: function (data) { return data.value; },
                        total: function (data) { return data["odata.count"]; }
                    }
                });
                angular.element("#gridRequestFolio").kendoGrid({
                    autoBind: false,
                    dataSource: dataSource,
                    detailInit: function (e) {
                        detailInit(e, baseURL, psrInterviewPath);
                    },
                    dataBound: function (e) {
                        //remove grid if no data, otherwise continue
                        if (removeGridWhenNoData(this.dataSource.data()) == false) {
                            executeConfidentialFolioAndInterviewCleanUp(this.dataSource.data());
                            generateContext;
                        }
                        //uncomment to expand details on first column
                        //this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [
                        {
                            field: "RequestFolioID",
                            template: kendo.template($("#kendo-ui-interview-link-template").html()),
                            title: " ",
                            width: "25px",
                        },
                        {
                            field: "Year",
                            width: "50px"
                        }, {
                            field: "Folio",
                            template: kendo.template($("#kendo-ui-folio-link-template").html()),
                            title: "Folio",
                            width: "145px"
                        }, {
                            field: "SiteAddress",
                            title: "Address"
                        }, {
                            field: "Owner"
                        }, {
                            field: "RequestFolioTypeName",
                            title: "Type",
                            width: "70px"
                        }
                    ]
                });
                dataSource.read();
            };
            //Method to remove detail arrow for rows that have no interview
            ServiceRequestWorkspaceController.prototype.RemoveGridWhenNoData = function (data) {
                if (data.length == 0) {
                    //show customer info if there are no folios
                    $(".customerInfo").show();
                    $("#gridRequestFolio").remove();
                    return true;
                }
                else {
                    return false;
                }
            };
            //Method to remove detail arrow for rows that have no interview
            //AND displays or hides customer contact info based on whether user has permission to view confidential folios from the list
            ServiceRequestWorkspaceController.prototype.ExecuteConfidentialFolioAndInterviewCleanUp = function (data) {
                var viewConfidential = 'false';
                var isConfidential = 'false';
                //replace details column header with custom title (merged detail and first column header)
                $(".k-hierarchy-cell.k-header").replaceWith("<th colspan='2' class='k-hierarchy-cell k-header'><span class='k-link'>Interviews</span></th>");
                $(".k-hierarchy-cell.k-header").next().remove();
                //after grid is databound, loop through grid and remove detail arrow when 'Count' column is 0 or show Customer Info based on certain conditions (see below)
                $.each(data, function (i, row) {
                    var element = $('tr[data-uid="' + row.uid + '"] ');
                    //does user have permission to view conf folio info?
                    viewConfidential = element.find(".hiddenUserCanViewConfidential").val();
                    //are there any conf folios in the list?
                    if (isConfidential != 'true') {
                        isConfidential = element.find(".hiddenIsConfidential").val();
                    }
                    //remove arrow
                    if (row.get("Interviews") == 0) {
                        element.find(".k-hierarchy-cell a").remove();
                    }
                    else {
                        element.find(".k-hierarchy-cell a").replaceWith("<a class='k-plus' href='#' tabindex='-1' style='margin-left:-15px;'>" + row.get("Interviews") + "</a>");
                    }
                });
                //Displays customer info if user has permission to view confidential folios or if there are no confidential folios
                if (viewConfidential == 'true') {
                    $(".customerInfo").show();
                }
                else if (isConfidential == 'false') {
                    $(".customerInfo").show();
                }
            }; //end ExecuteConfidentialFolioAndInterviewCleanUp()
            ServiceRequestWorkspaceController.prototype.OnDatePickerKeyDown = function (e) {
                var code = e.charCode || e.keyCode;
                //date picker key pressed is 
                if (code == 27) {
                    angular.element(e.target).val('');
                }
                return false;
            };
            //Method to expand PSR Interview details
            ServiceRequestWorkspaceController.prototype.DetailInit = function (e, baseURL, psrInterviewPath) {
                var requestFolioDetailURL = "odata/PSRInterviews";
                $("<div/>").appendTo(e.detailCell).kendoGrid({
                    pageable: true,
                    dataSource: {
                        type: "odata",
                        transport: {
                            read: {
                                //setting url AND dataType json removes additional parameters that odata controller does not recognize
                                url: baseURL + requestFolioDetailURL,
                                dataType: "json"
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    CreatedDate: { type: "date" }
                                }
                            },
                            data: function (data) { return data.value; },
                            total: function (data) { return data["odata.count"]; }
                        },
                        pageSize: 5,
                        serverFiltering: true,
                        serverPaging: true,
                        filter: {
                            logic: "and",
                            filters: [
                                { field: "Folio", operator: "eq", value: e.data.Folio }
                            ]
                        },
                    },
                    columns: [
                        {
                            field: "Year",
                            title: "Year",
                            template: "<a style='font-weight:normal!important;' target='_blank' href='" + psrInterviewPath + " #:data.RequestFolioID #'>#:Year#</a>",
                            width: "25px"
                        },
                        {
                            field: "FormattedRequestNumber",
                            title: "PSR Number",
                            template: "<a style='font-weight:normal!important;' target='_blank' href='" + baseURL + "\\#/Workspace/#:data.RequestID #'>#:FormattedRequestNumber#</a>",
                            width: "50px"
                        },
                        { field: "CreatedDate", title: "Created", format: "{0:MM/dd/yyyy}", width: "50px" },
                        { field: "FullName", title: "Created By", width: "80px" },
                        { field: "StatusType", title: "Status", width: "50px" },
                        { field: "Recommendation", title: "Recommendation", width: "50px" }
                    ]
                });
            }; //end detailInit()
            //set delay for loading spinner
            ServiceRequestWorkspaceController.prototype.SetDelay = function () {
                var _this = this;
                this.$timeout(function () {
                    _this.showSpinner = false;
                }, 800);
            };
            ServiceRequestWorkspaceController.prototype.DisableSaveButton = function () {
                this.disableButton = true;
                this.saveButtonText = "Saving";
            };
            ServiceRequestWorkspaceController.prototype.EnableSaveButton = function () {
                this.disableButton = false;
                this.saveButtonText = "Save";
            };
            ServiceRequestWorkspaceController.prototype.ToggleSelectAllFlag = function () {
                //set SelectAllFlag value to false if any AddAssocRequestFlag is false for any of the associated requests
                this.SelectAllFlag = true;
                for (var i = 0; i <= this.requestActionTypeViewModel.AssociatedRequests.length - 1; i++) {
                    if (this.requestActionTypeViewModel.AssociatedRequests[i].AddAssocRequestFlag === false) {
                        this.SelectAllFlag = false;
                        break;
                    }
                    ;
                }
            };
            ServiceRequestWorkspaceController.prototype.InitializeUpload = function () {
                //upload initializitation
                var onActionUploadOperationSuccess = this.OnActionUploadOperationSuccess;
                var requestActionTypeViewModel = this.requestActionTypeViewModel;
                //kendo ui upload widget parameters
                this.actionCreateKendoUploadOptions = {
                    async: {
                        saveUrl: this.appSettings.serverPath + "Main/SaveUploadedFile",
                        removeUrl: this.appSettings.serverPath + "Main/RemoveUploadedFile/?OutputDirectory=" + angular.element('#ConfidentialUploadFileDirectory').val() + "&TempID=" + requestActionTypeViewModel.AttachmentTemporaryID,
                        autoUpload: true
                    },
                    upload: function (e) {
                        //all uploads initially go to Confidential File Directory and are stored in a temp file
                        //they are later moved to the appropriate directory once request is submitted
                        var tempDir = angular.element('#ConfidentialUploadFileDirectory').val();
                        //post parameters included with saveUrl
                        e.data = { OutputDirectory: tempDir, TempID: requestActionTypeViewModel.AttachmentTemporaryID };
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
                        onActionUploadOperationSuccess(e, requestActionTypeViewModel, this);
                    }
                };
            };
            //Upload Methods
            //check if files selected for upload meet size and file type criteria, otherwise cancel & alert user
            //nearly identical to OnUploadFileSelection function in serviceRequestFormController.ts, therefore any changes there should probably be done here
            //no time to refactor for now
            ServiceRequestWorkspaceController.prototype.OnActionUploadFileSelection = function (e) {
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
            ServiceRequestWorkspaceController.prototype.OnActionUploadOperationSuccess = function (e, requestActionTypeResolved, uploadWidget) {
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
            //End Upload Methods
            //When displayFieldValueInCommentsFlag == true for a custom select box, the value of the select box is added to the comments field
            ServiceRequestWorkspaceController.prototype.SelectListChange = function (selectListValue, displayFieldValueInCommentsFlag) {
                if (displayFieldValueInCommentsFlag) {
                    var comments = this.requestActionTypeViewModel.Comments == null ? '' : this.requestActionTypeViewModel.Comments;
                    this.requestActionTypeViewModel.Comments = selectListValue + ". " + comments;
                }
            };
            ServiceRequestWorkspaceController.prototype.ToggleAssocRequestSelectAll = function (selectAllFlag) {
                //get whether this action changes the request status
                var blnActionChangesStatus = this.requestActionTypeViewModel.ChangeRequestStatus;
                if (selectAllFlag == true) {
                    angular.forEach(this.requestActionTypeViewModel.AssociatedRequests, function (value, key) {
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
                    angular.forEach(this.requestActionTypeViewModel.AssociatedRequests, function (value, key) {
                        value.AddAssocRequestFlag = false;
                    });
                }
            };
            //uses odata controller method
            //GetRequest(): void {
            //    var requestWorkspaceViewModelResource = this.dataAccessService.getRequestResource('/GetRequestWorkspaceViewModel');
            //    var newRequestWorkspaceViewModelResource = new requestWorkspaceViewModelResource({ RequestID: this.$stateParams.Id });
            //    newRequestWorkspaceViewModelResource.$save({}, (data: app.domain.IRequestWorkspaceViewModel) =>
            //    {
            //        this.requestWorkspaceViewModel = data;
            //          this.SetDelay();
            //    }, (error: any) => { console.log(error); });
            //}
            //uses regular MVC controller method
            ServiceRequestWorkspaceController.prototype.GetRequest = function () {
                var _this = this;
                //custom odata action GetRequestWorkspaceViewModel defined in webapi config
                var requestWorkspaceViewModelResource = this.dataAccessService.getRequestWorkspaceViewModelResource('GetRequestWorkspaceViewModel/');
                var newRequestWorkspaceViewModelResource = new requestWorkspaceViewModelResource();
                newRequestWorkspaceViewModelResource.$get({ id: this.$stateParams.Id }, function (data) {
                    _this.requestWorkspaceViewModel = data;
                    _this.GenerateRequestFolioGrid(_this.appSettings);
                    _this.ReportURL = _this.appSettings.psrConfirmationReportPath + data.RequestParentRootID;
                    _this.SetDelay();
                }, function (error) {
                    alert("Encountered an error when processing your request.\nYou will be redirected to the search page.\nError:\n" + error.statusText);
                    _this.$state.go('Search');
                });
            };
            ServiceRequestWorkspaceController.prototype.SetActionOrderBy = function (sortBy) {
                var _this = this;
                this.requestWorkspaceViewModel.BlnAsc = (this.requestWorkspaceViewModel.SortBy === sortBy) ? !this.requestWorkspaceViewModel.BlnAsc : false;
                this.requestWorkspaceViewModel.SortBy = sortBy;
                var sortedRequestActionResource = this.dataAccessService.getRequestActionResource('/SortRequestActions');
                var newsortedRequestActionResource = new sortedRequestActionResource({ RequestID: this.$stateParams.Id, SortBy: this.requestWorkspaceViewModel.SortBy, BlnAsc: this.requestWorkspaceViewModel.BlnAsc });
                newsortedRequestActionResource.$save({}, function (data) { _this.requestWorkspaceViewModel.RequestActions = data.RequestActions; }, function (error) { console.log(error); });
            };
            ServiceRequestWorkspaceController.prototype.ViewAttachment = function (requestAttachmentName, subFolder, isConfidential) {
                if (!isConfidential && this.requestWorkspaceViewModel.ViewAttachmentFlag) {
                    var path = angular.element('#DocumentVirtualPath').val() + subFolder + requestAttachmentName;
                    window.open(path);
                }
                else if (isConfidential && this.requestWorkspaceViewModel.ViewConfidentialAttachmentFlag && this.requestWorkspaceViewModel.ViewAttachmentFlag) {
                    var path = angular.element('#ConfidentialDocumentVirtualPath').val() + subFolder + requestAttachmentName;
                    window.open(path);
                }
                else {
                    alert('You are not authorized to view this file.');
                }
            };
            ServiceRequestWorkspaceController.prototype.OpenModal = function (requestActionTypeId, requestID) {
                var requestWorkspaceViewModel = this.requestWorkspaceViewModel;
                var baseURL = this.appSettings.serverPath;
                var dataAccessService = this.dataAccessService;
                var modalInstance = this.$uibModal.open({
                    animation: true,
                    templateUrl: baseURL + 'app/serviceRequests/serviceRequestAddActionModal.html',
                    backdrop: 'static',
                    controller: 'ServiceRequestAddActionController',
                    controllerAs: 'vm',
                    //bindToController: true,
                    size: 'lg',
                    resolve: {
                        requestActionTypeResolved: function () {
                            var requestActionResource = dataAccessService.getRequestActionResource('/GetRequestActionTypeViewModel');
                            return new requestActionResource({ RequestServiceTypeID: requestWorkspaceViewModel.ServiceTypeID, RequestActionTypeID: requestActionTypeId, RequestID: requestID, AssociatedRequests: requestWorkspaceViewModel.AssociatedRequests, RequestChildrenCloseParentFlag: requestWorkspaceViewModel.CloseWhenChildrenAreClosedFlag, ConcurrentCreationOfChildrenFlag: requestWorkspaceViewModel.ConcurrentCreationOfChildrenFlag, TaxpayerID: requestWorkspaceViewModel.TaxpayerID }).$save().catch(function (reason) {
                                console.log(reason);
                            });
                        },
                        requestWorkspaceResolved: function () {
                            return requestWorkspaceViewModel;
                        }
                    }
                });
            };
            ServiceRequestWorkspaceController.prototype.GetRequestActionType = function (requestActionTypeId) {
                var _this = this;
                this.CustomStatusConstraintMessage = "";
                if (requestActionTypeId == null) {
                    this.requestActionTypeViewModel = null;
                }
                else {
                    var requestActionResource = this.dataAccessService.getRequestActionResource('/GetRequestActionTypeViewModel');
                    var newRequestActionResource = new requestActionResource({ RequestServiceTypeID: this.requestWorkspaceViewModel.ServiceTypeID, RequestActionTypeID: requestActionTypeId, RequestID: this.requestWorkspaceViewModel.RequestID, AssociatedRequests: this.requestWorkspaceViewModel.AssociatedRequests, RequestChildrenCloseParentFlag: this.requestWorkspaceViewModel.CloseWhenChildrenAreClosedFlag, ConcurrentCreationOfChildrenFlag: this.requestWorkspaceViewModel.ConcurrentCreationOfChildrenFlag, TaxpayerID: this.requestWorkspaceViewModel.TaxpayerID });
                    newRequestActionResource.$save({}, function (data) {
                        //preserve comments in case user made a mistake in initial update action selection
                        if (_this.requestActionTypeViewModel != undefined) {
                            var comments = _this.requestActionTypeViewModel.Comments;
                        }
                        _this.requestActionTypeViewModel = data;
                        _this.requestActionTypeViewModel.Comments = comments;
                        _this.InitializeUpload();
                    }, function (error) { console.log(error); });
                }
            };
            ServiceRequestWorkspaceController.prototype.Save = function () {
                var _this = this;
                this.CustomStatusConstraintMessage = "";
                if (!this.requestActionTypeViewModel.ByPassClientSideValidation) {
                    //CUSTOM LOGIC - NON CONFIGURATION ARRRGGGHHH!
                    if (this.requestActionTypeViewModel.SelectedStatus && this.requestActionTypeViewModel.RequestActionTypeID != 10) {
                        if (this.requestActionTypeViewModel.SelectedStatus.StatusValue == 5 && !this.requestWorkspaceViewModel.CompletionDate) {
                            this.CustomStatusConstraintMessage = "Cannot reopen if request is not completed or cancelled.";
                            return;
                        }
                        if (this.requestWorkspaceViewModel.CompletionDate && this.requestActionTypeViewModel.SelectedStatus.StatusValue != 5) {
                            this.CustomStatusConstraintMessage = "Cannot update request unless the PSR is reopened first.";
                            return;
                        }
                        if ((this.requestActionTypeViewModel.SelectedStatus.StatusValue == 2 || this.requestActionTypeViewModel.SelectedStatus.StatusValue == 4 || this.requestActionTypeViewModel.SelectedStatus.StatusValue == 6) && !this.requestActionTypeViewModel.Comments) {
                            this.CustomStatusConstraintMessage = "Please input comments.";
                            return;
                        }
                    }
                    else if (this.requestActionTypeViewModel.RequestActionTypeID == 10 && this.requestWorkspaceViewModel.RequestStatus == "Not Started") {
                        if (this.requestActionTypeViewModel.SelectedStatus) {
                            if (this.requestActionTypeViewModel.SelectedStatus.StatusValue == null) {
                                this.requestActionTypeViewModel.SelectedStatus.StatusValue = 3; //In-Progress
                                this.requestActionTypeViewModel.SelectedStatus.StatusOpensRequest = true;
                                this.requestActionTypeViewModel.SelectedStatus.StatusClosesRequest = false;
                            }
                        }
                        else {
                            this.requestActionTypeViewModel.SelectedStatus = {
                                StatusValue: 3,
                                StatusOpensRequest: true,
                                StatusClosesRequest: false,
                                StatusName: ''
                            };
                        }
                    }
                    //END CUSTOM LOGIC - NON CONFIGURATION
                }
                this.DisableSaveButton();
                var newRequestAction = this.GenerateAction();
                var requestActionResource = this.dataAccessService.getRequestActionResource('/CreateRequestAction');
                var requestAction = new requestActionResource({ 'NewAction': newRequestAction });
                requestAction.$save({}, function (data) {
                    //update requestWorkspaceModel with new refreshed data
                    _this.UpdateRequestWorkspace(data);
                    _this.EnableSaveButton();
                    _this.ResetForm();
                }, function (error) { console.log(error); });
            };
            ;
            ServiceRequestWorkspaceController.prototype.ResetForm = function () {
                this.SelectAllFlag = false;
                this.requestActionTypeViewModel = null;
                this.selectedRequestActionTypeID = null;
                //reset all validations to pristine and untouched state
                this.$scope.addActionForm.$setPristine();
                this.$scope.addActionForm.$setUntouched();
            };
            ServiceRequestWorkspaceController.prototype.UpdateRequestWorkspace = function (data) {
                this.requestWorkspaceViewModel.ServiceTypeID = data.ServiceTypeID;
                this.requestWorkspaceViewModel.ServiceTypeName = data.ServiceTypeName;
                this.requestWorkspaceViewModel.RequestStatus = data.RequestStatus;
                this.requestWorkspaceViewModel.RequestStatusColor = data.RequestStatusColor;
                this.requestWorkspaceViewModel.Resolution = data.Resolution;
                this.requestWorkspaceViewModel.CompletionDate = data.CompletionDate;
                this.requestWorkspaceViewModel.CurrentlyAssignedWorker = data.CurrentlyAssignedWorker;
                this.requestWorkspaceViewModel.BlnAsc = data.BlnAsc;
                this.requestWorkspaceViewModel.SortBy = data.SortBy;
                this.requestWorkspaceViewModel.RequestActions = data.RequestActions;
                this.requestWorkspaceViewModel.RequestAttachments = data.RequestAttachments;
                this.requestWorkspaceViewModel.AssociatedRequests = data.AssociatedRequests;
                this.requestWorkspaceViewModel.RequestAvailableActions = data.RequestAvailableActions;
            };
            ServiceRequestWorkspaceController.prototype.GenerateAction = function () {
                var newRequestAction = {
                    RequestID: this.requestWorkspaceViewModel.RequestID,
                    ServiceTypeID: this.requestWorkspaceViewModel.ServiceTypeID,
                    ServiceTypeName: this.requestWorkspaceViewModel.ServiceTypeName,
                    RequestParentRootID: this.requestWorkspaceViewModel.RequestParentRootID,
                    //value taken from requestWorkspaceViewModel instead of requestActionTypeResolved to avoid additional query in GetRequestActionTypeViewModel server controller method 
                    FormattedRequestNumber: this.requestWorkspaceViewModel.FormattedRequestNumber,
                    RequestUpdateNotificationFlag: this.requestWorkspaceViewModel.NotifyOfProgress,
                    RequestUpdateNotificationEmail: this.requestWorkspaceViewModel.RequestUpdateNotificationEmail,
                    RequestActionTypeID: this.requestActionTypeViewModel.RequestActionTypeID,
                    SelectedOwnerGroup: this.requestActionTypeViewModel.SelectedOwnerGroup,
                    SelectedUser: this.requestActionTypeViewModel.SelectedUser,
                    SelectedStatus: this.requestActionTypeViewModel.SelectedStatus,
                    SelectedServiceType: this.requestActionTypeViewModel.SelectedServiceType,
                    AssignUserFlag: this.requestActionTypeViewModel.AssignUserFlag,
                    UpdateServiceType: this.requestActionTypeViewModel.UpdateServiceType,
                    UpdateRequestFolio: this.requestActionTypeViewModel.UpdateRequestFolio,
                    ConcurrentCreationOfChildrenFlag: this.requestActionTypeViewModel.ConcurrentCreationOfChildrenFlag,
                    RequestActionTypeName: this.requestActionTypeViewModel.RequestActionTypeName,
                    BackgroundColor: null,
                    TextColor: null,
                    Comments: this.requestActionTypeViewModel.Comments,
                    ChangeRequestStatus: this.requestActionTypeViewModel.ChangeRequestStatus,
                    ReassignRequest: this.requestActionTypeViewModel.ReassignRequest,
                    UploadDocument: this.requestActionTypeViewModel.UploadDocument,
                    AllowReplication: this.requestActionTypeViewModel.AllowReplication,
                    RequestActionCustomFields: this.requestActionTypeViewModel.RequestActionCustomFields,
                    RequestAttachments: this.requestActionTypeViewModel.RequestAttachments,
                    AssociatedRequests: this.requestActionTypeViewModel.AssociatedRequests,
                    OutputDirectory: angular.element('#UploadFileDirectory').val(),
                    ConfidentialOutputDirectory: angular.element('#ConfidentialUploadFileDirectory').val(),
                    //temp id is used to name temp folder where uploaded files will be stored, until action is saved
                    AttachmentTemporaryID: this.requestActionTypeViewModel.AttachmentTemporaryID,
                    AddActionPermission: this.requestActionTypeViewModel.AddActionPermission,
                    UpdateActionPermission: this.requestActionTypeViewModel.UpdateActionPermission,
                    DeleteActionPermission: this.requestActionTypeViewModel.DeleteActionPermission,
                    CloseWhenChildrenAreClosedFlag: this.requestWorkspaceViewModel.CloseWhenChildrenAreClosedFlag,
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
            return ServiceRequestWorkspaceController;
        }());
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestWorkspaceController.$inject = ['$scope', '$stateParams', 'dataAccessService', '$timeout', '$uibModal', 'appSettings', '$state'];
        //register controller with the main angular module defined in app.ts
        angular.module('serviceRequestApp')
            .controller('ServiceRequestWorkspaceController', ServiceRequestWorkspaceController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestWorkspaceController.js.map