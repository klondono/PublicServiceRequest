module app.domain {
    export interface ICustomFieldSelectListItem {
        CustomFieldSelectListItemID: number;
        CustomFieldTypeID: number;
        CustomFieldSelectListItemLabel: string;
        CustomFieldSelectListItemValue: string;
        ListSequence: number;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }
    export class CustomFieldSelectListItem implements ICustomFieldSelectListItem {
        constructor(public CustomFieldSelectListItemID: number,
            public CustomFieldTypeID: number,
            public CustomFieldSelectListItemLabel: string,
            public CustomFieldSelectListItemValue: string,
            public ListSequence: number,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}