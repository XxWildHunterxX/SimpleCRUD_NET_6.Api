using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;
using SimpleCRUD_NET_6.Api.Handlers.Dtos;
using SimpleCRUD_NET_6.Api.Services;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class QueryUsersRequest : IRequest<ListResponse>
    {
    }

    public class QueryUsersHandler : IRequestHandler<QueryUsersRequest, ListResponse>
    {
        private readonly ApiContext _apiContext;
        private readonly ICalculateAgeService _calculateAgeService;

        public QueryUsersHandler(ICalculateAgeService calculateAgeService, ApiContext apiContext)
        {
            _calculateAgeService = calculateAgeService;
            _apiContext = apiContext;
        }

        public async Task<ListResponse> Handle(QueryUsersRequest request, CancellationToken cancellationToken)
        {

            var list = _apiContext.Users.ToList();

            return await Task.FromResult(new ListResponse
            {
                Data = list.Select(x => new User
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    PhoneNumber = x.PhoneNumber,
                    CountryCode = x.CountryCode,
                    BirthDate = x.BirthDate,
                    Age = _calculateAgeService.CalculateAge(x.BirthDate),
                    IsActive = x.IsActive,
                })
            });


        }


    }
}