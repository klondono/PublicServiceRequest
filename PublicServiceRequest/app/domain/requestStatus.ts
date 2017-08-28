module app.domain {

    export interface IRequestStatus {
        RequestStatusID: number;
        RequestStatusName: string;
        RequestStatusDescription: string;
        RequestStatusColor: string;
        StatusReopensRequestFlag: boolean;
        StatusClosesRequestFlag: boolean;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class RequestStatus implements IRequestStatus {
        constructor(public RequestStatusID: number,
            public RequestStatusName: string,
            public RequestStatusDescription: string,
            public RequestStatusColor: string,
            public StatusReopensRequestFlag: boolean,
            public StatusClosesRequestFlag: boolean,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}