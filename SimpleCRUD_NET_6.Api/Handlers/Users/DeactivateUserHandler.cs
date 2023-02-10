using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class DeactivateUserRequest : IRequest<DeactivateUserResponse>
    {
        public int Id { get; set; }
    }

    public class DeactivateUserResponse
    {

    }

    public class DeactivateUserHandler : IRequestHandler<DeactivateUserRequest, DeactivateUserResponse>
    {
        private readonly ApiContext _apiContext;

        public DeactivateUserHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;

        }

        public async Task<DeactivateUserResponse> Handle(DeactivateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _apiContext.Users.Where(u=> u.Id == request.Id).FirstOrDefault();

            user.IsActive = false;

            _apiContext.SaveChanges();

            return await Task.FromResult(new DeactivateUserResponse());
        }
         
    }
}