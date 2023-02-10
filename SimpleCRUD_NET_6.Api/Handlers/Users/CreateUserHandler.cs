using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;
using SimpleCRUD_NET_6.Api.Services;

namespace SimpleCRUD_NET_6.Api.Handlers.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string? Username { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class CreateUserResponse
    {

    }

    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly ApiContext _apiContext;

        public CreateUserValidator(ApiContext apiContext)
        {
            _apiContext = apiContext;

            CascadeMode = CascadeMode.Stop;


            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username cannot be empty")
                .Matches(@"^[a-zA-Z0-9-_']*$")
                .WithMessage("Username only a-z, 0-9, @, _ and - are allowed")
                .Must(UsernameExists)
                .WithMessage("Username is used. Please use other username");

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

        private bool UsernameExists(CreateUserRequest request, string username)
        {
            if (string.IsNullOrEmpty(request.Username)) return true;

            var existsCount = _apiContext.Users.Count(x => x.Username == username);

            return existsCount == 0;
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

    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {

        private readonly ApiContext _apiContext;

        public CreateUserHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {

            var addUser = new User
            {
                Username = request.Username,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                CountryCode = request.CountryCode,
                BirthDate = request.BirthDate,
                IsActive = true
            };

            _apiContext.Users.Add(addUser);
            _apiContext.SaveChanges();


            return await Task.FromResult(new CreateUserResponse());

        }

    }
}