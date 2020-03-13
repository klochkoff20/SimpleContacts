﻿using SimpleContacts.Common.Enums;
using SimpleContacts.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleContacts.DAL.Abstractions
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Task<Candidate> GetCandidateById(Guid id);
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
        Task<IEnumerable<Candidate>> GetAllCandidatesSortedAsync(string order, CandidateSortField field, string filter);
    }
}
