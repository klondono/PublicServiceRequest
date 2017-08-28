var app;
(function (app) {
    var common;
    (function (common) {
        var services = angular.module('common.services', ['ngResource'])
            .constant('appSettings', {
            serverPath: '/PSR/',
            psrInterviewPath: '/PSR_Interview/?RequestId=',
            psrConfirmationReportPath: 'http://prodsp1panet.miamidade.gov/ReportServer/Pages/ReportViewer.aspx?/PA-Reports/PA-PublicService/Reports/PSRConfirmation&rs:Command=Render&RootRequestID=',
            realPropertySearchPath: 'http://www.miamidade.gov/propertysearch/#/?folio=',
            tppSearchPath: 'http://www.miamidade.gov/pa/business_lookup.asp#/business/',
            pictometryPath: 'http://arcgis.miamidade.gov/GISImages/PictometryOnline.aspx?folio=',
            taxCollectorPath: 'https://www.miamidade.county-taxes.com/public/real_estate/parcels/',
            taxComparisonPath: 'http://www.miamidade.gov/PAPortal/Taxes/TaxComparison.aspx?Folio=',
            comparableSalesPath: 'http://www.miamidade.gov/ComparableSales/#/?folio=',
            photosPath: 'http://prodweb1panet.miamidade.gov/PANET/Public/PictureAdmin.aspx?Folio=',
            trimNoticePath: 'http://www.miamidade.gov/paportal/trimpdf/MakeTrim.aspx?FolSrch=',
            fieldCheckReportPath: 'http://prodweb1panet.miamidade.gov/PANET/FieldChecks/FieldRepMainMenu.aspx?fol=',
            propertyReportCardPath: 'http://prodweb1panet.miamidade.gov/PANET/PTXA/PTXAreportMain.aspx?Fol=',
            googleMapPath: 'http://maps.google.com/?q=',
            addressChangeAppPath: 'http://prodweb1panet.miamidade.gov/PANET/AddressChanges/address_request_form_main_menu.asp?Fol=',
            dpaLetterAppPath: 'http://prodweb1panet.miamidade.gov/PANET/DeedLetter/deed_request_form_main_menu.asp?Fol='
        });
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=common.services.js.map