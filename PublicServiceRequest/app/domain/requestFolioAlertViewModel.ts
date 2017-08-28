module app.domain {

    export interface IServiceTypeFolioAlert {
        ServiceTypeName: string;
    }

    export interface IRequestStatusFolioAlert {
        RequestStatusName: string;
        RequestStatusColor: string;
    }

    export interface IRequestTaxpayerFolioAlert {
        FormattedTaxpayerName: string;
    }

    export interface IRequestFolioAlert {
        ServiceType: IServiceTypeFolioAlert;
        RequestStatus: IRequestStatusFolioAlert;
        RequestTaxpayer: IRequestTaxpayerFolioAlert;
        AdmUserAddedFullName: string;
        AdmDateAdded: Date;
        RequestCurrentWorkerFullName: string;
        RequestID: number;
        FormattedRequestNumber: string;
        RequestComments: string;
    }

    export interface IValueFolioAlert {
        Request: IRequestFolioAlert;
    }

    export interface IRequestFolioAlertViewModel {
        RequestID: number;
        FormattedTaxpayerName: string;
        AdmUserAddedFullName: string;
        AdmDateAdded: Date;
        RequestCurrentWorkerFullName: string;
        FormattedRequestNumber: string;
        RequestComments: string;
        ServiceTypeName: string;
        RequestStatusName: string;
        RequestStatusColor: string;



        //value: IValueFolioAlert[];
    }
}