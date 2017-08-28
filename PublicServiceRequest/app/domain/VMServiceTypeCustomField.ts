module app.domain {
    export interface IVMServiceTypeCustomField {
        ServiceTypeCustomFieldID: number;
        ServiceTypeID: number;
        CustomFieldTypeID: number;
        CustomFieldDataTypeID: number;
        LabelName: string;
        PlaceholderText: string;
        TextAlignment: string;
        Description: string;
        InputSequence: number;
        RequiredFlag: string;
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
        DisplayData: string;
    }
    export class VMServiceTypeCustomField implements IVMServiceTypeCustomField {
        constructor(public ServiceTypeCustomFieldID: number,
            public ServiceTypeID: number,
            public CustomFieldTypeID: number,
            public CustomFieldDataTypeID: number,
            public LabelName: string,
            public PlaceholderText: string,
            public TextAlignment: string,
            public Description: string,
            public InputSequence: number,
            public RequiredFlag: string,
            public TooltipMessage: string,
            public GroupingIdentifier1: string,
            public GroupingIdentifier2: string,
            public AdmIsActive: string,
            public AdmUserAdded: number,
            public AdmUserAddedFullName: string,
            public AdmDateAdded: string,
            public AdmUserModified: number,
            public AdmUserModifiedFullName: string,
            public AdmDateModified: string,
            public DisplayData: string) { }
    }
}