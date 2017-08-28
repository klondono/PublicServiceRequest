module app.domain {

    export interface IRequestActionWorkspaceViewModel {
        RequestActionID: number;
        ActionTypeName: string;
        ActionStatusChangedName: string;
        ActionStatusChangedColor: string;
        ActionAssignedUserFullName: string;
        ActionComments: string;
        ActionAddedBy: string;
        ActionAddedDate: string;
        ActionModifiedBy: string;
        ActionModifiedDate: string;
        BackgroundColor: string;
        TextColor: string;
        DisplayFlag: boolean;
    }

    export class RequestActionWorkspaceViewModel implements IRequestActionWorkspaceViewModel {
        constructor(public RequestActionID: number,
            public ActionTypeName: string,
            public ActionStatusChangedName: string,
            public ActionStatusChangedColor: string,
            public ActionAssignedUserFullName: string,
            public ActionComments: string,
            public ActionAddedBy: string,
            public ActionAddedDate: string,
            public ActionModifiedBy: string,
            public ActionModifiedDate: string,
            public BackgroundColor: string,
            public TextColor: string,
            public DisplayFlag: boolean) { }
    }
}