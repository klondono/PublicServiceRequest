module app.domain {

    export interface IRequestFolio {
        RequestFolioID: number;
        RequestFolioTypeID: number;
        RequestID: number;
        Folio: string;
        FormattedFolio: string;
        Cancelled: string;
        Confidential: string;
        HasOpenPSR: boolean;
        Year: string;
        HistoryRunID: number;
        District: number;
        DORCode: string;
        Owner: string;
        SiteAddress: string;
        SiteCity: string;
        ZipCode: string;
        MailingAddress: string,
        MailingCity: string,
        MailingZipCode: string,
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
        RequestFolioTypeName?: string;
    }

    export class RequestFolio implements IRequestFolio {
        constructor(public RequestFolioID: number,
            public RequestFolioTypeID: number,
            public RequestID: number,
            public Folio: string,
            public FormattedFolio: string,
            public Cancelled: string,
            public Confidential: string,
            public HasOpenPSR: boolean,
            public Year: string,
            public HistoryRunID: number,
            public District: number,
            public DORCode: string,
            public Owner: string,
            public SiteAddress: string,
            public SiteCity: string,
            public ZipCode: string,
            public MailingAddress: string,
            public MailingCity: string,
            public MailingZipCode: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string,
            public RequestFolioTypeName?: string) { }
    }
}
