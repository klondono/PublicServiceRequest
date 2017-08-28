using System;
using System.Collections.Generic;
using System.Linq;
using CustomerService_PSR.Models;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace PublicServiceRequest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //This application uses ODATA version 3.  For reference info see
            //Supporting OData v3 in ASP.NET Web API: https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-v3/

            //var cors = new EnableCorsAttribute("http://testweb1panet.miamidade.gov", "*", "*");
            //config.EnableCors(cors);

            // Web API Odata configuration and services
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Request>("Requests");
            builder.EntitySet<ApplicationSource>("ApplicationSources");
            builder.EntitySet<RequestAction>("RequestActions");
            builder.EntitySet<RequestAttachment>("RequestAttachments");
            builder.EntitySet<RequestFolio>("RequestFolios");
            builder.EntitySet<RequestAgenda>("RequestAgendas");
            builder.EntitySet<RequestFolioType>("RequestFolioTypes");
            builder.EntitySet<RequestOrigin>("RequestOrigins");
            builder.EntitySet<RequestPriority>("RequestPriorities");
            builder.EntitySet<RequestStatus>("RequestStatus");
            builder.EntitySet<RequestTaxpayer>("RequestTaxpayers");
            builder.EntitySet<RequestTaxpayerPreferredLanguage>("RequestTaxpayerPreferredLanguages");
            builder.EntitySet<RequestType>("RequestTypes");
            builder.EntitySet<ServiceType>("ServiceTypes");
            builder.EntitySet<ServiceTypeCustomFieldTransaction>("ServiceTypeCustomFieldTransactions");
            builder.EntitySet<ServiceTypeResolution>("ServiceTypeResolutions");
            builder.EntitySet<AttachmentType>("AttachmentTypes");
            builder.EntitySet<ServiceTypeCustomField>("ServiceTypeCustomFields");
            builder.EntitySet<ServiceTypeOwnerGroup>("ServiceTypeOwnerGroups");
            builder.EntitySet<ServiceTypeRelationshipDefinition>("ServiceTypeRelationshipDefinitions");
            builder.EntitySet<ServiceTypeRequestActionTypeLink>("ServiceTypeRequestActionTypeLinks");
            builder.EntitySet<ServiceTypeResolutionLink>("ServiceTypeResolutionLinks");
            builder.EntitySet<ServiceTypeSearchKeywordLink>("ServiceTypeSearchKeywordLinks");
            builder.EntitySet<ServiceTypeOwnerGroupLocation>("ServiceTypeOwnerGroupLocations");
            builder.EntitySet<ServiceTypeSearchKeyword>("ServiceTypeSearchKeywords");
            builder.EntitySet<CustomFieldDataType>("CustomFieldDataTypes");
            builder.EntitySet<CustomFieldType>("CustomFieldTypes");
            builder.EntitySet<RequestActionType>("RequestActionTypes");
            builder.EntitySet<RequestActionCustomFieldTransaction>("RequestActionCustomFieldTransactions");
            builder.EntitySet<CustomFieldSelectListItem>("CustomFieldSelectListItems");
            builder.EntitySet<RequestActionTypeCustomField>("RequestActionTypeCustomFields");
            builder.EntitySet<RequestFolio>("RequestFolios");
            builder.EntitySet<ServiceTypeChildStartTrigger>("ServiceTypeChildStartTriggers");
            builder.EntitySet<View_RequestMainSearchGridWFolio>("View_RequestMainSearchGridWFolio");
            builder.EntitySet<View_RequestFolioByRequestNumberAndYear>("View_RequestFolioByRequestNumberAndYear");
            builder.EntitySet<View_RequestFolioGrid>("View_RequestFolioGrid");
            builder.EntitySet<PSRInterviewViewModel>("PSRInterviews");
            builder.EntitySet<View_PSRAdmUserAdded>("View_PSRAdmUserAdded");
            builder.EntitySet<View_PSRCurrentlyAssigned>("View_PSRCurrentlyAssigned");
            
            //custom post actions
            ActionConfiguration getAssociatedServiceTypes = builder.Entity<ServiceType>().Collection.Action("GetAssociatedServiceTypes");
            getAssociatedServiceTypes.Parameter<int>("id");
            getAssociatedServiceTypes.ReturnsCollectionFromEntitySet<ServiceType>("ServiceTypes");

            ActionConfiguration initializeRequest = builder.Entity<Request>().Collection.Action("InitializeRequest");
            initializeRequest.Parameter<int>("ServiceTypeID");
            initializeRequest.Returns<RequestCreateViewModel>();

            ActionConfiguration initializeRequestMainSearch = builder.Entity<Request>().Collection.Action("InitializeRequestMainSearch");
            initializeRequestMainSearch.Returns<RequestMainSearchViewModel>();

            ActionConfiguration createRequest = builder.Entity<Request>().Collection.Action("CreateRequest");
            createRequest.Parameter<RequestCreateViewModel>("NewRequest");
            createRequest.Parameter<AssociatedServiceTypeContainerViewModel>("AssociatedServiceTypes");
            createRequest.Returns<int>();

            ActionConfiguration createRequestAction = builder.Entity<RequestAction>().Collection.Action("CreateRequestAction");
            createRequestAction.Parameter<RequestActionTypeViewModel>("NewAction");
            createRequestAction.Returns<RefreshedRequestWorkspaceViewModel>();

            ActionConfiguration viewRequestWorkspace = builder.Entity<Request>().Collection.Action("GetRequestWorkspaceViewModel");
            viewRequestWorkspace.Parameter<int>("RequestID");
            viewRequestWorkspace.Returns<RequestWorkspaceViewModel>();

            ActionConfiguration getSortedRequestActions = builder.Entity<RequestAction>().Collection.Action("SortRequestActions");
            getSortedRequestActions.Parameter<int>("RequestID");
            getSortedRequestActions.Parameter<string>("SortBy");
            getSortedRequestActions.Parameter<bool>("BlnAsc");
            getSortedRequestActions.Returns<SortedRequestActionsContainerViewModel>();

            ActionConfiguration viewRequestActionTypeViewModel = builder.Entity<RequestAction>().Collection.Action("GetRequestActionTypeViewModel");
            viewRequestActionTypeViewModel.Parameter<int>("RequestServiceTypeID");
            viewRequestActionTypeViewModel.Parameter<int>("RequestActionTypeID");
            viewRequestActionTypeViewModel.Parameter<int>("RequestID");
            viewRequestActionTypeViewModel.Parameter<bool>("RequestChildrenCloseParentFlag");
            viewRequestActionTypeViewModel.Parameter<bool>("ConcurrentCreationOfChildrenFlag");
            viewRequestActionTypeViewModel.Parameter<int?>("TaxpayerID");

            viewRequestActionTypeViewModel.CollectionParameter<AssociatedRequestWorkspaceViewModel>("AssociatedRequests");
            viewRequestActionTypeViewModel.Returns<RequestActionTypeViewModel>();

            ActionConfiguration validateFolio = builder.Entity<RequestFolio>().Collection.Action("ValidateFolio");
            validateFolio.Parameter<string>("FolioNo");
            validateFolio.Parameter<string>("PropertyType");
            validateFolio.Parameter<string>("Year");
            validateFolio.Returns<RequestFolioViewModel>();

            ActionConfiguration getOpenRequestsByFolio = builder.Entity<RequestFolio>().Collection.Action("GetOpenRequestsByFolio");
            getOpenRequestsByFolio.Parameter<string>("FolioNo");
            getOpenRequestsByFolio.Returns<RequestFolioAlertModalViewModel>();

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
