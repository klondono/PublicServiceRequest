module app.domain {

    export interface ISortedRequestActionsContainerViewModel {
        RequestActions: app.domain.IRequestActionWorkspaceViewModel[];
    }

    export class SortedRequestActionContainerViewModel implements ISortedRequestActionsContainerViewModel {
        constructor(public RequestActions: app.domain.IRequestActionWorkspaceViewModel[]) { }
    }
}