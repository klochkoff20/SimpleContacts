using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleContacts.Common.Enums;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.Abstractions
{
    public interface IVacancyService
    {
        Task<ResponseMessageResult<string>> CreateVacancyAsync(VacancyInsertViewModel vacancy);
        Task<ResponseMessageResult<List<VacancyGeneralInfoViewModel>>> GetAllVacanciesAsync();
        Task<ResponseMessageResult<PagedList<VacancyGeneralInfoViewModel>>> GetAllVacanciesSortedAsync(int page, int pageSize, string order, VacancySortField field, string filter);
        Task<ResponseMessageResult<VacancyViewModel>> GetVacancyById(Guid id);
        Task<BaseResponseMessageResult> UpdateVacancyAsync(Guid id, VacancyUpdateViewModel vacancy);
        Task<BaseResponseMessageResult> DeleteVacancyAsync(Guid id);
    }
}
