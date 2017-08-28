module app.common {
    export interface IAppSettings {
        serverPath: string,
        psrInterviewPath: string,
        psrConfirmationReportPath: string,
        realPropertySearchPath: string,
        tppSearchPath: string,
        pictometryPath: string,
        taxCollectorPath: string,
        taxComparisonPath: string,
        comparableSalesPath: string,
        photosPath: string,
        trimNoticePath: string,
        fieldCheckReportPath: string,
        propertyReportCardPath: string,
        googleMapPath: string,
        addressChangeAppPath: string,
        dpaLetterAppPath: string
    }
    var services = angular.module('common.services', ['ngResource'])
        .constant('appSettings',
        {
            serverPath: '/PSR/',
            psrInterviewPath: '/PSR_Interview/?RequestId=',//Hard coded in serviceRequestWorkspaceView.html as part of kendo ui template, update in both places
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
}