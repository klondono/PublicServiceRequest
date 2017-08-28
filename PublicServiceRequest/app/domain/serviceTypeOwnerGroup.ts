module app.domain {

    export interface IServiceTypeOwnerGroup {
        ServiceTypeOwnerGroupID: number;
        ServiceTypeOwnerGroupLocationID: number;
        ServiceTypeOwnerGroupName: string;
        ServiceTypeOwnerGroupDescription: string;
        ServiceTypeOwnerGroupPhoneNo: string;
        ServiceTypeOwnerGroupDistrictNo: number;
        ServiceTypeOwnerGroupNotificationEmail: string;
        ServiceTypeOwnerGroupEscalationEmail: string;
        ServiceTypeOwnerGroupMainEmail: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class ServiceTypeOwnerGroup implements IServiceTypeOwnerGroup {
        constructor(public ServiceTypeOwnerGroupID: number,
            public ServiceTypeOwnerGroupLocationID: number,
            public ServiceTypeOwnerGroupName: string,
            public ServiceTypeOwnerGroupDescription: string,
            public ServiceTypeOwnerGroupPhoneNo: string,
            public ServiceTypeOwnerGroupDistrictNo: number,
            public ServiceTypeOwnerGroupNotificationEmail: string,
            public ServiceTypeOwnerGroupEscalationEmail: string,
            public ServiceTypeOwnerGroupMainEmail: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}