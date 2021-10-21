using ApiRentMovietoon.DTOs;
using ApiRentMovietoon.Entities;
using ApiRentMovietoon.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRentMovietoon.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public BaseController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected async Task<List<TDTO>> Get<TEntidad, TDTO>() where TEntidad : class
        {
            var entidades = await context.Set<TEntidad>().AsNoTracking().ToListAsync();
            var dtos = mapper.Map<List<TDTO>>(entidades);
            return dtos;
        }

        protected async Task<ActionResult<TDTO>> Get<TEntidad, TDTO>(int id) where TEntidad : class,IId
        {
            var entity = await context.Set<TEntidad>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id );
            if(entity == null)
            {

                return NotFound();

            }
            return mapper.Map<TDTO>(entity);
        }

        protected async Task<ActionResult> Post<TCreate, TEntity, TRead>(TCreate createDTO, string nameRoute) 
            where TEntity : class, IId
        {
            var entity = mapper.Map<TEntity>(createDTO);
            context.Add(entity);
            await context.SaveChangesAsync();
            var dtoRead = mapper.Map<TRead>(entity);
            return new CreatedAtRouteResult(nameRoute, new { id = entity.Id }, dtoRead);
        }

        protected async Task<ActionResult> Put<TCreate, TEntity>
            (int id, TCreate createDto) where TEntity : class, IId
        {
            var entity = mapper.Map<TEntity>(createDto);
            entity.Id = id;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> Delete<TEntity>(int id) where TEntity : class, IId, new()
        {
            var existe = await context.Set<TEntity>().AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NoContent();
            }
            context.Remove(new TEntity() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

      

        protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginacionDTO paginacionDTO)
            where TEntidad : class
        {
            var queryable = context.Set<TEntidad>().AsQueryable();
            return await Get<TEntidad, TDTO>(paginacionDTO, queryable);
        }

        protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginacionDTO paginacionDTO,
            IQueryable<TEntidad> queryable)
            where TEntidad : class
        {
            await HttpContext.InsertarParametrosPaginacion(queryable, paginacionDTO.CantidadRegistrosPorPagina);
            var entidades = await queryable.Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<TDTO>>(entidades);
        }

      
        protected async Task<ActionResult> Patch<TEntidad, TDTO>(int id, JsonPatchDocument<TDTO> patchDocument)
            where TDTO : class
            where TEntidad : class, IId
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entidadDB = await context.Set<TEntidad>().FirstOrDefaultAsync(x => x.Id == id);

            if (entidadDB == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<TDTO>(entidadDB);

            patchDocument.ApplyTo(dto, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            var isValid = TryValidateModel(dto);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            mapper.Map(dto, entidadDB);

            await context.SaveChangesAsync();

            return NoContent();

        }

    }
}   
       
