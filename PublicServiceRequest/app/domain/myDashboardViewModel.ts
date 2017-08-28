module app.domain {

    export interface IMyDashboardViewModel {
        StatOne: number;
        StatTwo: number;
        StatThree: number;
        StatFour: number;
    }
    export class MyDashboardViewModel implements IMyDashboardViewModel {
        constructor(public StatOne: number,
        public StatTwo: number,
        public StatThree: number,
        public StatFour: number) { }
    }
}