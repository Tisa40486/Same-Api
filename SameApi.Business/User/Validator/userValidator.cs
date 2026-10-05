using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SameApi.Business.User.Command;
using SameApi.Db.DbContexts;
using System.Text.RegularExpressions;

public class UserValidator : AbstractValidator<CreateUserCommand>
{
    private readonly SameApiDbContext _context;

    public UserValidator(SameApiDbContext context)
    {
        _context = context;

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .Matches("^[a-zA-Z]+.[a-zA-Z]+@eduge.ch$")
            .MustAsync(async (dto, email, _) =>
            {
                return !await _context.Users
                    .AnyAsync(u => u.Email == email);
            })
            .WithMessage("Someone else already uses this email");

        RuleFor(x => x.Birthdate)
            .NotEmpty().WithMessage("Birthdate is required")
             .Must(birthdate =>
             {
                 var today = DateTime.Today;
                 var age = today.Year - birthdate.Value.Year;

                 if (birthdate.Value.Date > today.AddYears(-age))
                     age--;

                 return age >= 13;
             })
            .WithMessage("You must be at least 13 years old");

        RuleFor(x => x.Password)
     .NotEmpty().WithMessage("Password is required")
     .MinimumLength(16).WithMessage("Password must be at least 16 characters")
     .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter")
     .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter")
     .Matches(@"\d+").WithMessage("Password must contain at least one number")
     .Matches(@"[!@#$%^&*(),.?""':{}|<>]+").WithMessage("Password must contain at least one special character")
     .Must((dto, pw) => !new[] { dto.Pseudo, dto.FirstName, dto.LastName, dto.Email, dto.Birthdate.ToString() }
         .Any(s => !string.IsNullOrEmpty(s) && pw.Contains(s))).WithMessage("Password cannot contain your personal info")
     .Must(pw => !Regex.IsMatch(pw, @"(.)\1\1")).WithMessage("Password cannot contain consecutive repeated characters")
     .Must(pw => !pw.Contains(" ")).WithMessage("Password cannot contain spaces");

        RuleFor(x => x.Pseudo)
     .NotEmpty().WithMessage("Pseudo is required")
     .MinimumLength(3).WithMessage("Pseudo must be at least 3 characters")
     .MaximumLength(20).WithMessage("Pseudo must be at most 20 characters")
     .Matches(@"^[a-zA-Z0-9_-]+$").WithMessage("Pseudo can only contain letters, numbers, _ and -")
     .Must(pseudo => !pseudo.Contains(" ")).WithMessage("Pseudo cannot contain spaces")
     .Must(pseudo => !pseudo.Contains("--") && !pseudo.Contains("__") && !pseudo.Contains("-_") && !pseudo.Contains("_-"))
         .WithMessage("Pseudo cannot contain consecutive special characters")
     .Must(pseudo => pseudo.Any(char.IsLetter)).WithMessage("Pseudo must contain at least one letter")
     .Must(pseudo => !new[] { "admin", "root", "support" }
         .Any(reserved => pseudo.ToLower().Contains(reserved)))
         .WithMessage("Pseudo cannot contain reserved words like 'admin', 'root', 'support'")
     .Must(pseudo => !pseudo.All(char.IsDigit)).WithMessage("Pseudo cannot be all numbers")
     .MustAsync(async (dto, pseudo, _) =>
     {
         return !await _context.Users
             .AnyAsync(u => u.Pseudo == pseudo);
     }).WithMessage("Someone else already uses this pseudo");
    }
}