var app;
(function (app) {
    var domain;
    (function (domain) {
        var RequestCustomFieldViewModel = (function () {
            function RequestCustomFieldViewModel(RequestActionID, ServiceTypeID, CustomFieldID, CustomFieldTypeID, ErrorMessage, RegularExpression, LabelName, DisplayData, FieldValue, PlaceholderText, TextAlignment, InputSequence, RequiredFlag, TooltipMessage, SelectListItems, SelectListDisplayData, ServiceTypeChildCheckedByDefaultFlag, DisplayFieldValueInCommentsFlag) {
                this.RequestActionID = RequestActionID;
                this.ServiceTypeID = ServiceTypeID;
                this.CustomFieldID = CustomFieldID;
                this.CustomFieldTypeID = CustomFieldTypeID;
                this.ErrorMessage = ErrorMessage;
                this.RegularExpression = RegularExpression;
                this.LabelName = LabelName;
                this.DisplayData = DisplayData;
                this.FieldValue = FieldValue;
                this.PlaceholderText = PlaceholderText;
                this.TextAlignment = TextAlignment;
                this.InputSequence = InputSequence;
                this.RequiredFlag = RequiredFlag;
                this.TooltipMessage = TooltipMessage;
                this.SelectListItems = SelectListItems;
                this.SelectListDisplayData = SelectListDisplayData;
                this.ServiceTypeChildCheckedByDefaultFlag = ServiceTypeChildCheckedByDefaultFlag;
                this.DisplayFieldValueInCommentsFlag = DisplayFieldValueInCommentsFlag;
            }
            return RequestCustomFieldViewModel;
        }());
        domain.RequestCustomFieldViewModel = RequestCustomFieldViewModel;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=requestCustomFieldViewModel.js.map