using Microsoft.AspNetCore.Mvc;
namespace Practica_2.API.Controllers;
using AutoMapper;
using Ein.DTOS;
using EIN.Entidades;
using Microsoft.EntityFrameworkCore;
using Practica_2.DATA.AutoMapper;
using Practica_2.DATA.DataContext;

[Route("api/[controller]")]
[ApiController]
public class GeneracionesController : ControllerBase
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public GeneracionesController(BaseContext conext, IMapper mapper)
    {  _context = conext;
        _mapper = mapper;

    }

    [HttpGet]
    public  async Task<IActionResult> Listar()
    {

        try
        {
            var generaciones = await _context.Generaciones
            .Where(x=> x.EstaActivo==true)
            .Select(x => _mapper.Map<GeneracionGetDTO>(x))
            .ToListAsync();
            if (generaciones == null || generaciones.Count == 0)
                return NoContent();

            return Ok(generaciones);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GeneracionSetDTO newObj)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var obj = _mapper.Map<GeneracionEntity>(newObj);
            await _context.Generaciones.AddAsync(obj);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Listar), newObj);

        }

        catch  (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try 
        {
            var generacion = await _context.Generaciones.FindAsync(id);
            if (generacion == null)
                return NotFound();
            //_context.Generaciones.Remove(generacion);
            generacion.EstaActivo = false;
            _context.Generaciones.Update(generacion);
            await _context.SaveChangesAsync();

            return Ok("Generacion eliminada correctamente");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GeneracionSetDTO updateObj)
    {

        try
        {
            if (ModelState.IsValid)
                return BadRequest();
            var generacion = await _context.Generaciones.Where(x=> x.Id==id && x.EstaActivo).FirstOrDefaultAsync();

            if (generacion == null)
                return NotFound();

            generacion.Nombre = updateObj.Nombre;

            _context.Generaciones.Update(generacion);
            _context.SaveChangesAsync();
            return Ok("Generacion actualizada correctamente");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody] GeneracionEntity updateObj)
    {
        return Ok("Generacion actualizada parcialmente correctamente");

    }

}
