module app.domain {

    export interface IRequestCustomFieldViewModel {
        RequestActionID: number;
        ServiceTypeID: number;
        CustomFieldID: number;
        CustomFieldTypeID: number;
        ErrorMessage: string;
        RegularExpression: string;
        LabelName: string;
        DisplayData: string;
        FieldValue: string;
        PlaceholderText: string;
        TextAlignment: string;
        InputSequence: number;
        RequiredFlag: boolean;
        TooltipMessage: string;
        SelectListItems: app.domain.IRequestCustomFieldSelectListViewModel[];
        SelectListDisplayData: app.domain.IRequestCustomFieldSelectListViewModel;
        ServiceTypeChildCheckedByDefaultFlag?: boolean;
        DisplayFieldValueInCommentsFlag?: boolean;

    }

    export class RequestCustomFieldViewModel implements IRequestCustomFieldViewModel {
        constructor(public RequestActionID: number,
            public ServiceTypeID: number,
            public CustomFieldID: number,
            public CustomFieldTypeID: number,
            public ErrorMessage: string,
            public RegularExpression: string,
            public LabelName: string,
            public DisplayData: string,
            public FieldValue: string,
            public PlaceholderText: string,
            public TextAlignment: string,
            public InputSequence: number,
            public RequiredFlag: boolean,
            public TooltipMessage: string,
            public SelectListItems: app.domain.IRequestCustomFieldSelectListViewModel[],
            public SelectListDisplayData: app.domain.IRequestCustomFieldSelectListViewModel,
            public ServiceTypeChildCheckedByDefaultFlag?: boolean,
            public DisplayFieldValueInCommentsFlag?: boolean) { }
    }
}