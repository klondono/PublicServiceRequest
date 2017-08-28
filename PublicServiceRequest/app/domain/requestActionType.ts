module app.domain {

    export interface IRequestActionType {
        RequestActionTypeID: number;
        RequestActionTypeName: string;
        RequestActionTypeDescription: string;
        BackgroundColor: string;
        TextColor: string;
        ChangeRequestStatusFlag: boolean;
        ReassignRequestFlag: boolean;
        DisplayFlag: boolean;
        SystemReservedFlag: boolean;
        AllowReplicationFlag: boolean;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class RequestActionType implements IRequestActionType {
        constructor(public RequestActionTypeID: number,
            public RequestActionTypeName: string,
            public RequestActionTypeDescription: string,
            public BackgroundColor: string,
            public TextColor: string,
            public ChangeRequestStatusFlag: boolean,
            public ReassignRequestFlag: boolean,
            public DisplayFlag: boolean,
            public SystemReservedFlag: boolean,
            public AllowReplicationFlag: boolean,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}