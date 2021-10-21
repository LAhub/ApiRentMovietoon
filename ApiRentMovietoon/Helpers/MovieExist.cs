using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApiRentMovietoon.Helpers
{
    public class MovieExist : Attribute, IAsyncResourceFilter
    {
        private readonly ApplicationDbContext Dbcontext;

        public MovieExist(ApplicationDbContext context)
        {
            this.Dbcontext = context;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context,
        ResourceExecutionDelegate next)
        {
            var userObject = context.HttpContext.Request.RouteValues["userId"];

            if (userObject == null)
            {
                return;
            }

            var userId = int.Parse(userObject.ToString());

            var existUser = await Dbcontext.Movies.AnyAsync(x => x.Id == userId);

            if (!existUser)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                await next();
            }
        }
    }
}


