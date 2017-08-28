module app.domain {
    export interface IAssociatedServiceTypeViewModel {
        ServiceTypeID: number;
        ServiceTypeName: string;
        ServiceTypeParentID: number;
        ServiceTypeParentName: string;
        ServiceTypeDescription: string;
        ServiceTypeOwnerGroupID: number;
        ServiceTypeOwnerGroupName: string;
        DefaultRequestStatusID: number;
        StatusClosesRequestFlag: boolean;
        EscalationExpectedStatusID: number;
        ServiceTypeOwnerGroupNotificationEmail: string;
        ServiceTypeOwnerGroupEscalationEmail: string;
        ServiceTypeAssigneeDependantOnPropertyFlag: boolean;
        District: number;
        ServiceTypeIncludePropertyInfoFlag: boolean;
        ServiceTypeIncludeFirstActionCommentFlag: boolean;
        ServiceTypeShowAsStandaloneServiceFlag: boolean;
        ServiceTypeParentClosesWhenChildrenClosedFlag: boolean;
        ServiceTypeChildRequiredFlag: boolean;
        ServiceTypeChildCheckedByDefaultFlag: boolean;
        ServiceTypeChildStartDelay: number;
        ServiceTypeChildDuration: number;
        ServiceTypeChildStartTriggerID: number;
        ServiceTypeConcurrentCreationOfChildrenFlag: boolean;
        EffectiveDate: string;
        DueDate: string;
        ServiceTypeAssigneeDependantOnOriginFlag: boolean;
        ServiceTypeDependantOriginID: number;
        ServiceTypeOwnerGroupOverrideOriginBased : string;
        DefaultRequestFolioTypeID: number;
        ForceRequestFolioType: boolean;
        TreeLevel: number;
    }
    export class AssociatedServiceTypeViewModel implements IAssociatedServiceTypeViewModel {
        constructor(public ServiceTypeID: number,
            public ServiceTypeName: string,
            public ServiceTypeParentID: number,
            public ServiceTypeParentName: string,
            public ServiceTypeDescription: string,
            public ServiceTypeOwnerGroupID: number,
            public ServiceTypeOwnerGroupName: string,
            public DefaultRequestStatusID: number,
            public StatusClosesRequestFlag: boolean,
            public EscalationExpectedStatusID: number,
            public ServiceTypeOwnerGroupNotificationEmail: string,
            public ServiceTypeOwnerGroupEscalationEmail: string,
            public ServiceTypeAssigneeDependantOnPropertyFlag: boolean,
            public District: number,
            public ServiceTypeIncludePropertyInfoFlag: boolean,
            public ServiceTypeIncludeFirstActionCommentFlag: boolean,
            public ServiceTypeShowAsStandaloneServiceFlag: boolean,
            public ServiceTypeParentClosesWhenChildrenClosedFlag: boolean,
            public ServiceTypeChildRequiredFlag: boolean,
            public ServiceTypeChildCheckedByDefaultFlag: boolean,
            public ServiceTypeChildStartDelay: number,
            public ServiceTypeChildDuration: number,
            public ServiceTypeChildStartTriggerID: number,
            public ServiceTypeConcurrentCreationOfChildrenFlag: boolean,
            public EffectiveDate: string,
            public DueDate: string,
            public ServiceTypeAssigneeDependantOnOriginFlag: boolean,
            public ServiceTypeDependantOriginID: number,
            public ServiceTypeOwnerGroupOverrideOriginBased: string,
            public DefaultRequestFolioTypeID: number,
            public ForceRequestFolioType: boolean,
            public TreeLevel: number) { }
    }


}