using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using youtubeAPI.DataStore;
using youtubeAPI.Modelos;
using youtubeAPI.Modelos.Dto.Empresa;

namespace youtubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<EmpresaDto>> GetEmpresas()
        {
            //return new List<EmpresaDto>
            //{
            //    new EmpresaDto{ Id= 1, Nombre="Televisa" },
            //    new EmpresaDto{ Id= 2, Nombre="PROSA" },
            //    new EmpresaDto{ Id= 3, Nombre="PEMEX" }
            //};

            return Ok(EmpresaStore.EmpresaList);
        }

        [HttpGet("Id:int", Name = "GetEmpresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmpresaDto> GetEmpresa(int id)
        {
            //return Ok(EmpresaStore.EmpresaList.FirstOrDefault(e => e.Id == id));

            if(id == 0)
            {
                return BadRequest();
            }
            var Empresa = EmpresaStore.EmpresaList.FirstOrDefault(e => e.Id == id);
            if(Empresa == null)
            {
                return NotFound();
            }
            return Ok(Empresa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EmpresaDto> CrearEmpresa([FromBody] EmpresaDto empresaDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(EmpresaStore.EmpresaList.FirstOrDefault(e=>e.Nombre.ToLower() == empresaDto.Nombre.ToLower())!=null)
            {
                ModelState.AddModelError("NombreExiste", "La empresa ya existe...");
                return BadRequest(ModelState);
            }
            if (empresaDto == null)
            {
                return BadRequest(empresaDto);
            }
            if(empresaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            empresaDto.Id=EmpresaStore.EmpresaList.OrderByDescending(e=> e.Id).FirstOrDefault().Id +1;
            EmpresaStore.EmpresaList.Add(empresaDto);
            //return Ok(empresaDto);
            return CreatedAtRoute("GetEmpresa", new { id = empresaDto.Id }, empresaDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteEmpresa(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var empresa = EmpresaStore.EmpresaList.FirstOrDefault(e=>e.Id ==id);

            if (empresa == null) 
            {
                return NotFound();
            }
            EmpresaStore.EmpresaList.Remove(empresa);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmpresa(int id, [FromBody] EmpresaDto empresaDto)
        {
            if(empresaDto==null || id != empresaDto.Id)
            {
                return BadRequest();
            }
            var depto = EmpresaStore.EmpresaList.FirstOrDefault(e=>e.Id==id);
            depto.Nombre = empresaDto.Nombre;
            depto.Ocupantes = empresaDto.Ocupantes;
            depto.Metros = empresaDto.Metros;

            return CreatedAtRoute("GetEmpresa", new { id = empresaDto.Id }, empresaDto);
        }   

    }
}
