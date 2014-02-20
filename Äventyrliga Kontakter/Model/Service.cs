using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Äventyrliga_Kontakter.Model.DAL;

namespace Äventyrliga_Kontakter.Model
{
    public class Service
    {
        private static ContactDAL _ContactDAL;

        private static ContactDAL ContactDAL 
        {
            get { return _ContactDAL ?? (_ContactDAL = new ContactDAL()); } 
        }

        public static void DeleteContact(Contact contact)
        {
            DeleteContact(contact.ContactID);
        }

        public static void DeleteContact(int contactId)
        {
            ContactDAL.DeleteContact(contactId);
        }

        public static Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

        public static IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();
        }

        public static IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ContactDAL.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        public static void SaveContact(Contact contact)
        {
            if (contact.ContactID == 0)
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }
        }
    }
}