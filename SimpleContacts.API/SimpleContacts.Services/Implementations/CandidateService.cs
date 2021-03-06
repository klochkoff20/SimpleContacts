﻿using System;
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
    public class CandidateService : ICandidateService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            ICandidateRepository candidateRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _candidateRepository = candidateRepository;
        }

        public async Task<ResponseMessageResult<string>> CreateCandidateAsync(CandidateViewModel candidate)
        {
            var response = new ResponseMessageResult<string>();

            var newCandidate = _mapper.Map<Candidate>(candidate);

            await _candidateRepository.AddAsync(newCandidate);
            await _unitOfWork.SaveChangesAsync();

            response.Content = candidate.Id.ToString();
            response.Message = $"Candidate [{candidate.Contact.FullName}] Id: [{candidate.Id}] was successfully added";

            return response;
        }

        public async Task<ResponseMessageResult<PagedList<CandidateViewModel>>> GetAllCandidatesAsync(int page, int pageSize)
        {
            var response = new ResponseMessageResult<PagedList<CandidateViewModel>>();
            var candidates = await _candidateRepository.GetAllAsync();

            response.Content = _mapper.Map<List<CandidateViewModel>>(candidates).ToPagedList(page, pageSize);
            return response;
        }

        public async Task<ResponseMessageResult<CandidateViewModel>> GetCandidateByIdAsync(Guid id)
        {
            var response = new ResponseMessageResult<CandidateViewModel>();

            var candidate = await _candidateRepository.GetAsync(id);
            if(candidate == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Candidate [{id}] was not found!");
                return response;
            }

            response.Content = _mapper.Map<CandidateViewModel>(candidate);
            return response;
        }

        public async Task<BaseResponseMessageResult> UpdateCandidateAsync(Guid id, CandidateViewModel candidate)
        {
            var response = new BaseResponseMessageResult();

            var oldCandidate = await _candidateRepository.GetAsync(id);
            if(oldCandidate == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Candidate [{id}] was not found!");
                return response;
            }

            var updatedCandidate = _mapper.Map(candidate, oldCandidate);
            _candidateRepository.Update(updatedCandidate);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"Candidate [{id}] was updated!";
            return response;
        }

        public async Task<BaseResponseMessageResult> DeleteCandidateAsync(Guid id)
        {
            var response = new BaseResponseMessageResult();

            var candidate = await GetCandidateByIdAsync(id);
            if(candidate == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"Candidate [{id}] was not found!");
                return response;
            }

            await _candidateRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"Candidate [{id}] was removed!";
            return response;
        }
    }
}
