using ApiRentMovietoon.DTOs;
using ApiRentMovietoon.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRentMovietoon.Controllers
{[ApiController]
    [Route("api/gender")]
    public class GenerosController : BaseController
    {
        public GenerosController(ApplicationDbContext context, IMapper mapper): base(context,mapper)
        {
           
        }

        [HttpGet]
        public async Task<ActionResult<List<GenderDTO>>> Get()
        {
            return await Get<Gender, GenderDTO>();
        }

        [HttpGet("{id:int}", Name = "GetGender")]
        public async Task<ActionResult<GenderDTO>> Get(int id)
        {
            return await Get<Gender,GenderDTO>(id);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenderCreateDTO generCreateDTO)
        {
            return await Post<GenderCreateDTO,Gender, GenderDTO>(generCreateDTO, "GetGender");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenderCreateDTO generCreateDTO)
        {
            return await Put<GenderCreateDTO, Gender>(id, generCreateDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Gender>(id);
        }

    }
}
