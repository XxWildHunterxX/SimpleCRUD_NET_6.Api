using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public long Id { get; set; }
    }

    public class GetUserResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public int? PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
    }

    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly ApiContext _apiContext;

        public GetUserHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request,
            CancellationToken cancellationToken)
        {

            var response = new GetUserResponse();

            var user = _apiContext.Users.Where(u => u.Id == request.Id).FirstOrDefault();

            if (user == null) return await Task.FromResult(response);

            response = new GetUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                CountryCode = user.CountryCode,

            };

            return await Task.FromResult(response);
        }
       
    }
}