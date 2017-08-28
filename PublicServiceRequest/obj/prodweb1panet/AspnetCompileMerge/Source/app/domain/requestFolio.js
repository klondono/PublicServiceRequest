var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestFolio = (function () {
            function RequestFolio(RequestFolioID, RequestFolioTypeID, RequestID, Folio, FormattedFolio, Cancelled, Confidential, HasOpenPSR, Year, HistoryRunID, District, DORCode, Owner, SiteAddress, SiteCity, ZipCode, MailingAddress, MailingCity, MailingZipCode, AdmIsActive, AdmUserAdded, AdmUserAddedFullName, AdmDateAdded, AdmUserModified, AdmUserModifiedFullName, AdmDateModified, RequestFolioTypeName) {
                this.RequestFolioID = RequestFolioID;
                this.RequestFolioTypeID = RequestFolioTypeID;
                this.RequestID = RequestID;
                this.Folio = Folio;
                this.FormattedFolio = FormattedFolio;
                this.Cancelled = Cancelled;
                this.Confidential = Confidential;
                this.HasOpenPSR = HasOpenPSR;
                this.Year = Year;
                this.HistoryRunID = HistoryRunID;
                this.District = District;
                this.DORCode = DORCode;
                this.Owner = Owner;
                this.SiteAddress = SiteAddress;
                this.SiteCity = SiteCity;
                this.ZipCode = ZipCode;
                this.MailingAddress = MailingAddress;
                this.MailingCity = MailingCity;
                this.MailingZipCode = MailingZipCode;
                this.AdmIsActive = AdmIsActive;
                this.AdmUserAdded = AdmUserAdded;
                this.AdmUserAddedFullName = AdmUserAddedFullName;
                this.AdmDateAdded = AdmDateAdded;
                this.AdmUserModified = AdmUserModified;
                this.AdmUserModifiedFullName = AdmUserModifiedFullName;
                this.AdmDateModified = AdmDateModified;
                this.RequestFolioTypeName = RequestFolioTypeName;
            }
            return RequestFolio;
        }());
        domain.RequestFolio = RequestFolio;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestFolio.js.map