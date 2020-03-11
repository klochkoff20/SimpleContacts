using System;
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
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<PagedList<CandidateGeneralInfoViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<CandidateGeneralInfoViewModel>>>> GetAll
            (int pageIndex = -1, int pageSize = 15)
        {
            return await _candidateService.GetAllCandidatesAsync(pageIndex, pageSize);
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}/{order}/{field:int}/{filter}")]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<PagedList<CandidateGeneralInfoViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<CandidateGeneralInfoViewModel>>>> GetAllSorted
            (int pageIndex = -1, int pageSize = 15, string order = "", CandidateSortField field = 0, string filter = "")
        {
            return await _candidateService.GetAllCandidatesSortedAsync(pageIndex, pageSize, order, field, filter);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<CandidateViewModel>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ResponseMessageResult<CandidateViewModel>>> GetById(Guid id)
        {
            return await _candidateService.GetCandidateByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Create(CandidateInsertViewModel candidate)
        {
            return await _candidateService.CreateCandidateAsync(candidate);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Update(Guid id, CandidateUpdateViewModel candidate)
        {
            return await _candidateService.UpdateCandidateAsync(id, candidate);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> DeleteById(Guid id)
        {
            return await _candidateService.DeleteCandidateAsync(id);
        }
    }
}
