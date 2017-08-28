module app.domain {

    export interface ICustomFieldViewModel {
        ServiceTypeCustomFieldTransactionID: number;
        CustomFieldLabel: string;
        CustomFieldValue: string;
    }

    export class CustomFieldViewModel implements ICustomFieldViewModel {
        constructor(public ServiceTypeCustomFieldTransactionID: number,
            public CustomFieldLabel: string,
            public CustomFieldValue: string) { }
    }
}