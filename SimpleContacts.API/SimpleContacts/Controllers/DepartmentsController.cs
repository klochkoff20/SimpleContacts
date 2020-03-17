using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleContacts.Common.Enums;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<List<DepartmentGeneralInfoViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<List<DepartmentGeneralInfoViewModel>>>> GetAll()
        {
            return await _departmentService.GetAllDepartmentsAsync();
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}/{order}/{field:int}/{filter}")]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<PagedList<DepartmentGeneralInfoViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<DepartmentGeneralInfoViewModel>>>> GetAllSorted
            (int pageIndex = -1, int pageSize = 15, string order = "", DepartmentSortField field = 0, string filter = "")
        {
            return await _departmentService.GetAllDepartmentsSortedAsync(pageIndex, pageSize, order, field, filter);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<DepartmentViewModel>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ResponseMessageResult<DepartmentViewModel>>> GetById(Guid id)
        {
            return await _departmentService.GetDepartmentByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Create(DepartmentInsertViewModel department)
        {
            return await _departmentService.CreateDepartmentAsync(department);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Update(Guid id, DepartmentUpdateViewModel department)
        {
            return await _departmentService.UpdateDepartmentAsync(id, department);
        }


        [HttpPut("{id:Guid}/{status:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> UpdateStatus(Guid id, DepartmentStatus status)
        {
            return await _departmentService.UpdateDepartmentStatusAsync(id, status);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Delete(Guid id)
        {
            return await _departmentService.DeleteDepartmentAsync(id);
        }
    }
}
