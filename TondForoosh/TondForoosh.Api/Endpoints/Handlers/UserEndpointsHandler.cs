using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TondForoosh.Api.Data;
using TondForoosh.Api.Dtos.User;
using TondForoosh.Api.Mapping;
using TondForoosh.Api.Services;

namespace TondForoosh.Api.Endpoints.Handlers
{
    public class UserEndpointsHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public UserEndpointsHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<IResult> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return Results.Ok(users.Select(u => u.ToDto()));
        }

        public async Task<IResult> GetUserProfileAsync()
        {
            var currentUser = _authService.GetCurrentUser();
            if (currentUser == null)
                return Results.Unauthorized();

            var user = await _unitOfWork.UserRepository.GetByIdAsync(currentUser.Id);
            return user is not null ? Results.Ok(user.ToDto()) : Results.NotFound();
        }

        public async Task<IResult> CreateUserAsync(CreateUserDto dto)
        {
            var user = dto.ToEntity();
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return Results.Created($"/users/{user.Id}", user.ToDto());
        }

        public async Task<IResult> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null) return Results.NotFound();

            user = user.UpdateEntity(dto);
            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return Results.NoContent();
        }

        public async Task<IResult> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null) return Results.NotFound();

            await _unitOfWork.UserRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}
