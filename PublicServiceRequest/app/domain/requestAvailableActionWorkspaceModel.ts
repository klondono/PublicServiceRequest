module app.domain {

    export interface IRequestAvailableActionWorkspaceViewModel {
        RequestActionTypeID: number;
        RequestActionTypeName: string;
        RequestActionTypeDescription: string;
        BackgroundColor: string;
        RequestWorkspaceDisplayCode: number;
        TextColor: string;
    }

    export class RequestAvailableActionWorkspaceViewModel implements IRequestAvailableActionWorkspaceViewModel {
        constructor(public RequestActionTypeID: number,
            public RequestActionTypeName: string,
            public RequestActionTypeDescription: string,
            public BackgroundColor: string,
            public RequestWorkspaceDisplayCode: number,
            public TextColor: string) { }
    }
}