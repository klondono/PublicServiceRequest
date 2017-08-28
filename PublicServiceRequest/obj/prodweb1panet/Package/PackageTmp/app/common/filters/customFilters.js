var app;
(function (app) {
    var common;
    (function (common) {
        function myLimitTo() {
            return function (obj, limit) {
                var keys = Object.keys(obj);
                if (keys.length < 1) {
                    return [];
                }
                var ret = new Object, count = 0;
                angular.forEach(keys, function (key, arrayIndex) {
                    if (count >= limit) {
                        return false;
                    }
                    ret[key] = obj[key];
                    count++;
                });
                return ret;
            };
        }
        common.myLimitTo = myLimitTo;
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
angular.module("common.services")
    .filter("myLimitTo", app.common.myLimitTo);
//# sourceMappingURL=customFilters.js.map