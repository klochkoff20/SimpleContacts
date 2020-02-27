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
        
        public async Task<ResponseMessageResult<string>> CreateDepartmentAsync(DepartmentViewModel department)
        {
            var response = new ResponseMessageResult<string>();

            var newDepartment = _mapper.Map<Department>(department);

            await _departmentRepository.AddAsync(newDepartment);
            await _unitOfWork.SaveChangesAsync();

            response.Content = department.Id.ToString();
            response.Message = $"Department [{department.Name}] Id: [{department.Id}] was successfully added!";

            return response;
        }

        public async Task<ResponseMessageResult<PagedList<DepartmentViewModel>>> GetAllDepartmentsAsync(int page, int pageSize)
        {
            var response = new ResponseMessageResult<PagedList<DepartmentViewModel>>();
            var departments = await _departmentRepository.GetAllAsync();

            response.Content = _mapper.Map<List<DepartmentViewModel>>(departments).ToPagedList(page, pageSize);
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

        public async Task<BaseResponseMessageResult> UpdateDepartmentAsync(Guid id, DepartmentViewModel department)
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
