module app.domain {

    export interface IRequestFolioType {
        RequestFolioTypeID: number;
        RequestFolioTypeName: string;
        RequestFoliotypeDescription: string;
        AdmIsActive: string;
        AdmUserAddedFullName: string;
        AdmUserAdded: number;
        AdmDateAdded: string;
        AdmUserModifiedFullName: string;
        AdmUserModified: number;
        AdmDateModified: string;
    }

    export class RequestFolioType implements IRequestFolioType {
        constructor(public RequestFolioTypeID: number,
            public RequestFolioTypeName: string,
            public RequestFoliotypeDescription: string,
            public AdmIsActive: string,
            public AdmUserAddedFullName: string,
            public AdmUserAdded: number,
            public AdmDateAdded: string,
            public AdmUserModifiedFullName: string,
            public AdmUserModified: number,
            public AdmDateModified: string) { }
    }
}