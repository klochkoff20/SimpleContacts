using System;
using System.Collections.Generic;
using SimpleContacts.Entities.Entities;

namespace SimpleContacts.ViewModels
{
    public class TagViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public IList<CandidatesTags> CandidatesTags { get; set; }
    }
}
