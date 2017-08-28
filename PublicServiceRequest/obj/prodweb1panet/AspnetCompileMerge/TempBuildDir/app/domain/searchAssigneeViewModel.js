var app;
(function (app) {
    var domain;
    (function (domain) {
        var SearchAssigneeViewModel = (function () {
            function SearchAssigneeViewModel(AssigneeID, AssigneeName, AssigneeType, AssigneeUniqueID) {
                this.AssigneeID = AssigneeID;
                this.AssigneeName = AssigneeName;
                this.AssigneeType = AssigneeType;
                this.AssigneeUniqueID = AssigneeUniqueID;
            }
            return SearchAssigneeViewModel;
        }());
        domain.SearchAssigneeViewModel = SearchAssigneeViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=searchAssigneeViewModel.js.map