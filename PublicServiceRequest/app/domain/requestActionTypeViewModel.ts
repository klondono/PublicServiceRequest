module app.domain {

    export interface IRequestActionTypeViewModel {
        RequestID: number;
        ServiceTypeID: number;
        ServiceTypeName: string;
        RequestParentRootID: number;
        FormattedRequestNumber: string;
        RequestUpdateNotificationFlag: boolean;
        RequestUpdateNotificationEmail: string;
        RequestActionTypeID: number;
        SelectedStatus: app.domain.IRequestStatusViewModel;
        AssignUserFlag: boolean;
        RequestActionTypeName: string;
        BackgroundColor: string;
        TextColor: string;
        Comments: string;
        ChangeRequestStatus: boolean;
        ReassignRequest: boolean;
        UploadDocument: boolean;
        AllowReplication: boolean;
        UpdateServiceType: boolean;
        UpdateRequestFolio: boolean;
        ConcurrentCreationOfChildrenFlag: boolean;
        SelectedUser: app.domain.IRequestUserViewModel;
        SelectedOwnerGroup: app.domain.IRequestOwnerGroupViewModel;
        SelectedServiceType: app.domain.IServiceTypeViewModel;
        RequestActionCustomFields: app.domain.IRequestCustomFieldViewModel[];
        RequestActionUsers: app.domain.IRequestUserViewModel[];
        RequestActionStatuses: app.domain.IRequestStatusViewModel[];
        RequestActionOwnerGroups: app.domain.IRequestOwnerGroupViewModel[];
        RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[];
        AssociatedRequests: app.domain.IAssociatedRequestWorkspaceViewModel[];
        ServiceTypes: app.domain.IServiceTypeViewModel[];
        OutputDirectory: string;
        ConfidentialOutputDirectory: string;
        AttachmentTemporaryID: string;
        AddActionActiveDirectoryGroupName: string;
        AddActionPermission: boolean;
        UpdateActionActiveDirectoryGroupName: string;
        UpdateActionPermission: boolean;
        DeleteActionActiveDirectoryGroupName: string;
        DeleteActionPermission: boolean;
        MaximumAllowedOcurrence: number;
        ExceededMaximumAllowedOcurrence: boolean;
        CloseWhenChildrenAreClosedFlag: boolean;
        PrecedenceConstraintRequestActionTypeIDValue?: string;
        PrecedenceConstraintLogicalOperatorIsORFlag?: boolean;
        PrecedenceConstraintSatisfied?: boolean;
        PrecedenceConstraintErrorMsg?: string;
        ByPassClientSideValidation?: boolean;
    }

    export class RequestActionTypeViewModel implements IRequestActionTypeViewModel {
        constructor(public RequestID: number,
            public ServiceTypeID: number,
            public ServiceTypeName: string,
            public RequestParentRootID: number,
            public FormattedRequestNumber: string,
            public RequestUpdateNotificationFlag: boolean,
            public RequestUpdateNotificationEmail: string,
            public RequestActionTypeID: number,
            public SelectedStatus: app.domain.IRequestStatusViewModel,
            public AssignUserFlag: boolean,
            public RequestActionTypeName: string,
            public BackgroundColor: string,
            public TextColor: string,
            public Comments: string,
            public ChangeRequestStatus: boolean,
            public ReassignRequest: boolean,
            public UploadDocument: boolean,
            public AllowReplication: boolean,
            public UpdateServiceType: boolean,
            public UpdateRequestFolio: boolean,
            public ConcurrentCreationOfChildrenFlag: boolean,
            public SelectedUser: app.domain.IRequestUserViewModel,
            public SelectedOwnerGroup: app.domain.IRequestOwnerGroupViewModel,
            public SelectedServiceType: app.domain.IServiceTypeViewModel,
            public RequestActionCustomFields: app.domain.IRequestCustomFieldViewModel[],
            public RequestActionUsers: app.domain.IRequestUserViewModel[],
            public RequestActionStatuses: app.domain.IRequestStatusViewModel[],
            public RequestActionOwnerGroups: app.domain.IRequestOwnerGroupViewModel[],
            public RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[],
            public AssociatedRequests: app.domain.IAssociatedRequestWorkspaceViewModel[],
            public ServiceTypes: app.domain.IServiceTypeViewModel[],
            public OutputDirectory: string,
            public ConfidentialOutputDirectory: string,
            public AttachmentTemporaryID: string,
            public AddActionActiveDirectoryGroupName: string,
            public AddActionPermission: boolean,
            public UpdateActionActiveDirectoryGroupName: string,
            public UpdateActionPermission: boolean,
            public DeleteActionActiveDirectoryGroupName: string,
            public DeleteActionPermission: boolean,
            public MaximumAllowedOcurrence: number,
            public ExceededMaximumAllowedOcurrence: boolean,
            public CloseWhenChildrenAreClosedFlag: boolean,
            public PrecedenceConstraintRequestActionTypeIDValue?: string,
            public PrecedenceConstraintLogicalOperatorIsORFlag?: boolean,
            public PrecedenceConstraintSatisfied?: boolean,
            public PrecedenceConstraintErrorMsg?: string,
            public ByPassClientSideValidation?: boolean) { }
    }
}