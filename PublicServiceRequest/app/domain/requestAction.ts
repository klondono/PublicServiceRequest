module app.domain {

    export interface IRequestAction {
        RequestActionID: number;
        RequestActionTypeID: number;
        RequestID: number;
        RequestStatusChangedID: number;
        RequestAssignedUserID: number;
        Comments: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class RequestAction implements IRequestAction {
        constructor(public RequestActionID: number,
            public RequestActionTypeID: number,
            public RequestID: number,
            public RequestStatusChangedID: number,
            public RequestAssignedUserID: number,
            public Comments: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}