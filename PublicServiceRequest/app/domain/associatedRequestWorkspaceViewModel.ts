module app.domain {

    export interface IAssociatedRequestWorkspaceViewModel {
        RequestID: number;
        FormattedRequestNumber: string;
        ServiceTypeName: string;
        ServiceTypeOwnerName: string;
        RequestCurrentWorkerFullName: string;
        RequestStatus: string;
        RequestStatusColor: string;
        CreatedDate: string;
        DueDate: string;
        DueDatePassed: boolean;
        CompletionDate: string;
        AddAssocRequestFlag: boolean;
        CloseWhenChildrenAreClosedFlag: boolean;
    }

    export class AssociatedRequestWorkspaceViewModel implements IAssociatedRequestWorkspaceViewModel {
        constructor(public RequestID: number,
            public FormattedRequestNumber: string,
            public ServiceTypeName: string,
            public ServiceTypeOwnerName: string,
            public RequestCurrentWorkerFullName: string,
            public RequestStatus: string,
            public RequestStatusColor: string,
            public CreatedDate: string,
            public DueDate: string,
            public DueDatePassed: boolean,
            public CompletionDate: string,
            public AddAssocRequestFlag: boolean,
            public CloseWhenChildrenAreClosedFlag: boolean) { }
    }
}