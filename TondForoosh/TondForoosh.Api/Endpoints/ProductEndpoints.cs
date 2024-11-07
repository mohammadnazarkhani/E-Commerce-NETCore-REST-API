using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Services;
using TondForoosh.Api.Data;
using TondForoosh.Api.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace TondForoosh.Api.Endpoints
{
    public static class ProductEndpoints
    {
        const string ProductEndpointGroupName = "Products";

        public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(ProductEndpointGroupName)
                .WithParameterValidation();

            return group;
        }
    }
}
