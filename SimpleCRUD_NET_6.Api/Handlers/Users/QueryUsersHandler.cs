using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;
using SimpleCRUD_NET_6.Api.Handlers.Dtos;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class QueryUsersRequest : IRequest<ListResponse>
    {
    }

    public class QueryUsersHandler : IRequestHandler<QueryUsersRequest, ListResponse>
    {
       
        public QueryUsersHandler()
        {
           
        }

        public async Task<ListResponse> Handle(QueryUsersRequest request, CancellationToken cancellationToken)
        {
            using (var context = new ApiContext())
            {
                var list = context.Users.ToList();

                return await Task.FromResult(new ListResponse
                {
                    Data = list
                });
            }

        }

       
    }
}