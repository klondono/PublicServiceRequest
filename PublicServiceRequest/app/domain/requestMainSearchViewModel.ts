module app.domain {

    export interface IMainSearchViewModel {
        RequestNo: string;
        Folio: string;
        Requestor: string;
        CreatedFrom: string;
        CreatedTo: string;
        StatusList: app.domain.ISearchStatusViewModel[];
        AssigneeList: app.domain.ISearchAssigneeViewModel[];
        SelectedStatusID: number;
        SelectedAssignee: app.domain.ISearchAssigneeViewModel;
    }

    export class MainSearchViewModel implements IMainSearchViewModel {
        constructor(public RequestNo: string,
            public Folio: string,
            public Requestor: string,
            public CreatedFrom: string,
            public CreatedTo: string,
            public StatusList: app.domain.ISearchStatusViewModel[],
            public AssigneeList: app.domain.ISearchAssigneeViewModel[],
            public SelectedStatusID: number,
            public SelectedAssignee: app.domain.ISearchAssigneeViewModel) { }
    }
}