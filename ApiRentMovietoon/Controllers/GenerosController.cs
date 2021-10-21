using ApiRentMovietoon.DTOs;
using ApiRentMovietoon.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRentMovietoon.Controllers
{[ApiController]
    [Route("api/gener")]
    public class GenerosController : BaseController
    {
        public GenerosController(ApplicationDbContext context, IMapper mapper): base(context,mapper)
        {
           
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            return await Get<Gener, GeneroDTO>();
        }

        [HttpGet("{id:int}", Name = "GetGener")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            return await Get<Gener,GeneroDTO>(id);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenerCreateDTO generCreateDTO)
        {
            return await Post<GenerCreateDTO,Gener, GeneroDTO>(generCreateDTO, "GetGener");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenerCreateDTO generCreateDTO)
        {
            return await Put<GenerCreateDTO, Gener>(id, generCreateDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Gener>(id);
        }

    }
}
