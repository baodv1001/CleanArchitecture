using AutoMapper;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_infrastructure.Repositories
{
    public class RequestDateoffRepository : IRequestDateoffRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestDateoffRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Create(List<RequestDateoff> requestDateoffs)
        {
            foreach (var requestDateoff in requestDateoffs)
            {
                var dbRequest = _mapper.Map<RequestDateoffEntity>(requestDateoff);
                _dbContext.RequestDateoffs.Add(dbRequest);
                _dbContext.Entry(dbRequest).Reference(c => c.Request).Load();
                _dbContext.Entry(dbRequest).Reference(c => c.Dateoff).Load();
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
