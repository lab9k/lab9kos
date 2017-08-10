using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.AdminViewModels
{
    public class WekenViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Ontvanger { get; set; }

        [Required]
        public String Inhoud { get; set; }
    }
}
