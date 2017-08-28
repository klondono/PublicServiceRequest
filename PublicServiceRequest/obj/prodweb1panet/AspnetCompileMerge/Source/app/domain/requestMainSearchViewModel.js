var app;
(function (app) {
    var domain;
    (function (domain) {
        var MainSearchViewModel = (function () {
            function MainSearchViewModel(RequestNo, Folio, Requestor, CreatedFrom, CreatedTo, StatusList, AssigneeList, SelectedStatusID, SelectedAssignee) {
                this.RequestNo = RequestNo;
                this.Folio = Folio;
                this.Requestor = Requestor;
                this.CreatedFrom = CreatedFrom;
                this.CreatedTo = CreatedTo;
                this.StatusList = StatusList;
                this.AssigneeList = AssigneeList;
                this.SelectedStatusID = SelectedStatusID;
                this.SelectedAssignee = SelectedAssignee;
            }
            return MainSearchViewModel;
        }());
        domain.MainSearchViewModel = MainSearchViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestMainSearchViewModel.js.map