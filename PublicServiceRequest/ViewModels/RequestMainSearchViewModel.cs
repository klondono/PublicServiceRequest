using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService_PSR.Models
{
    public class RequestMainSearchViewModel
    {
        public string RequestNo { get; set; }
        public string Folio { get; set; }
        public string Requestor { get; set; }
        public List<SearchStatusViewModel> StatusList { get; set; }
        public List<SearchAssigneeViewModel> AssigneeList { get; set; }
        public string CreatedFrom { get; set; }
        public string CreatedTo  { get; set; }
        public int? SelectedStatusID { get; set; }
        public SearchAssigneeViewModel SelectedAssignee { get; set; }
        public string CurrentUser { get; set; }
    }

    public class SearchStatusViewModel
    {
        public int? StatusValue { get; set; }
        public string StatusName { get; set; }
    }

    public class SearchAssigneeViewModel
    {
        public Guid? AssigneeID { get; set; }
        public string AssigneeName { get; set; }
        public string AssigneeType { get; set; }
        public string AssigneeUniqueID { get; set;}
    }
}