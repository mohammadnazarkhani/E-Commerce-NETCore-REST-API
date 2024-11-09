using TondForoosh.Api.Entities;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Services;
using TondForoosh.Api.Data;
using System.Threading.Tasks;
using TondForoosh.Api.Mapping;

namespace TondForoosh.Api.Endpoints.Handlers
{
    public class AuthenticationHandler
    {
        private readonly IUnitOfWork _unitOfWork; // Injecting UnitOfWork to manage repositories and transactions
        private readonly IAuthService _authService;
        private readonly IPasswordHasherService _passwordHasher;

        // Constructor to inject dependencies
        public AuthenticationHandler(IUnitOfWork unitOfWork, IAuthService authService, IPasswordHasherService passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        // Handler for user registration
        public async Task<IResult> HandleRegisterAsync(RegisterUserDto registerUserDto)
        {
            // Check if the username already exists using the UserRepository from UnitOfWork
            if (await _unitOfWork.UserRepository.UserExistsAsync(registerUserDto.Username))
            {
                return Results.BadRequest("Username is already taken.");
            }

            // Convert DTO to Entity and set the default role as "User"
            User user = registerUserDto.ToEntity();

            // Hash the password before saving it to the database
            user.Password = _passwordHasher.HashPassword(registerUserDto.Password);

            // Save the new user to the database using UnitOfWork
            await _unitOfWork.UserRepository.AddAsync(user);  // Use AddAsync to insert the user
            await _unitOfWork.SaveChangesAsync(); // Ensure changes are saved

            // Generate JWT token for the newly registered user
            var token = _authService.GenerateTokenForNewUser(user);

            // Return the response with user details and token
            return Results.CreatedAtRoute(
                "RegisterUser", // This is the route name
                new { id = user.Id },
                new { user.Id, user.Username, Token = token }
            );
        }

        // Handler for user login
        public IResult HandleLogin(LoginUserDto loginUserDto)
        {
            // Use the Authenticate method to verify the user and generate a token
            var token = _authService.Authenticate(loginUserDto.Username, loginUserDto.Password);

            // If authentication fails, return Unauthorized
            if (token == null)
            {
                return Results.Unauthorized();
            }

            // Return the generated token in the response
            return Results.Ok(new { Token = token });
        }
    }
}
