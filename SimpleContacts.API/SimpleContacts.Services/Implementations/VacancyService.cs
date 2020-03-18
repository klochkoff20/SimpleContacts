using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using SimpleContacts.Common.Enums;
using SimpleContacts.DAL.Abstractions;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Infrastructure.Helpers;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Services.Implementations
{
    public class VacancyService : IVacancyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVacancyRepository _vacancyRepository;

        public VacancyService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IVacancyRepository vacancyRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _vacancyRepository = vacancyRepository;
        }

        public async Task<ResponseMessageResult<string>> CreateVacancyAsync(VacancyInsertViewModel vacancy)
        {
            var response = new ResponseMessageResult<string>();

            var newVacancy = _mapper.Map<Vacancy>(vacancy);

            await _vacancyRepository.AddAsync(newVacancy);
            await _unitOfWork.SaveChangesAsync();

            response.Content = newVacancy.Id.ToString();
            response.Message = $"Vacancy [{newVacancy.Name}] Id: [{newVacancy.Id}] was successfully added";

            return response;
        }

        public async Task<ResponseMessageResult<List<VacancyGeneralInfoViewModel>>> GetAllVacanciesAsync()
        {
            var response = new ResponseMessageResult<List<VacancyGeneralInfoViewModel>>();
            var vacancies = await _vacancyRepository.GetAllVacanciesAsync();

            response.Content = _mapper.Map<List<VacancyGeneralInfoViewModel>>(vacancies).ToList();

            return response;
        }

        public async Task<ResponseMessageResult<PagedList<VacancyGeneralInfoViewModel>>> GetAllVacanciesSortedAsync(
            int page, int pageSize, string order, VacancySortField field, string filter)
        {
            var response = new ResponseMessageResult<PagedList<VacancyGeneralInfoViewModel>>();
            var vacancies = await _vacancyRepository.GetAllVacanciesSortedAsync(order, field, filter);

            response.Content = _mapper.Map<List<VacancyGeneralInfoViewModel>>(vacancies).ToPagedList(page, pageSize);

            return response;
        }

        public async Task<ResponseMessageResult<VacancyViewModel>> GetVacancyById(Guid id)
        {
            var response = new ResponseMessageResult<VacancyViewModel>();
            var vacancy = await _vacancyRepository.GetVacancyById(id);
            if (vacancy == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Vacancy [{id}] was not found!");
                return response;
            }

            response.Content = _mapper.Map<VacancyViewModel>(vacancy);
            return response;
        }

        public async Task<BaseResponseMessageResult> UpdateVacancyAsync(Guid id, VacancyUpdateViewModel vacancy)
        {
            var response = new BaseResponseMessageResult();

            var oldVacancy = await _vacancyRepository.GetAsync(id);
            if (oldVacancy == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Vacancy [{id}] was not found!");
                return response;
            }

            var updatedVacancy = _mapper.Map(vacancy, oldVacancy);
            _vacancyRepository.Update(updatedVacancy);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"Vacancy [{id}] was updated!";
            return response;
        }

        public async Task<BaseResponseMessageResult> UpdateVacancyStatusAsync(Guid id, VacancyStatus status)
        {
            var response = new BaseResponseMessageResult();

            var vacancy = await _vacancyRepository.GetAsync(id);
            if (vacancy == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Vacancy [{id}] was not found!");
                return response;
            }

            if (status == VacancyStatus.OnHold)
            {
                vacancy.Priority = VacancyPriority.Low;
            }

            if (vacancy.Status == VacancyStatus.OnHold && status != VacancyStatus.OnHold)
            {
                vacancy.CreatedAt = DateTime.Now;
            }

            vacancy.Status = status;
            _vacancyRepository.Update(vacancy);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"Vacancy [{id}] status was updated!";
            return response;
        }

        public async Task<BaseResponseMessageResult> DeleteVacancyAsync(Guid id)
        {
            var response = new BaseResponseMessageResult();

            var vacancy = await _vacancyRepository.GetAsync(id);
            if (vacancy == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Vacancy [{id}] was not found!");
                return response;
            }

            await _vacancyRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"Vacancy [{id}] was removed!";
            return response;
        }
    }
}
