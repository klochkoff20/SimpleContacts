using System;
using System.Threading.Tasks;
using SimpleContacts.ViewModels;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Common.Enums;

namespace SimpleContacts.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ResponseMessageResult<string>> CreateDepartmentAsync(DepartmentViewModel department);
        Task<ResponseMessageResult<PagedList<DepartmentGeneralInfoViewModel>>> GetAllDepartmentsAsync(int pageIndex, int pageSize);
        Task<ResponseMessageResult<PagedList<DepartmentGeneralInfoViewModel>>> GetAllDepartmentsSortedAsync(int pagIndex, int pageSize, string order, DepartmentSortField field, string filter);
        Task<ResponseMessageResult<DepartmentViewModel>> GetDepartmentByIdAsync(Guid id);
        Task<BaseResponseMessageResult> UpdateDepartmentAsync(Guid id, DepartmentViewModel department);
        Task<BaseResponseMessageResult> DeleteDepartmentAsync(Guid id);
    }
}
