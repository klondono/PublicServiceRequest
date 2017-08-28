var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestTaxpayer = (function () {
            function RequestTaxpayer(RequestTaxpayerID, RequestTaxpayerPreferredLanguageID, FirstName, MiddleInitial, LastName, FormattedTaxpayerName, PhoneNo, FormattedPhoneNo, PhoneNoType, AltPhoneNo1, AltPhoneNo1Type, AltPhoneNo2, AltPhoneNo2Type, Email, AltEmail, SystemReservedFlag, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified, RemainAnonymousFlag) {
                this.RequestTaxpayerID = RequestTaxpayerID;
                this.RequestTaxpayerPreferredLanguageID = RequestTaxpayerPreferredLanguageID;
                this.FirstName = FirstName;
                this.MiddleInitial = MiddleInitial;
                this.LastName = LastName;
                this.FormattedTaxpayerName = FormattedTaxpayerName;
                this.PhoneNo = PhoneNo;
                this.FormattedPhoneNo = FormattedPhoneNo;
                this.PhoneNoType = PhoneNoType;
                this.AltPhoneNo1 = AltPhoneNo1;
                this.AltPhoneNo1Type = AltPhoneNo1Type;
                this.AltPhoneNo2 = AltPhoneNo2;
                this.AltPhoneNo2Type = AltPhoneNo2Type;
                this.Email = Email;
                this.AltEmail = AltEmail;
                this.SystemReservedFlag = SystemReservedFlag;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
                this.RemainAnonymousFlag = RemainAnonymousFlag;
            }
            return RequestTaxpayer;
        }());
        domain.RequestTaxpayer = RequestTaxpayer;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestTaxpayer.js.map