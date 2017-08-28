var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestOriginViewModel = (function () {
            function RequestOriginViewModel(RequestOriginID, RequestOriginName, RequestOriginDescription, AutoSelectedForActiveDirectoryGroup, DisableProgressNotificationForAutoSelectedGroupFlag, ForceAutoSelectedOriginFlag, AdmIsActive) {
                this.RequestOriginID = RequestOriginID;
                this.RequestOriginName = RequestOriginName;
                this.RequestOriginDescription = RequestOriginDescription;
                this.AutoSelectedForActiveDirectoryGroup = AutoSelectedForActiveDirectoryGroup;
                this.DisableProgressNotificationForAutoSelectedGroupFlag = DisableProgressNotificationForAutoSelectedGroupFlag;
                this.ForceAutoSelectedOriginFlag = ForceAutoSelectedOriginFlag;
                this.AdmIsActive = AdmIsActive;
            }
            return RequestOriginViewModel;
        }());
        domain.RequestOriginViewModel = RequestOriginViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestOriginViewModel.js.map