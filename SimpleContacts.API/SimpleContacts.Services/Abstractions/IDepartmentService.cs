using System;
using System.Threading.Tasks;
using SimpleContacts.ViewModels;
using SimpleContacts.Infrastructure.APIResponce;

namespace SimpleContacts.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ResponseMessageResult<string>> CreateDepartmentAsync(DepartmentViewModel department);
        Task<ResponseMessageResult<PagedList<DepartmentViewModel>>> GetAllDepartmentsAsync(int page, int pageSize);
        Task<ResponseMessageResult<DepartmentViewModel>> GetDepartmentByIdAsync(Guid id);
        Task<BaseResponseMessageResult> UpdateDepartmentAsync(Guid id, DepartmentViewModel department);
        Task<BaseResponseMessageResult> DeleteDepartmentAsync(Guid id);
    }
}
