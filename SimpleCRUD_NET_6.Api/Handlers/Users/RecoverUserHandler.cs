using MediatR;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class RecoverUserRequest : IRequest<RecoverUserResponse>
    {
        public int Id { get; set; }
    }

    public class RecoverUserResponse
    {

    }

    public class RecoverUserHandler : IRequestHandler<RecoverUserRequest, RecoverUserResponse>
    {
        private readonly ApiContext _apiContext;

        public RecoverUserHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;

        }

        public async Task<RecoverUserResponse> Handle(RecoverUserRequest request, CancellationToken cancellationToken)
        {
            var user = _apiContext.Users.Where(u => u.Id == request.Id).FirstOrDefault();

            user.IsActive = true;

            _apiContext.SaveChanges();

            return await Task.FromResult(new RecoverUserResponse());
        }

    }
}
