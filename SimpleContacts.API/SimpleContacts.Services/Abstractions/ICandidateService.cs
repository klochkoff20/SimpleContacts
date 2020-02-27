using System;
using System.Threading.Tasks;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.Abstractions
{
    public interface ICandidateService
    {
        Task<ResponseMessageResult<string>> CreateCandidateAsync(CandidateViewModel candidate);
        Task<ResponseMessageResult<PagedList<CandidateViewModel>>> GetAllCandidatesAsync(int page, int pageSize);
        Task<ResponseMessageResult<CandidateViewModel>> GetCandidateByIdAsync(Guid id);
        Task<BaseResponseMessageResult> UpdateCandidateAsync(Guid id, CandidateViewModel candidate);
        Task<BaseResponseMessageResult> DeleteCandidateAsync(Guid id);
    }
}
