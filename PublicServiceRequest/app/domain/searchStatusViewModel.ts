module app.domain {

    export interface ISearchStatusViewModel {
        StatusValue: number;
        StatusName: string;
    }

    export class SearchStatusViewModel implements ISearchStatusViewModel {
        constructor(public StatusValue: number,
            public StatusName: string) { }
    }
}