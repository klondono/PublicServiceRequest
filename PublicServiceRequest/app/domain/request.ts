module app.domain {

    export interface IRequest {
        RequestID: number;
        ServiceTypeID: number;
        RequestTypeID: number;
        RequestOriginID: number;
        RequestPriorityID: number;
        RequestStatusID: number;
        RequestResolutionID: number;
        RequestTaxpayerID: number;
        RequestCurrentWorkerID: number;
        RequestCurrentWorkerFullName: string;
        RequestYear: string;
        RequestNumber: string;
        RequestSuffix: string;
        FormattedRequestNumber: string;
        RequestDueDate: string;
        RequestComments: string;
        RequestEffectiveDate: string;
        RequestCompletionDate: string;
        RequestUpdateNotificationFlag: boolean;
        RequestUpdateNotificationEmail: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
        OutputDirectory: string;
        ConfidentialOutputDirectory: string;
        FolioList: app.domain.IRequestFolio[];
        DisableProgressNotification: boolean;
        RestrictToAutoSelection: boolean;
        AttachmentTemporaryID: string;
        RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[];
        RequestTaxpayerInfo: app.domain.IRequestTaxpayer;
        TaxYearList?: string[];
        SelectedYear?: string; 
        RequestOrigins?: app.domain.IRequestOriginViewModel[];
        RequestCommentsInternal?: string;       
    }

    export class Request implements IRequest {
        constructor(public RequestID: number,
            public ServiceTypeID: number,
            public RequestTypeID: number,
            public RequestOriginID: number,
            public RequestPriorityID: number,
            public RequestStatusID: number,
            public RequestResolutionID: number,
            public RequestTaxpayerID: number,
            public RequestCurrentWorkerID: number,
            public RequestCurrentWorkerFullName: string,
            public RequestYear: string,
            public RequestNumber: string,
            public RequestSuffix: string,
            public FormattedRequestNumber: string,
            public RequestDueDate: string,
            public RequestComments: string,
            public RequestEffectiveDate: string,
            public RequestCompletionDate: string,
            public RequestUpdateNotificationFlag: boolean,
            public RequestUpdateNotificationEmail: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string,
            public OutputDirectory: string,
            public ConfidentialOutputDirectory: string,
            public FolioList: app.domain.IRequestFolio[],
            public AttachmentTemporaryID: string,
            public DisableProgressNotification: boolean,
            public RestrictToAutoSelection: boolean,
            public RequestAttachments: app.domain.IRequestAttachmentWorkspaceViewModel[],
            public RequestTaxpayerInfo: app.domain.IRequestTaxpayer,
            public TaxYearList?: string[],
            public SelectedYear?: string,
            public RequestOrigins?: app.domain.IRequestOriginViewModel[],
            public RequestCommentsInternal?: string) { }
    }
}
