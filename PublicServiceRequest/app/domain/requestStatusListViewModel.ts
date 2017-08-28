module app.domain {

    export interface IRequestStatusViewModel {
            StatusValue: number;
            StatusName: string;
            StatusOpensRequest: boolean;
            StatusClosesRequest: boolean
    }

    export class RequestStatusListViewModel implements IRequestStatusViewModel {
        constructor(public StatusValue: number,
            public StatusName: string,
            public StatusOpensRequest: boolean,
            public StatusClosesRequest: boolean) { }
    }
}