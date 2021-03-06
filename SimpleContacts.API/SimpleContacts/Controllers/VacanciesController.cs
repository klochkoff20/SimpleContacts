﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleContacts.Common.Enums;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyService _vancancyService;

        public VacanciesController(IVacancyService vacancyService)
        {
            _vancancyService = vacancyService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<PagedList<VacancyGeneralInfoViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<VacancyGeneralInfoViewModel>>>> GetAll
            (int pageIndex = -1, int pageSize = 15)
        {
            return await _vancancyService.GetAllVacanciesAsync(pageIndex, pageSize);
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}/{order}/{field:int}/{filter}")]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<PagedList<VacancyGeneralInfoViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<VacancyGeneralInfoViewModel>>>> GetAllSorted
          (int pageIndex = -1, int pageSize = 15, string order = "", VacancySortField field = 0, string filter = "")
        {
            return await _vancancyService.GetAllVacanciesSortedAsync(pageIndex, pageSize, order, field, filter);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<VacancyViewModel>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ResponseMessageResult<VacancyViewModel>>> GetById(Guid id)
        {
            return await _vancancyService.GetVacancyById(id);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Create(VacancyViewModel vacancy)
        {
            return await _vancancyService.CreateVacancyAsync(vacancy);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Update(Guid id, VacancyViewModel vacancy)
        {
            return await _vancancyService.UpdateVacancyAsync(id, vacancy);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Delete(Guid id)
        {
            return await _vancancyService.DeleteVacancyAsync(id);
        }
    }
}
