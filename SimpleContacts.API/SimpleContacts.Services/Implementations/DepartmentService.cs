using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using SimpleContacts.ViewModels;
using SimpleContacts.DAL.Abstractions;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.Infrastructure.Helpers;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Common.Enums;
using System.Linq;

namespace SimpleContacts.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
        }
        
        public async Task<ResponseMessageResult<string>> CreateDepartmentAsync(DepartmentInsertViewModel department)
        {
            var response = new ResponseMessageResult<string>();

            var newDepartment = _mapper.Map<Department>(department);

            await _departmentRepository.AddAsync(newDepartment);
            await _unitOfWork.SaveChangesAsync();

            response.Content = newDepartment.Id.ToString();
            response.Message = $"Department [{newDepartment.Name}] Id: [{newDepartment.Id}] was successfully added!";

            return response;
        }

        public async Task<ResponseMessageResult<List<DepartmentGeneralInfoViewModel>>> GetAllDepartmentsAsync()
        {
            var response = new ResponseMessageResult<List<DepartmentGeneralInfoViewModel>>();
            var departments = await _departmentRepository.GetAllDepartmentsAsync();

            response.Content = _mapper.Map<List<DepartmentGeneralInfoViewModel>>(departments).ToList();
            return response;
        }

        public async Task<ResponseMessageResult<PagedList<DepartmentGeneralInfoViewModel>>> GetAllDepartmentsSortedAsync
            (int pageIndex, int pageSize, string order, DepartmentSortField field, string filter)
        {
            var response = new ResponseMessageResult<PagedList<DepartmentGeneralInfoViewModel>>();
            var departments = await _departmentRepository.GetAllDepartmentsSortedAsync(order, field, filter);

            response.Content = _mapper.Map<List<DepartmentGeneralInfoViewModel>>(departments).ToPagedList(pageIndex, pageSize);
            return response;
        }

        public async Task<ResponseMessageResult<DepartmentViewModel>> GetDepartmentByIdAsync(Guid id)
        {
            var response = new ResponseMessageResult<DepartmentViewModel>();

            var department = await _departmentRepository.GetAsync(id);
            if(department == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Department [{id}] was not found!");
                return response;
            }

            response.Content = _mapper.Map<DepartmentViewModel>(department);
            return response;
        }

        public async Task<BaseResponseMessageResult> UpdateDepartmentAsync(Guid id, DepartmentUpdateViewModel department)
        {
            var response = new BaseResponseMessageResult();

            var oldDepartment = await _departmentRepository.GetAsync(id);
            if(oldDepartment == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Department [{id}] was not found!");
                return response;
            }

            var updatedDepartment = _mapper.Map(department, oldDepartment);
            _departmentRepository.Update(updatedDepartment);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"Department [{id}] was updated!";

            return response;
        }

        public async Task<BaseResponseMessageResult> DeleteDepartmentAsync(Guid id)
        {
            var response = new BaseResponseMessageResult();

            var department = await _departmentRepository.GetAsync(id);
            if (department == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Department [{id}] was not found!");
                return response;
            }

            await _departmentRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"Department [{id}] was removed!";

            return response;
        }
    }
}
