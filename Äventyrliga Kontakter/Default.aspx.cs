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
        protected void Page_Load(object sender, EventArgs e)
        {
            DataPager1.SetPageProperties(1, 20, false);
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
                    TextLabel.Text = "Kontakten lades till";
                    Panel.Visible = true;
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
                TextLabel.Text = "Kontakten togs bort";
                Panel.Visible = true;
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
                    TextLabel.Text = "Kontakten Uppdaterades";
                    Panel.Visible = true;
                }
                catch
                {
                    ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när kontakten med ID {0} skulle uppdateras", ContactID));
                }
            }
        }
    }
}