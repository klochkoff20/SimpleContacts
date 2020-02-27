using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.ViewModels;

namespace SimpleContacts.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponseMessageResult<PagedList<CandidateViewModel>>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<CandidateViewModel>>>> GetAll(int page = -1, int pageSize = 15)
        {
            return await _candidateService.GetAllCandidatesAsync(page, pageSize);
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
        public async Task<ActionResult<BaseResponseMessageResult>> Create(CandidateViewModel candidate)
        {
            return await _candidateService.CreateCandidateAsync(candidate);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Update(Guid id, CandidateViewModel candidate)
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
