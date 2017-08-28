module app.domain {

    export interface IRequestAttachmentWorkspaceViewModel {
        RequestAttachmentID: number;
        RequestAttachmentClientID: string;
        RequestAttachmentName: string;
        AttachmentTypeName: string;
        RequestAttachmentComment: string;
        RequestAttachmentDate: string;
        AttachmentTypeID: number;
        SizeInKB: number;
        FileExtension: string;
        RequestAttachmentFriendlyName: string;
        AttachmentAddedBy: string;
        SubFolder: string;
        ConfidentialAttachmentFlag: boolean;

    }

    export class RequestAttachmentWorkspaceViewModel implements IRequestAttachmentWorkspaceViewModel {
        constructor(public RequestAttachmentID: number,
            public RequestAttachmentClientID: string,
            public RequestAttachmentName: string,
            public AttachmentTypeName: string,
            public RequestAttachmentComment: string,
            public RequestAttachmentDate: string,
            public AttachmentTypeID: number,
            public SizeInKB: number,
            public FileExtension: string,
            public RequestAttachmentFriendlyName: string,
            public AttachmentAddedBy: string,
            public SubFolder: string,
            public ConfidentialAttachmentFlag: boolean) { }
    }
}