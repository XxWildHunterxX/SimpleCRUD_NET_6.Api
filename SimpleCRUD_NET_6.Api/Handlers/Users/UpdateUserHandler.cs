using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SimpleCRUD_NET_6.Api.Domains;

namespace SimpleCRUD.Api.Handlers.Users
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public UserType? UserType { get; set; }

        public string StreamRole { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
    }

    public class UpdateUserResponse
    { 
    }

    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        
        public UpdateUserValidator()
        {
            
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UserType)
                .NotEmpty()
                .WithMessage("User Type cannot be empty") ;

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number cannot be empty")
                .Must(PhoneNumberExists)
                .WithMessage("Phone Number is used. Please use other Phone Number");

            RuleFor(x => x.CountryCode)
                .NotEmpty()
                .WithMessage("Country Code cannot be empty");


        }

        private bool PhoneNumberExists(UpdateUserRequest request, string username)
        {
            if (string.IsNullOrEmpty(request.PhoneNumber)) return true;

            var existsCount = 0;

            return existsCount == 0;
        }

    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {

        
        public UpdateUserHandler()
        {
           
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request,
            CancellationToken cancellationToken)
        { 
  
            return await Task.FromResult(new UpdateUserResponse
            { 
            });
        }
        
    }
}