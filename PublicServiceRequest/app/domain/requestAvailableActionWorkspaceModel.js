var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestAvailableActionWorkspaceViewModel = (function () {
            function RequestAvailableActionWorkspaceViewModel(RequestActionTypeID, RequestActionTypeName, RequestActionTypeDescription, BackgroundColor, RequestWorkspaceDisplayCode, TextColor) {
                this.RequestActionTypeID = RequestActionTypeID;
                this.RequestActionTypeName = RequestActionTypeName;
                this.RequestActionTypeDescription = RequestActionTypeDescription;
                this.BackgroundColor = BackgroundColor;
                this.RequestWorkspaceDisplayCode = RequestWorkspaceDisplayCode;
                this.TextColor = TextColor;
            }
            return RequestAvailableActionWorkspaceViewModel;
        }());
        domain.RequestAvailableActionWorkspaceViewModel = RequestAvailableActionWorkspaceViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestAvailableActionWorkspaceModel.js.map