module app.domain {
    export interface IAssociatedServiceTypeContainerViewModel {
        AssociatedServiceTypes: app.domain.IAssociatedServiceTypeViewModel[];
        CustomFields: app.domain.IRequestCustomFieldViewModel[];
    }

    export class AssociatedServiceTypeContainerViewModel implements IAssociatedServiceTypeContainerViewModel {
        constructor(public AssociatedServiceTypes: app.domain.IAssociatedServiceTypeViewModel[],
            public CustomFields: app.domain.IRequestCustomFieldViewModel[]) { }
    }
}