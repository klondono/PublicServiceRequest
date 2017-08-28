var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestAttachmentWorkspaceViewModel = (function () {
            function RequestAttachmentWorkspaceViewModel(RequestAttachmentID, RequestAttachmentClientID, RequestAttachmentName, AttachmentTypeName, RequestAttachmentComment, RequestAttachmentDate, AttachmentTypeID, SizeInKB, FileExtension, RequestAttachmentFriendlyName, AttachmentAddedBy, SubFolder, ConfidentialAttachmentFlag) {
                this.RequestAttachmentID = RequestAttachmentID;
                this.RequestAttachmentClientID = RequestAttachmentClientID;
                this.RequestAttachmentName = RequestAttachmentName;
                this.AttachmentTypeName = AttachmentTypeName;
                this.RequestAttachmentComment = RequestAttachmentComment;
                this.RequestAttachmentDate = RequestAttachmentDate;
                this.AttachmentTypeID = AttachmentTypeID;
                this.SizeInKB = SizeInKB;
                this.FileExtension = FileExtension;
                this.RequestAttachmentFriendlyName = RequestAttachmentFriendlyName;
                this.AttachmentAddedBy = AttachmentAddedBy;
                this.SubFolder = SubFolder;
                this.ConfidentialAttachmentFlag = ConfidentialAttachmentFlag;
            }
            return RequestAttachmentWorkspaceViewModel;
        }());
        domain.RequestAttachmentWorkspaceViewModel = RequestAttachmentWorkspaceViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestAttachmentWorkspaceViewModel.js.map