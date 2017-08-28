var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestUserViewModel = (function () {
            function RequestUserViewModel(UserId, UserFullName, UserEmail) {
                this.UserId = UserId;
                this.UserFullName = UserFullName;
                this.UserEmail = UserEmail;
            }
            return RequestUserViewModel;
        }());
        domain.RequestUserViewModel = RequestUserViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestUserListViewModel.js.map