module app.domain {

    export interface IRequestTaxpayerPreferredLanguage {
        RequestTaxpayerPreferredLanguageID: number;
        RequestTaxpayerPreferredLanguageName: string;
        RequestTaxpayerPreferredLanguageDescription: string;
        AdmIsActive: string;
        AdmUserAddedFullName: string;
        AdmUserAdded: number;
        AdmDateAdded: string;
        AdmUserModifiedFullName: string;
        AdmUserModified: number;
        AdmDateModified: string;
    }

    export class RequestTaxpayerPreferredLanguage implements IRequestTaxpayerPreferredLanguage {
        constructor(public RequestTaxpayerPreferredLanguageID: number,
            public RequestTaxpayerPreferredLanguageName: string,
            public RequestTaxpayerPreferredLanguageDescription: string,
            public AdmIsActive: string,
            public AdmUserAddedFullName: string,
            public AdmUserAdded: number,
            public AdmDateAdded: string,
            public AdmUserModifiedFullName: string,
            public AdmUserModified: number,
            public AdmDateModified: string) { }
    }
}