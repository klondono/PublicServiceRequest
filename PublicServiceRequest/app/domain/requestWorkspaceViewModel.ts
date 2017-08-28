module app.domain {

    export interface IRequestWorkspaceViewModel {
        RequestID: number;
        RequestParentRootID: number;
        RequestYear: number;
        RequestSuffix: number;
        RequestNumber: string;
        ServiceTypeID: number;
        ServiceTypeName: string;
        ApplicationSourceName: string;
        ServiceTypeOwnerName: string;
        FormattedRequestNumber: string;
        RequestStatus: string;
        RequestStatusColor: string;
        Origin: string;
        CreatedDate: string;
        CreatedBy: string;
        Priority: string;
        Resolution: string;
        NotifyOfProgress: boolean;
        DueDate: string;
        DueDatePassed: boolean;
        CompletionDate: string;
        CurrentWorkerIsGroupFlag: boolean;
        CloseWhenChildrenAreClosedFlag: boolean;
        ConcurrentCreationOfChildrenFlag: boolean;
        CurrentlyAssignedWorker: string;
        Comments: string;
        EffectiveDate: string;
        RequestUpdateNotificationEmail: string;
        CustomFields: app.domain.ICustomFieldViewModel[];
        TaxpayerID: number;
        FormattedTaxpayerName: string;
        TaxpayerFirstName: string;
        TaxpayerLastName: string;
        TaxpayerMiddleInitial: string;
        TaxpayerPhoneNo: string;
        TaxpayerEmail: string;
        TaxpayerPreferredLanguage: string;
        SortBy: string;
        BlnAsc: boolean;
        ViewConfidentialAttachmentFlag: boolean;
        ViewAttachmentFlag: boolean;
        AssociatedRequests: app.domain.IAssociatedRequestWorkspaceViewModel[];
        RequestActions: app.domain.IRequestActionWorkspaceViewModel[];
        RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[];
        RequestAvailableActions: app.domain.IRequestAvailableActionWorkspaceViewModel[];
        agendasCount: number;
    }

    export class RequestWorkspaceViewModel implements IRequestWorkspaceViewModel {
        constructor(public RequestID: number,
            public RequestParentRootID: number,
            public RequestYear: number,
            public RequestSuffix: number,
            public RequestNumber: string,
            public ServiceTypeID: number,
            public ServiceTypeName: string,
            public ApplicationSourceName: string,
            public ServiceTypeOwnerName: string,
            public FormattedRequestNumber: string,
            public RequestStatus: string,
            public RequestStatusColor: string,
            public Origin: string,
            public CreatedDate: string,
            public CreatedBy: string,
            public Priority: string,
            public Resolution: string,
            public NotifyOfProgress: boolean,
            public DueDate: string,
            public DueDatePassed: boolean,
            public CompletionDate: string,
            public CurrentWorkerIsGroupFlag: boolean,
            public CloseWhenChildrenAreClosedFlag: boolean,
            public ConcurrentCreationOfChildrenFlag: boolean,
            public CurrentlyAssignedWorker: string,
            public Comments: string,
            public EffectiveDate: string,
            public RequestUpdateNotificationEmail: string,
            public CustomFields: app.domain.ICustomFieldViewModel[],
            public TaxpayerID: number,
            public FormattedTaxpayerName: string,
            public TaxpayerFirstName: string,
            public TaxpayerLastName: string,
            public TaxpayerMiddleInitial: string,
            public TaxpayerPhoneNo: string,
            public TaxpayerEmail: string,
            public TaxpayerPreferredLanguage: string,
            public SortBy: string,
            public BlnAsc: boolean,
            public ViewConfidentialAttachmentFlag: boolean,
            public ViewAttachmentFlag: boolean,
            public AssociatedRequests: app.domain.IAssociatedRequestWorkspaceViewModel[],
            public RequestActions: app.domain.IRequestActionWorkspaceViewModel[],
            public RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[],
            public RequestAvailableActions: app.domain.IRequestAvailableActionWorkspaceViewModel[],
            public agendasCount: number
) { }
    }
}