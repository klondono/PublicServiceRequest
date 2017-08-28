var app;
(function (app) {
    var serviceRequest;
    (function (serviceRequest) {
        //define class (aka controller) that implements interface
        var ServiceRequestMainSearchController = (function () {
            //constructor: include properties to be exposed when class is instantiated including injected dependencies
            function ServiceRequestMainSearchController(appSettings, dataAccessService, $state, $stateParams) {
                this.appSettings = appSettings;
                this.dataAccessService = dataAccessService;
                this.$state = $state;
                this.$stateParams = $stateParams;
                //declare properties for class
                this.requestSearchKendoGridOptions = {};
                this.ShowDashboard = true;
                //hide dashboard and home link if request comes in from the following URL state
                var isPAUser = angular.element('#IsPAUser').val();
                if (isPAUser == "False") {
                    this.ShowDashboard = false;
                }
                this.InitializeRequestMainSearch();
                this.GenerateSearchGrid();
                this.getMyDashboardViewModel();
            } //end constructor    
            //controller methods
            ServiceRequestMainSearchController.prototype.InitializeRequestMainSearch = function () {
                var _this = this;
                var initializeRequestMainSearchResource = this.dataAccessService.getRequestResource('/InitializeRequestMainSearch');
                var newinitializeRequestMainSearchResource = new initializeRequestMainSearchResource();
                newinitializeRequestMainSearchResource.$save({}, function (data) {
                    _this.mainSearchViewModel = data;
                    //if router state is named Search_Folio then clear default search criteria, get folio parameter and search by folio no
                    if (_this.$state.current.name == 'Search_Folio') {
                        _this.mainSearchViewModel.SelectedAssignee = { AssigneeID: 0, AssigneeName: "- All -", AssigneeType: "", AssigneeUniqueID: "0" };
                        _this.mainSearchViewModel.Folio = _this.$stateParams.Folio;
                        _this.mainSearchViewModel.SelectedStatusID = 0;
                        _this.Search();
                    }
                    else {
                        _this.Search();
                    }
                }, function (error) { console.log(error); });
            };
            ServiceRequestMainSearchController.prototype.ExecuteDashboardFilter = function () {
                alert('Feature Coming Soon!');
            };
            ServiceRequestMainSearchController.prototype.GenerateSearchGrid = function () {
                var baseURL = this.appSettings.serverPath;
                var requestURL = "odata/View_RequestMainSearchGridWFolio";
                var detailInit = this.DetailInit;
                var hideWhenNoDetail = this.HideWhenNoDetail;
                this.requestSearchKendoGridOptions = {
                    dataSource: {
                        type: "odata",
                        transport: {
                            read: {
                                //setting url AND dataType json removes additional paramaters that odata controller does not recognize
                                url: baseURL + requestURL,
                                dataType: "json"
                            }
                        },
                        pageSize: 25,
                        schema: {
                            model: {
                                fields: {
                                    AdmDateAddedNoTime: { type: "date" },
                                    AdmDateAdded: { type: "date" },
                                    RequestCompletionDate: { type: "date" }
                                },
                            },
                            data: function (data) { return data.value; },
                            total: function (data) { return data["odata.count"]; }
                        },
                        //filter: {
                        //    filters: [{ field: "CurrentlyAssigned", operator: "eq", value: selectedAssignee }]
                        //},
                        serverPaging: true,
                        serverSorting: true,
                        //sort: { field: "RequestID", dir: "desc" },
                        serverFiltering: true
                    },
                    autoBind: false,
                    columnMenu: true,
                    height: 700,
                    groupable: true,
                    //toolbar: ["excel", "pdf"],
                    //excel: { allPages: true },
                    //pdf: { allPages: true },
                    reorderable: true,
                    resizable: true,
                    sortable: { mode: "multiple" },
                    allowCopy: true,
                    filterable: {
                        extra: false,
                        operators: {
                            string: {
                                contains: "Contains",
                                eq: "Equal to",
                                neq: "Not equal to"
                            },
                            date: {
                                eq: "Equal to",
                                gt: "After",
                                lt: "Before"
                            }
                        }
                    },
                    pageable: {
                        refresh: true,
                        pageSizes: true,
                        buttonCount: 5
                    },
                    //detailinit function and dataBound property enables detail view expand
                    detailInit: function (e) {
                        detailInit(e, baseURL);
                    },
                    dataBound: function (e) {
                        hideWhenNoDetail(this.dataSource.data());
                        //uncomment to expand details on first column
                        //this.expandRow(this.tbody.find("tr.k-master-row").first());
                    },
                    columns: [
                        { field: "FormattedRequestNumber", template: "<a target='_blank' ui-sref='Workspace({Id: #:data.RequestID #})'>#:FormattedRequestNumber #</a>", title: "PSR Number", width: "115px", groupable: false },
                        {
                            field: "ServiceTypeName", title: "Service",
                            filterable: {
                                multi: true,
                                dataSource: {
                                    type: "odata",
                                    transport: {
                                        read: {
                                            url: baseURL + "odata/ServiceTypes?$filter=(AdmIsActive eq 'Y')&$orderby=ServiceTypeName",
                                            dataType: "json",
                                            data: {
                                                field: "ServiceTypeName"
                                            }
                                        }
                                    },
                                    schema: {
                                        data: function (data) { return data.value; },
                                        total: function (data) { return data["odata.count"]; }
                                    }
                                }
                            },
                            width: "120px"
                        },
                        {
                            field: "CurrentlyAssigned", title: "Assigned To",
                            filterable: {
                                multi: true,
                                dataSource: {
                                    type: "odata",
                                    transport: {
                                        read: {
                                            url: baseURL + "odata/View_PSRCurrentlyAssigned",
                                            dataType: "json",
                                            data: {
                                                field: "CurrentlyAssigned"
                                            }
                                        }
                                    },
                                    schema: {
                                        data: function (data) { return data.value; },
                                        total: function (data) { return data["odata.count"]; }
                                    }
                                }
                            },
                            width: "130px"
                        },
                        //{ field: "ServiceTypeOwnerGroupName", title: "Business Area", filterable: { multi: true }, width: "130px"},
                        {
                            field: "RequestStatusName", template: "<span style='font-weight:bold; color:#:data.RequestStatusColor #'>#: RequestStatusName #</span>", title: "Status",
                            filterable: {
                                multi: true,
                                dataSource: {
                                    type: "odata",
                                    transport: {
                                        read: {
                                            url: baseURL + "odata/RequestStatus?$filter=(AdmIsActive eq 'Y')",
                                            dataType: "json",
                                            data: {
                                                field: "RequestStatusName"
                                            }
                                        }
                                    },
                                    schema: {
                                        data: function (data) { return data.value; },
                                        total: function (data) { return data["odata.count"]; }
                                    }
                                }
                            },
                            width: "80px"
                        },
                        {
                            field: "RequestOriginName", title: "Origin",
                            hidden: true,
                            filterable: {
                                multi: true,
                                dataSource: {
                                    type: "odata",
                                    transport: {
                                        read: {
                                            url: baseURL + "odata/RequestOrigins?$orderby=RequestOriginName",
                                            dataType: "json",
                                            data: {
                                                field: "RequestOriginName"
                                            }
                                        }
                                    },
                                    schema: {
                                        data: function (data) { return data.value; },
                                        total: function (data) { return data["odata.count"]; }
                                    }
                                }
                            },
                            width: "85px"
                        },
                        {
                            field: "RequestPriorityName", title: "Priority",
                            filterable: {
                                multi: true,
                                dataSource: {
                                    type: "odata",
                                    transport: {
                                        read: {
                                            url: baseURL + "odata/RequestPriorities?$filter=(AdmIsActive eq 'Y')&$orderby=RequestPriorityName",
                                            dataType: "json",
                                            data: {
                                                field: "RequestPriorityName"
                                            }
                                        }
                                    },
                                    schema: {
                                        data: function (data) { return data.value; },
                                        total: function (data) { return data["odata.count"]; }
                                    }
                                }
                            },
                            width: "85px"
                        },
                        { field: "AdmDateAdded", title: "Created", format: "{0:MM/dd/yyyy hh:mm tt}", filterable: { ui: "datepicker" }, width: "100px", groupable: false },
                        //{ field: "RequestDueDate", title: "Due Date", template: "<span style='color:#:data.DueDateColor #'>#: kendo.toString(RequestDueDate,'MM/dd/yyyy') #</span>", filterable: { ui: "datepicker" }, width: "100px", groupable: false },
                        { field: "RequestCompletionDate", title: "Completed", format: "{0:MM/dd/yyyy}", filterable: { ui: "datepicker" }, width: "100px", groupable: false },
                        { field: "Requestor", title: "Customer", width: "130px" },
                        { field: "CreatedBy", title: "Created By",
                            filterable: {
                                multi: true,
                                dataSource: {
                                    type: "odata",
                                    transport: {
                                        read: {
                                            url: baseURL + "odata/View_PSRAdmUserAdded",
                                            dataType: "json",
                                            data: {
                                                field: "CreatedBy"
                                            }
                                        }
                                    },
                                    schema: {
                                        data: function (data) { return data.value; },
                                        total: function (data) { return data["odata.count"]; }
                                    }
                                }
                            },
                            width: "140px"
                        }
                    ]
                }; //end kendo grid options
            };
            //Method to expand grid folio details
            ServiceRequestMainSearchController.prototype.DetailInit = function (e, baseURL) {
                var requestFolioDetailURL = "odata/View_RequestFolioByRequestNumberAndYear";
                $("<div/>").appendTo(e.detailCell).kendoGrid({
                    dataSource: {
                        type: "odata",
                        transport: {
                            read: {
                                //setting url AND dataType json removes additional paramaters that odata controller does not recognize
                                url: baseURL + requestFolioDetailURL,
                                dataType: "json"
                            }
                        },
                        schema: {
                            data: function (data) { return data.value; },
                            total: function (data) { return data["odata.count"]; }
                        },
                        serverPaging: true,
                        serverSorting: true,
                        serverFiltering: true,
                        pageSize: 5,
                        filter: {
                            logic: "and",
                            filters: [
                                { field: "RequestNumber", operator: "eq", value: e.data.RequestNumber },
                                { field: "RequestYear", operator: "eq", value: e.data.RequestYear }
                            ]
                        },
                    },
                    //scrollable: false,
                    //sortable: true,
                    //pageable: true,
                    columns: [
                        { field: "FormattedFolio", title: "Folio", width: "120px", headerTemplate: "<span style='font-weight:bold; color: #666666;'>Folio</span>" },
                        { field: "RequestFolioTypeName", title: "Type", width: "70px", headerTemplate: "<span style='font-weight:bold; color: #666666;'>Type</span>" },
                        { field: "Year", title: "Year", width: "70px", headerTemplate: "<span style='font-weight:bold; color: #666666;'>Year</span>" },
                        { field: "Owner", title: "Owner at Time of Request", width: "200px", headerTemplate: "<span style='font-weight:bold; color: #666666;'>Owner at Time of Request</span>" },
                        { title: "Site Address", width: "200px", template: "#= data.SiteAddress # #=data.ZipCode #", headerTemplate: "<span style='font-weight:bold; color: #666666;'>Site Address</span>" }
                    ]
                });
            }; //end detailInit()
            //method is called when search button is pressed
            ServiceRequestMainSearchController.prototype.Search = function () {
                var grid = angular.element('#gridRequestSearch').data('kendoGrid');
                grid.dataSource.query({
                    //sort: { field: "RequestID", dir: "desc" },
                    page: 1,
                    pageSize: 20,
                    filter: {
                        logic: "and",
                        filters: this.GetDynamicFilter()
                    }
                });
            };
            ServiceRequestMainSearchController.prototype.ClearFilter = function () {
                //angular.element("form.k-filter-menu button[type = 'reset']").trigger('click');
                this.mainSearchViewModel.SelectedStatusID = 0;
                this.mainSearchViewModel.CreatedFrom = '';
                this.mainSearchViewModel.CreatedTo = '';
                this.mainSearchViewModel.Folio = '';
                this.mainSearchViewModel.RequestNo = '';
                this.mainSearchViewModel.SelectedAssignee = { AssigneeID: 0, AssigneeName: "- All -", AssigneeType: "", AssigneeUniqueID: "0" };
                this.mainSearchViewModel.Requestor = '';
                this.Search();
                //var grid: kendo.ui.Grid = angular.element('#gridRequestSearch').data('kendoGrid');
                //grid.dataSource.data([]);
            };
            ServiceRequestMainSearchController.prototype.GetDynamicFilter = function () {
                //initialize dynamic filter array
                var dynamicFilter = [];
                //for each property, check if there is a value, if so, add filter object to dynamic filter array
                if (this.mainSearchViewModel.CreatedFrom.trim().length != 0 && this.mainSearchViewModel.CreatedTo.trim().length != 0) {
                    //easier to add additional field in SQL view that did not include time portion to get this filter to work
                    var dateFromFilter = { field: "AdmDateAddedNoTime", operator: "ge", value: new Date(this.mainSearchViewModel.CreatedFrom) };
                    dynamicFilter.push(dateFromFilter);
                    var dateToFilter = { field: "AdmDateAddedNoTime", operator: "le", value: new Date(this.mainSearchViewModel.CreatedTo) };
                    dynamicFilter.push(dateToFilter);
                }
                if (this.mainSearchViewModel.SelectedAssignee.AssigneeUniqueID != "0") {
                    var assigneeFilter = { field: "CurrentlyAssigned", operator: "eq", value: this.mainSearchViewModel.SelectedAssignee.AssigneeName };
                    dynamicFilter.push(assigneeFilter);
                }
                if (this.mainSearchViewModel.SelectedStatusID != 0) {
                    var statusFilter = this.mainSearchViewModel.SelectedStatusID == 1 ? { field: "RequestCompletionDate", operator: "eq", value: null } :
                        //this.mainSearchViewModel.SelectedStatusID == 3 ? { field: "DueDateColor", operator: "eq", value: "#e50000" } :
                        //this.mainSearchViewModel.SelectedStatusID == 4 ? { field: "NotClosed", operator: "eq", value: 1 } :
                        { field: "RequestCompletionDate", operator: "ne", value: null };
                    dynamicFilter.push(statusFilter);
                }
                if (this.mainSearchViewModel.RequestNo.trim().length != 0) {
                    var requestNoFilter = { field: "FormattedRequestNumber", operator: "contains", value: this.mainSearchViewModel.RequestNo };
                    dynamicFilter.push(requestNoFilter);
                }
                if (this.mainSearchViewModel.Requestor.trim().length != 0) {
                    var requestorFilter = { field: "tolower(Requestor)", operator: "contains", value: this.mainSearchViewModel.Requestor.toLowerCase() };
                    dynamicFilter.push(requestorFilter);
                }
                if (this.mainSearchViewModel.Folio.trim().length != 0) {
                    var unformattedFolio = this.mainSearchViewModel.Folio.replace(/-|\s/g, "");
                    var requestFolioFilter = { field: "Folio", operator: "contains", value: unformattedFolio };
                    dynamicFilter.push(requestFolioFilter);
                }
                return dynamicFilter;
            };
            //Method to remove detail arrow for rows that have no folio
            ServiceRequestMainSearchController.prototype.HideWhenNoDetail = function (data) {
                //replace details column header with custom title
                $(".k-hierarchy-cell.k-header").replaceWith("<th class='k-hierarchy-cell k-header'><span class='k-link'>Folio(s)</span></th>");
                //after grid is databound, loop through grid and remove detail arrow when 'Count' column is 0
                $.each(data, function (i, row) {
                    var element = $('tr[data-uid="' + row.uid + '"] ');
                    //remove arrow
                    if (row.get("Count") == 0) {
                        element.find(".k-hierarchy-cell a").remove();
                    }
                    else {
                        element.find(".k-hierarchy-cell a").replaceWith("<a class='k-plus' href='#' tabindex='-1'>" + row.get("Count") + "</a>");
                    }
                });
            }; //end HideWhenNoDetail()
            //retreive dashboard stats for user
            ServiceRequestMainSearchController.prototype.getMyDashboardViewModel = function () {
                var _this = this;
                //custom odata action GetAssociatedServiceTypes defined in webapi config
                var myDashboardViewModelResource = this.dataAccessService.getMyDashboardViewModelResource('GetMyDashboardViewModel/');
                var newMyDashboardViewModelResource = new myDashboardViewModelResource();
                newMyDashboardViewModelResource.$get({}, function (data) { _this.myDashboardViewModel = data; }, function (error) { console.log(error); });
            };
            return ServiceRequestMainSearchController;
        }());
        //inject dependencies, must be in same order as in the constructor
        ServiceRequestMainSearchController.$inject = ['appSettings', 'dataAccessService', '$state', '$stateParams'];
        //register controller with the main angular module defined in app.ts
        angular.module('serviceRequestApp')
            .controller('ServiceRequestMainSearchController', ServiceRequestMainSearchController);
    })(serviceRequest = app.serviceRequest || (app.serviceRequest = {}));
})(app || (app = {}));
//# sourceMappingURL=serviceRequestMainSearchController.js.map