using CustomerService_PSR.Models;
using CustomerService_PSR.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CustomerService_PSR.Controllers
{
    [Authorize]
    public class AssociatedServiceTypesController : Controller
    {
        private PAGeneralDb db = new PAGeneralDb();

        public ActionResult GetAssociatedServiceTypes(int? id)
        {
            var associatedServiceTypeContainer = new AssociatedServiceTypeContainerViewModel();

            List<AssociatedServiceTypeViewModel> associatedServiceTypeViewModel =
                db.Database.SqlQuery<AssociatedServiceTypeViewModel>(
                "Select * from PSR.GetServiceTypeChildrenByParent(@id)",
                new SqlParameter("@id", id)).ToList();

            associatedServiceTypeContainer.AssociatedServiceTypes = associatedServiceTypeViewModel;

            //get serviceTypeIDs from list; cannot join the in memory associatedServiceTypeViewModel list in LINQ query
            var serviceTypeIDs = associatedServiceTypeViewModel.Select(i => i.ServiceTypeID);

            associatedServiceTypeContainer.CustomFields = (from cf in db.ServiceTypeCustomFields
                                                           join rd in db.ServiceTypeRelationshipDefinitions on cf.ServiceTypeID  equals rd.ServiceTypeChildID into rdj
                                                           from rd in rdj.DefaultIfEmpty()
                                                           where serviceTypeIDs.Contains(cf.ServiceTypeID) && cf.AdmIsActive == "Y"
                                                           orderby cf.ServiceTypeID, cf.InputSequence
                                                           select new RequestCustomFieldViewModel()
                                                           {
                                                               ServiceTypeChildCheckedByDefaultFlag = rd.ServiceTypeChildCheckedByDefaultFlag,
                                                               RequestActionID = 0,
                                                               ServiceTypeID = cf.ServiceTypeID,
                                                               CustomFieldID = cf.ServiceTypeCustomFieldID,
                                                               CustomFieldTypeID = cf.CustomFieldTypeID,
                                                               ErrorMessage = cf.CustomFieldDataType.ErrorMessage,
                                                               RegularExpression = cf.CustomFieldDataType.RegularExpression,
                                                               LabelName = cf.LabelName,
                                                               PlaceholderText = cf.PlaceholderText,
                                                               TextAlignment = cf.TextAlignment,
                                                               InputSequence = cf.InputSequence,
                                                               RequiredFlag = cf.RequiredFlag,
                                                               TooltipMessage = cf.TooltipMessage,
                                                               SelectListItems = (from li in db.CustomFieldSelectListItems
                                                                                  where li.CustomFieldTypeID == cf.CustomFieldTypeID && li.AdmIsActive == "Y"
                                                                                  orderby li.ListSequence
                                                                                  select new RequestCustomFieldSelectListViewModel()
                                                                                  {
                                                                                      SelectListLabel = li.CustomFieldSelectListItemLabel,
                                                                                      SelectListValue = li.CustomFieldSelectListItemValue
                                                                                  }).ToList()
                                                           }).ToList();
            //return JsonNetResult class instead of json to avoid dates from being returned as millisecond number
            return new JsonNetResult() { Data = associatedServiceTypeContainer };
        }
    }
}