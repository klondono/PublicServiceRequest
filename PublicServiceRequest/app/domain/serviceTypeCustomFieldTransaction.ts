module app.domain {
    export interface IServiceTypeCustomFieldTransaction {
        ServiceTypeCustomFieldTransactionID: number;
        RequestID: number;
        ServiceTypeCustomFieldID: number;
        DisplayData: string;
        Value: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }

    export class ServiceTypeCustomFieldTransaction implements IServiceTypeCustomFieldTransaction {
        constructor(public ServiceTypeCustomFieldTransactionID: number,
            public RequestID: number,
            public ServiceTypeCustomFieldID: number,
            public DisplayData: string,
            public Value: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}

