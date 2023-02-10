using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;
using SimpleCRUD_NET_6.Api.Helpers;
using SimpleCRUD_NET_6.Api.Services;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Username { get; set; }
        public string Name { get; set; }
    }

    public class CreateUserResponse
    {
        public List<User> users { get; set; }
    }

    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {

        public CreateUserValidator()
        {

            CascadeMode = CascadeMode.Stop;

           
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username cannot be empty")
                .Matches(@"^[a-zA-Z0-9-_']*$")
                .WithMessage("Username only a-z, 0-9, @, _ and - are allowed");

           
        }

        //private bool UsernameExists(CreateUserRequest request, string username)
        //{
        //    if (string.IsNullOrEmpty(request.Username)) return true;
             
        //    var existsCount = 0;

        //    return existsCount == 0;
        //}

        

    }

    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
       

        public CreateUserHandler(ICalculateAgeService calculateAgeService)
        {
           
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {

            // var hash = HashingExtension.Hash256(request.Password, _appSettingProvider.PasswordSalt);
            var addNewUser = new User
            {
                Username = "junhao",
                Name = "junhao123",
            };

            using (var context = new ApiContext())
            {
                context.Users.Add(addNewUser);
                context.SaveChanges();


                var list = context.Users.ToList();

                return await Task.FromResult(new CreateUserResponse
                {
                    users = list
                });
            }


            
        }

    }
}