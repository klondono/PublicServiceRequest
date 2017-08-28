module app.domain {

    export interface IRequestPriority {
        RequestPriorityID: number;
        RequestPriorityName: string;
        RequestPriorityDescription: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class RequestPriority implements IRequestPriority {
        constructor(public RequestPriorityID: number,
            public RequestPriorityName: string,
            public RequestPriorityDescription: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}