using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleCRUD_NET_6.Api.Domains;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteUserResponse
    {

    }

    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
       
        public DeleteUserHandler()
        {
           
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            
            
            return await Task.FromResult(new DeleteUserResponse());
        }
         
    }
}