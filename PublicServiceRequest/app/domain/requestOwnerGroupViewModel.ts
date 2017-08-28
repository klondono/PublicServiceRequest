module app.domain {

    export interface IRequestOwnerGroupViewModel {
        OwnerGroupID: number;
        OwnerGroupName: string;
        Email: string;
    }

    export class RequestOwnerGroupViewModel implements IRequestOwnerGroupViewModel {
        constructor(public OwnerGroupID: number,
            public OwnerGroupName: string,
            public Email: string) { }
    }
}