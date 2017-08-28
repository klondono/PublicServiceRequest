module app.domain {

    export interface IRequestUserViewModel {
        UserId: number;
        UserFullName: string;
        UserEmail: string;
    }

    export class RequestUserViewModel implements IRequestUserViewModel {
        constructor(public UserId: number,
            public UserFullName: string,
            public UserEmail: string) { }
    }
}