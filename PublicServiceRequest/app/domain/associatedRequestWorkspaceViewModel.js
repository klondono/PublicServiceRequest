var app;
(function (app) {
    var domain;
    (function (domain) {
        var AssociatedRequestWorkspaceViewModel = (function () {
            function AssociatedRequestWorkspaceViewModel(RequestID, FormattedRequestNumber, ServiceTypeName, ServiceTypeOwnerName, RequestCurrentWorkerFullName, RequestStatus, RequestStatusColor, CreatedDate, DueDate, DueDatePassed, CompletionDate, AddAssocRequestFlag, CloseWhenChildrenAreClosedFlag) {
                this.RequestID = RequestID;
                this.FormattedRequestNumber = FormattedRequestNumber;
                this.ServiceTypeName = ServiceTypeName;
                this.ServiceTypeOwnerName = ServiceTypeOwnerName;
                this.RequestCurrentWorkerFullName = RequestCurrentWorkerFullName;
                this.RequestStatus = RequestStatus;
                this.RequestStatusColor = RequestStatusColor;
                this.CreatedDate = CreatedDate;
                this.DueDate = DueDate;
                this.DueDatePassed = DueDatePassed;
                this.CompletionDate = CompletionDate;
                this.AddAssocRequestFlag = AddAssocRequestFlag;
                this.CloseWhenChildrenAreClosedFlag = CloseWhenChildrenAreClosedFlag;
            }
            return AssociatedRequestWorkspaceViewModel;
        }());
        domain.AssociatedRequestWorkspaceViewModel = AssociatedRequestWorkspaceViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=associatedRequestWorkspaceViewModel.js.map