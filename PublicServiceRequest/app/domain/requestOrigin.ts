module app.domain {

    export interface IRequestOrigin {
        RequestOriginID: number;
        RequestOriginName: string;
        RequestOriginDescription: string;
        AutoSelectedForActiveDirectoryGroup: string;
        DisableProgressNotificationForAutoSelectedGroupFlag: boolean;
        ForceAutoSelectedOriginFlag: boolean;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class RequestOrigin implements IRequestOrigin {
        constructor(public RequestOriginID: number,
            public RequestOriginName: string,
            public RequestOriginDescription: string,
            public AutoSelectedForActiveDirectoryGroup: string,
            public DisableProgressNotificationForAutoSelectedGroupFlag: boolean,
            public ForceAutoSelectedOriginFlag: boolean,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}