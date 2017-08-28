module app.domain {
    export interface IServiceType {
        ServiceTypeID: number;
        ServiceTypeOwnerGroupID: number;
        DefaultRequestStatusID: number;
        EscalationExpectedStatusID: number;
        ServiceTypeNumber: number;
        ServiceTypeName: string;
        ServiceTypeDescription: string;
        ServiceTypeDefaultDuration: number;
        ServiceTypeAssigneeDependantOnPropertyFlag: boolean;
        ServiceTypeIncludePropertyInfoFlag: boolean;
        ServiceTypeIncludeFirstActionCommentFlag: boolean;
        ServiceTypeShowAsStandaloneServiceFlag: boolean;
        ServiceTypeParentClosesWhenChildrenClosedFlag: boolean;
        ServiceTypeConcurrentCreationOfChildrenFlag: boolean;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;

        //Method(percent: number): number;
    }
    export class ServiceType implements IServiceType {
        constructor(public ServiceTypeID: number,
            public ServiceTypeOwnerGroupID: number,
            public DefaultRequestStatusID: number,
            public EscalationExpectedStatusID: number,
            public ServiceTypeNumber: number,
            public ServiceTypeName: string,
            public ServiceTypeDescription: string,
            public ServiceTypeDefaultDuration: number,
            public ServiceTypeAssigneeDependantOnPropertyFlag: boolean,
            public ServiceTypeIncludePropertyInfoFlag: boolean,
            public ServiceTypeIncludeFirstActionCommentFlag: boolean,
            public ServiceTypeShowAsStandaloneServiceFlag: boolean,
            public ServiceTypeParentClosesWhenChildrenClosedFlag: boolean,
            public ServiceTypeConcurrentCreationOfChildrenFlag: boolean,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }

        //Method(percent: number): number {

        //    return 1;
        //};
    }
}