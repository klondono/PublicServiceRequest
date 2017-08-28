module app.domain {
    export interface ICustomFieldDataType {
        CustomFieldDataTypeID: number;
        CustomFieldDataTypeName: string;
        CustomFieldDataTypeDescription: string;
        RegularExpression: string;
        ErrorMessage: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }
    export class CustomFieldDataType implements ICustomFieldDataType {
        constructor(public CustomFieldDataTypeID: number,
            public CustomFieldDataTypeName: string,
            public CustomFieldDataTypeDescription: string,
            public RegularExpression: string,
            public ErrorMessage: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}