module app.domain {
    export interface ICustomFieldType {
        CustomFieldTypeID: number;
        CustomFieldTypeName: string;
        CustomFieldTypeDescription: string;
        AllowEditFlag: boolean;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }
    export class CustomFieldType implements ICustomFieldType {
        constructor(public CustomFieldTypeID: number,
            public CustomFieldTypeName: string,
            public CustomFieldTypeDescription: string,
            public AllowEditFlag: boolean,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}