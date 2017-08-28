module app.domain {
    export interface IServiceTypeViewModel {
        ServiceTypeID: number;
        ServiceTypeName: string;
        ServiceTypeCompositeName: string;
        ServiceTypeOwnerGroupName: string; 
    }
    export class ServiceTypeViewModel implements IServiceTypeViewModel {
        constructor(public ServiceTypeID: number,
            public ServiceTypeName: string,
            public ServiceTypeCompositeName: string,
            public ServiceTypeOwnerGroupName: string) { }
    }
}