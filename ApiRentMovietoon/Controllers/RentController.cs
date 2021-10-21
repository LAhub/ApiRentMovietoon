using ApiRentMovietoon.DTOs;
using ApiRentMovietoon.Entities;
using ApiRentMovietoon.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiRentMovietoon.Controllers
{
    [Route("api/rent")]
    [ServiceFilter(typeof(MovieExist))]
    public class RentController : BaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public RentController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Post(int userId, [FromBody] RentCreateDTO rentCreacionDTO)
        {
            var rent = mapper.Map<Rent>(rentCreacionDTO);
            rent.UserId = userId;

            context.Add(rent);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
