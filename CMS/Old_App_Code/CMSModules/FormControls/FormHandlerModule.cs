using CMS;
using CMS.DataEngine;
using CMS.OnlineForms;
using CMSApp.Old_App_Code.CMSModules.FormControls;

[assembly: RegisterModule(typeof(FormHandlerModule))]

// Registers the custom module into the system

namespace CMSApp.Old_App_Code.CMSModules.FormControls
{
    public class FormHandlerModule : Module
    {
        // Module class constructor, the system registers the module under the name "CustomFormHandlers"
        public FormHandlerModule()
            : base("CustomFormHandlers")
        {
        }

        // Contains initialization code that is executed when the application starts
        protected override void OnInit()
        {
            base.OnInit();

            // Assigns a handler to the BizFormItemEvents.Insert.After event
            // This event occurs after the creation of every new form record
            BizFormItemEvents.Insert.After += FormItem_InsertAfterHandler;
        }

        // Handles the form data when users create new records for the 'ContactUs' form
        private void FormItem_InsertAfterHandler(object sender, BizFormItemEventArgs e)
        {
            // Gets the form data object from the event handler parameter
            BizFormItem formDataItem = e.Item;

            // Checks that the form record was successfully created
            // Ensures that the custom actions only occur for records of the 'ContactUs' form
            // The values of form class names must be in lower case
            if (formDataItem != null && formDataItem.BizFormClassName == "bizform.contactus")
            {
                string firstNameFieldValue = formDataItem.GetStringValue("FirstName", "");
                string lastNameFieldValue = formDataItem.GetStringValue("LastName", "");

                // Perform any required logic with the form field values

                // Variable representing a custom value that you want to save into the form data
                object customFieldValue;

                // Sets and saves a value for the form record's 'CustomField' field
                //formDataItem.SetValue("CustomField", customFieldValue);
                //formDataItem.SubmitChanges(false);
            }
        }
    }
}