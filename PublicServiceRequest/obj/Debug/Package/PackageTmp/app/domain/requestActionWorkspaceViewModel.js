var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestActionWorkspaceViewModel = (function () {
            function RequestActionWorkspaceViewModel(RequestActionID, ActionTypeName, ActionStatusChangedName, ActionStatusChangedColor, ActionAssignedUserFullName, ActionComments, ActionAddedBy, ActionAddedDate, ActionModifiedBy, ActionModifiedDate, BackgroundColor, TextColor, DisplayFlag) {
                this.RequestActionID = RequestActionID;
                this.ActionTypeName = ActionTypeName;
                this.ActionStatusChangedName = ActionStatusChangedName;
                this.ActionStatusChangedColor = ActionStatusChangedColor;
                this.ActionAssignedUserFullName = ActionAssignedUserFullName;
                this.ActionComments = ActionComments;
                this.ActionAddedBy = ActionAddedBy;
                this.ActionAddedDate = ActionAddedDate;
                this.ActionModifiedBy = ActionModifiedBy;
                this.ActionModifiedDate = ActionModifiedDate;
                this.BackgroundColor = BackgroundColor;
                this.TextColor = TextColor;
                this.DisplayFlag = DisplayFlag;
            }
            return RequestActionWorkspaceViewModel;
        }());
        domain.RequestActionWorkspaceViewModel = RequestActionWorkspaceViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestActionWorkspaceViewModel.js.map