module app.domain {

    export interface IServiceTypeResolution {
        ServiceTypeResolutionID: number;
        ServiceTypeResolutionName: string;
        ServiceTypeResolutionDescription: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class ServiceTypeResolution implements IServiceTypeResolution {
        constructor(public ServiceTypeResolutionID: number,
            public ServiceTypeResolutionName: string,
            public ServiceTypeResolutionDescription: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}