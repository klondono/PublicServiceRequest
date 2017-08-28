module app.domain {

    export interface ISearchAssigneeViewModel {
        AssigneeID: number;
        AssigneeName: string;
        AssigneeType: string;
        AssigneeUniqueID: string;
    }

    export class SearchAssigneeViewModel implements ISearchAssigneeViewModel {
        constructor(public AssigneeID: number,
            public AssigneeName: string,
            public AssigneeType: string,
            public AssigneeUniqueID: string) { }
    }
}