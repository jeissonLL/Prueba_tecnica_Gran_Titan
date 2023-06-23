using AutoMapper;
using BE_CRUDMascotas.models;
using BE_CRUDMascotas.models.DTO;
using BE_CRUDMascotas.models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_CRUDMascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMascotasRepository _mascotasRepository;

        public MascotaController(IMapper mapper, IMascotasRepository mascotasRepository)
        {
            _mapper = mapper;
            _mascotasRepository = mascotasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listMascotas = await _mascotasRepository.GetListMascotas();
                var listMascotasDTO = _mapper.Map<IEnumerable<MascotaDTO>>(listMascotas);
                
                return Ok(listMascotasDTO);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mascota = await _mascotasRepository.GetMascota(id);
                if (mascota == null)
                {
                    return NotFound();
                }

                var mascotaDTO = _mapper.Map<MascotaDTO>(mascota);

                return Ok(mascotaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mascota = await _mascotasRepository.GetMascota(id);
                if (mascota == null)
                {
                    return NotFound();
                }

                await _mascotasRepository.deleteMascota(mascota);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MascotaDTO mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);
                mascota = await _mascotasRepository.AddMascota(mascota);

                var mascotaItemDTO = _mapper.Map<MascotaDTO>(mascota);

                return CreatedAtAction("Get", new {Id = mascotaItemDTO.Id }, mascotaItemDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MascotaDTO mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);

                if (id != mascota.Id)
                {
                    return BadRequest();
                }

                var mascotasItem = await _mascotasRepository.GetMascota(id);

                if (mascotasItem == null) 
                {
                    return NotFound();
                }

                await _mascotasRepository.UpdateMascota(mascota);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
