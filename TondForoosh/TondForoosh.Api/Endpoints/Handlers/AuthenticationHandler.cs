using TondForoosh.Api.Entities;
using TondForoosh.Api.Services;
using TondForoosh.Api.Data;
using System.Threading.Tasks;
using TondForoosh.Api.Mapping;
using TondForoosh.Api.Dtos.User;

namespace TondForoosh.Api.Endpoints.Handlers
{
    public class AuthenticationHandler
    {
        private readonly IUnitOfWork _unitOfWork; // Managing repository and transactions
        private readonly IAuthService _authService;
        private readonly IPasswordHasherService _passwordHasher;

        // Constructor for dependency injection
        public AuthenticationHandler(IUnitOfWork unitOfWork, IAuthService authService, IPasswordHasherService passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        // Method for user registration
        public async Task<IResult> HandleRegisterAsync(RegisterUserDto registerUserDto)
        {
            // Check if the username already exists
            if (await _unitOfWork.UserRepository.UserExistsAsync(registerUserDto.Username))
            {
                return Results.BadRequest("Username is already taken.");
            }

            // Convert DTO to Entity and set user role to "User"
            User user = registerUserDto.ToEntity();
            user.Password = _passwordHasher.HashPassword(registerUserDto.Password); // Hashing the password

            // Save the new user to the database
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // Generate JWT token for the registered user
            var token = _authService.GenerateTokenForNewUser(user);

            // Return response with user details and token
            return Results.CreatedAtRoute(
                "RegisterUser",
                new { id = user.Id },
                new { user.Id, user.Username, Token = token }
            );
        }

        // Method for user login
        public IResult HandleLogin(LoginUserDto loginUserDto)
        {
            // Authenticate the user and generate a token
            var token = _authService.Authenticate(loginUserDto.Username, loginUserDto.Password);

            // If authentication fails
            if (token == null)
            {
                return Results.Unauthorized();
            }

            // Return the token
            return Results.Ok(new { Token = token });
        }
    }
}
