module app.domain {
    export interface IServiceTypeCustomField {
        ServiceTypeCustomFieldID: number;
        ServiceTypeID: number;
        CustomFieldTypeID: number;
        CustomFieldDataTypeID: number;
        LabelName: string;
        PlaceholderText: string;
        TextAlignment: string;
        Description: string;
        InputSequence: number;
        RequiredFlag: boolean;
        TooltipMessage: string;
        GroupingIdentifier1: string;
        GroupingIdentifier2: string;
        AdmIsActive: string;
        AdmUserAdded: number;
        AdmUserAddedFullName: string;
        AdmDateAdded: string;
        AdmUserModified: number;
        AdmUserModifiedFullName: string;
        AdmDateModified: string;
    }
    export class ServiceTypeCustomField implements IServiceTypeCustomField {
        constructor(public ServiceTypeCustomFieldID: number,
            public ServiceTypeID: number,
            public CustomFieldTypeID: number,
            public CustomFieldDataTypeID: number,
            public LabelName: string,
            public PlaceholderText: string,
            public TextAlignment: string,
            public Description: string,
            public InputSequence: number,
            public RequiredFlag: boolean,
            public TooltipMessage: string,
            public GroupingIdentifier1: string,
            public GroupingIdentifier2: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string) { }
    }
}