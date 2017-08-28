module app.domain {

    export interface IRequestCustomFieldSelectListViewModel {
        SelectListLabel: string;
        SelectListValue: string;
    }

    export class RequestCustomFieldSelectListViewModel implements IRequestCustomFieldSelectListViewModel {
        constructor(public SelectListLabel: string,
            public SelectListValue: string) { }
    }
}