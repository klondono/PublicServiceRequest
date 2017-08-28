module app.domain {
    export interface IVMServiceType {
        ServiceTypeID: number;
        ServiceTypeOwnerGroupID: number;
        DefaultRequestStatusID: number;
        EscalationExpectedStatusID: number;
        ServiceTypeNumber: number;
        ServiceTypeName: string;
        ServiceTypeDescription: string;
        ServiceTypeDefaultDuration: number;
        ServiceTypeNotificationEmail: string;
        ServiceTypeEscalationEmail: string;
        ServiceTypeAssigneeDependantOnPropertyFlag: boolean;
        ServiceTypeIncludePropertyInfoFlag: boolean;
        ServiceTypeIncludeFirstActionCommentFlag: boolean;
        ServiceTypeShowAsStandaloneServiceFlag: boolean;
        ServiceTypeParentClosesWhenChildrenClosedFlag: boolean;
        ServiceTypeChildRequiredFlag: boolean;
        ServiceTypeChildCheckedByDefaultFlag: boolean;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
        ServiceTypeCustomFields: IVMServiceTypeCustomField[];
        value: any;

    }
    export class VMServiceType implements IVMServiceType {
        constructor(public ServiceTypeID: number,
            public ServiceTypeOwnerGroupID: number,
            public DefaultRequestStatusID: number,
            public EscalationExpectedStatusID: number,
            public ServiceTypeNumber: number,
            public ServiceTypeName: string,
            public ServiceTypeDescription: string,
            public ServiceTypeDefaultDuration: number,
            public ServiceTypeNotificationEmail: string,
            public ServiceTypeEscalationEmail: string,
            public ServiceTypeAssigneeDependantOnPropertyFlag: boolean,
            public ServiceTypeIncludePropertyInfoFlag: boolean,
            public ServiceTypeIncludeFirstActionCommentFlag: boolean,
            public ServiceTypeShowAsStandaloneServiceFlag: boolean,
            public ServiceTypeParentClosesWhenChildrenClosedFlag: boolean,
            public ServiceTypeChildRequiredFlag: boolean,
            public ServiceTypeChildCheckedByDefaultFlag: boolean,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string,
            public ServiceTypeCustomFields: IVMServiceTypeCustomField[],
            public value: any
        ) { }

    }
}