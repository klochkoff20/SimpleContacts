using System;
using System.Threading.Tasks;
using SimpleContacts.Common.Enums;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.Abstractions
{
    public interface ICandidateService
    {
        Task<ResponseMessageResult<string>> CreateCandidateAsync(CandidateInsertViewModel candidate);
        Task<ResponseMessageResult<PagedList<CandidateGeneralInfoViewModel>>> GetAllCandidatesAsync(int pageIndex, int pageSize);
        Task<ResponseMessageResult<PagedList<CandidateGeneralInfoViewModel>>> GetAllCandidatesSortedAsync(int pageIndex, int pageSize, string order, CandidateSortField field, string filter);
        Task<ResponseMessageResult<CandidateViewModel>> GetCandidateByIdAsync(Guid id);
        Task<BaseResponseMessageResult> UpdateCandidateAsync(Guid id, CandidateUpdateViewModel candidate);
        Task<BaseResponseMessageResult> DeleteCandidateAsync(Guid id);
    }
}
