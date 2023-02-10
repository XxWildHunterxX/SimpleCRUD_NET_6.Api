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
        public string Name { get; set; }
        public string Username { get; set; }
        public UserType UserType { get; set; }

        public string StreamRole { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
    }



    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
       
        public GetUserHandler()
        {
           
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request,
            CancellationToken cancellationToken)
        {

            var response = new GetUserResponse();

            return await Task.FromResult(response);
        }
       
    }
}