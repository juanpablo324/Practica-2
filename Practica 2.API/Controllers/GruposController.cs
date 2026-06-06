using AutoMapper;
using Ein.DTOS;
using EIN.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_2.DATA.DataContext;

namespace Practica_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;

        public GruposController(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Listar() 
        {
            var lista = await _context.Grupos
                .Include(x=> x.Generacion)
                .Select(x => _mapper.Map<GrupoGetDto>(x))
                .ToListAsync();
            return Ok(lista);
        }

        [HttpPost]

        public async Task<IActionResult> Guardar (GrupoSetDto newObj)

        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var obj = _mapper.Map<GrupoEntity>(newObj);
                await _context.Grupos.AddAsync(obj);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Listar), newObj);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
