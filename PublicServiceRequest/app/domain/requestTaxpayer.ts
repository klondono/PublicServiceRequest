module app.domain {

    export interface IRequestTaxpayer {
        RequestTaxpayerID: number;
        RequestTaxpayerPreferredLanguageID: number;
        FirstName: string;
        MiddleInitial: string;
        LastName: string;
        FormattedTaxpayerName: string;
        PhoneNo: string;
        FormattedPhoneNo: string;
        PhoneNoType: string;
        AltPhoneNo1: string;
        AltPhoneNo1Type: string;
        AltPhoneNo2: string;
        AltPhoneNo2Type: string;
        Email: string;
        AltEmail: string,
        SystemReservedFlag: boolean,
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
        RemainAnonymousFlag: boolean;
    }

    export class RequestTaxpayer implements IRequestTaxpayer {
        constructor(public RequestTaxpayerID: number,
            public RequestTaxpayerPreferredLanguageID: number,
            public FirstName: string,
            public MiddleInitial: string,
            public LastName: string,
            public FormattedTaxpayerName: string,
            public PhoneNo: string,
            public FormattedPhoneNo: string,
            public PhoneNoType: string,
            public AltPhoneNo1: string,
            public AltPhoneNo1Type: string,
            public AltPhoneNo2: string,
            public AltPhoneNo2Type: string,
            public Email: string,
            public AltEmail: string,
            public SystemReservedFlag: boolean,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string,
            public RemainAnonymousFlag: boolean) { }
    }
}