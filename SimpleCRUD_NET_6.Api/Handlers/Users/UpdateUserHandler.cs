using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;

namespace SimpleCRUD.Api.Handlers.Users
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class UpdateUserResponse
    {
    }

    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        private readonly ApiContext _apiContext;
        public UpdateUserValidator(ApiContext apiContext)
        {
            _apiContext = apiContext;

            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.BirthDate)
                .Must(BeAValidAge)
                .WithMessage("Your Birth Date Cannot more than Current Date")
                .NotEmpty()
                .WithMessage("Birth Date cannot be empty");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number cannot be empty");
        }

        
        private bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear < currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }

    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly ApiContext _apiContext;

        public UpdateUserHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request,CancellationToken cancellationToken)
        {

            var user = _apiContext.Users.Where(u => u.Id == request.Id).FirstOrDefault();

            user.Name = request.Name;
            user.BirthDate = request.BirthDate;
            user.PhoneNumber = request.PhoneNumber;
            user.CountryCode = request.CountryCode;


            _apiContext.SaveChanges();

            return await Task.FromResult(new UpdateUserResponse());
        }

    }
}