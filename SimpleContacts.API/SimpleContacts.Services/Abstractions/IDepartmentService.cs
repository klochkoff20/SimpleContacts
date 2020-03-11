using System;
using System.Threading.Tasks;
using SimpleContacts.ViewModels;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Common.Enums;
using System.Collections.Generic;

namespace SimpleContacts.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ResponseMessageResult<string>> CreateDepartmentAsync(DepartmentInsertViewModel department);
        Task<ResponseMessageResult<List<DepartmentGeneralInfoViewModel>>> GetAllDepartmentsAsync();
        Task<ResponseMessageResult<PagedList<DepartmentGeneralInfoViewModel>>> GetAllDepartmentsSortedAsync(int pagIndex, int pageSize, string order, DepartmentSortField field, string filter);
        Task<ResponseMessageResult<DepartmentViewModel>> GetDepartmentByIdAsync(Guid id);
        Task<BaseResponseMessageResult> UpdateDepartmentAsync(Guid id, DepartmentUpdateViewModel department);
        Task<BaseResponseMessageResult> DeleteDepartmentAsync(Guid id);
    }
}
