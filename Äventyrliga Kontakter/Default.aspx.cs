using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Äventyrliga_Kontakter.Model;

namespace Äventyrliga_Kontakter
{
    public partial class Default : System.Web.UI.Page
    {
        //Returnerar true eller false beroende på om ett meddelande finns eller inte
        private bool HasMessage
        {
            get
            {
                return Session["uploadMessage"] != null;
            }
        }

        //Skapar en Session och tar bort den när den är skapad
        private string UploadMessage
        {
            get
            {
                var message = Session["uploadMessage"] as string;
                Session.Remove("uploadMessage");
                return message;

            }
            set
            {
                Session["uploadMessage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HasMessage)
            {
                TextLabel.Text = UploadMessage;
                SuccessPanel.Visible = true;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när kontakterna hämtades");
                totalRowCount = 0;
                return null;
            }
        }

        public void ContactListView_InsertItem()
        {
            var item = new Contact();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(item);
                    UploadMessage = String.Format("Kontakten lades till");
                    Response.Redirect("~/Default.aspx");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när kontakten skapades");
                }
                
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_DeleteItem(int ContactID)
        {
            try
            {
                Service.DeleteContact(ContactID);
                UploadMessage = String.Format("Kontakten togs bort");
                Response.Redirect("~/Default.aspx");
            }
            catch
            {

                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när kontakten med ID {0} skulle tas bort", ContactID));
            }
            
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(int ContactID)
        {
            var contact = Service.GetContact(ContactID);
 
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (contact == null)
            {
                // The item wasn't found
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när kontakten med ID {0} hittades inte", ContactID));
                return;
            }
            TryUpdateModel(contact);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                try
                {
                    Service.SaveContact(contact);
                    UploadMessage = String.Format("Kontakten uppdaterades");
                    Response.Redirect("~/Default.aspx");
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när kontakten med ID {0} skulle uppdateras", ContactID));
                }
            }
        }

        protected void ContactListView_PagePropertiesChanged(object sender, EventArgs e)
        {
            ContactListView.EditIndex = -1;
        }
    }
}