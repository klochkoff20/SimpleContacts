using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleContacts.ViewModels
{
    public class VacancyOnHoldViewModel
    {
        public Guid Id { get; set; }
        public BasicInfo<Guid> Vacancy { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
