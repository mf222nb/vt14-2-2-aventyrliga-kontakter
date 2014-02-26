using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Äventyrliga_Kontakter.Model
{
    public class Contact
    {
        public int ContactID { get; set; }
        [Required(ErrorMessage = "En Epost adress måste anges")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage="Eposten måste vara korrekt")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Ett förmamn måste anges")]
        [StringLength(50, ErrorMessage="Förnamnet kan bestå av 50 tecken som max")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Ett efternamn måste anges")]
        [StringLength(50, ErrorMessage = "Efternamnet kan bestå av 50 tecken som max")]
        public string LastName { get; set; }
    }
}