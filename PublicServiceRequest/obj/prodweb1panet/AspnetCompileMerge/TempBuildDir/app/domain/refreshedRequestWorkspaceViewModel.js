var app;
(function (app) {
    var domain;
    (function (domain) {
        var RefreshedRequestWorkspaceViewModel = (function () {
            function RefreshedRequestWorkspaceViewModel(RequestID, ServiceTypeID, ServiceTypeName, RequestStatus, RequestStatusColor, Resolution, CompletionDate, CurrentWorkerIsGroupFlag, CurrentlyAssignedWorker, SortBy, BlnAsc, RequestActions, RequestAttachments, AssociatedRequests, RequestAvailableActions) {
                this.RequestID = RequestID;
                this.ServiceTypeID = ServiceTypeID;
                this.ServiceTypeName = ServiceTypeName;
                this.RequestStatus = RequestStatus;
                this.RequestStatusColor = RequestStatusColor;
                this.Resolution = Resolution;
                this.CompletionDate = CompletionDate;
                this.CurrentWorkerIsGroupFlag = CurrentWorkerIsGroupFlag;
                this.CurrentlyAssignedWorker = CurrentlyAssignedWorker;
                this.SortBy = SortBy;
                this.BlnAsc = BlnAsc;
                this.RequestActions = RequestActions;
                this.RequestAttachments = RequestAttachments;
                this.AssociatedRequests = AssociatedRequests;
                this.RequestAvailableActions = RequestAvailableActions;
            }
            return RefreshedRequestWorkspaceViewModel;
        }());
        domain.RefreshedRequestWorkspaceViewModel = RefreshedRequestWorkspaceViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=refreshedRequestWorkspaceViewModel.js.map