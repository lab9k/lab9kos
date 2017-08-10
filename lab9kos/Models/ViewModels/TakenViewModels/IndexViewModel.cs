using System.Collections.Generic;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.TakenViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Taak> Todo { get; set; }
        public IEnumerable<Taak> InProgress { get; set; }
        public IEnumerable<Taak> NeedsReview { get; set; }
        public IEnumerable<Taak> Done { get; set; }
        public long CurrentUserId { get; set; }

        public IndexViewModel()
        {
            Todo = new List<Taak>();
            InProgress = new List<Taak>();
            NeedsReview = new List<Taak>();
            Done = new List<Taak>();
        }
    }
}