module app.domain {

    export interface IRefreshedRequestWorkspaceViewModel {
        RequestID: number;
        ServiceTypeID: number,
        ServiceTypeName: string,
        RequestStatus: string;
        RequestStatusColor: string;
        Resolution: string;
        CompletionDate: string;
        CurrentWorkerIsGroupFlag: boolean,
        CurrentlyAssignedWorker: string;
        SortBy: string;
        BlnAsc: boolean;
        RequestActions: app.domain.IRequestActionWorkspaceViewModel[];
        RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[];
        AssociatedRequests: app.domain.IAssociatedRequestWorkspaceViewModel[];
        RequestAvailableActions: app.domain.IRequestAvailableActionWorkspaceViewModel[];
    }

    export class RefreshedRequestWorkspaceViewModel implements IRefreshedRequestWorkspaceViewModel {
        constructor(public RequestID: number,
            public ServiceTypeID: number,
            public ServiceTypeName: string,
            public RequestStatus: string,
            public RequestStatusColor: string,
            public Resolution: string,
            public CompletionDate: string,
            public CurrentWorkerIsGroupFlag: boolean,
            public CurrentlyAssignedWorker: string,
            public SortBy: string,
            public BlnAsc: boolean,
            public RequestActions: app.domain.IRequestActionWorkspaceViewModel[],
            public RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[],
            public AssociatedRequests: app.domain.IAssociatedRequestWorkspaceViewModel[],
            public RequestAvailableActions: app.domain.IRequestAvailableActionWorkspaceViewModel[]) { }
    }
}