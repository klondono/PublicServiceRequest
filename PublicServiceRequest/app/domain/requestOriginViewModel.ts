module app.domain {

    export interface IRequestOriginViewModel {
        RequestOriginID: number;
        RequestOriginName: string;
        RequestOriginDescription: string;
        AutoSelectedForActiveDirectoryGroup: string;
        DisableProgressNotificationForAutoSelectedGroupFlag: boolean;
        ForceAutoSelectedOriginFlag: boolean;
        AdmIsActive: string;
    }

    export class RequestOriginViewModel implements IRequestOriginViewModel {
        constructor(public RequestOriginID: number,
            public RequestOriginName: string,
            public RequestOriginDescription: string,
            public AutoSelectedForActiveDirectoryGroup: string,
            public DisableProgressNotificationForAutoSelectedGroupFlag: boolean,
            public ForceAutoSelectedOriginFlag: boolean,
            public AdmIsActive: string) { }
    }
}