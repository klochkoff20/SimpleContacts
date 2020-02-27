using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<PagedList<DepartmentViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<DepartmentViewModel>>>> GetAll(int page = -1, int pageSize = 15)
        {
            return await _departmentService.GetAllDepartmentsAsync(page, pageSize);
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
        public async Task<ActionResult<BaseResponseMessageResult>> Create(DepartmentViewModel department)
        {
            return await _departmentService.CreateDepartmentAsync(department);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Update(Guid id, DepartmentViewModel department)
        {
            return await _departmentService.UpdateDepartmentAsync(id, department);
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
