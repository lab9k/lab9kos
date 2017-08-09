using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.UrenViewModels
{
    public class EditViewModel
    {

        public long? Id { get; set; }

        public long DateTimeStamp { get; set; }
        [Required]
        [Range(0,8)]
        public int Maandag { get; set; }

        [Required]
        [Range(0, 8)]
        public int Dinsdag { get; set; }

        [Required]
        [Range(0, 8)]
        public int Woensdag { get; set; }

        [Required]
        [Range(0, 8)]
        public int Donderdag { get; set; }

        [Required]
        [Range(0, 8)]
        public int Vrijdag { get; set; }

    }
}
