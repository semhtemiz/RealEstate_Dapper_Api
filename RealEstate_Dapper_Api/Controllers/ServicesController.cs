using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServicesDtos;
using RealEstate_Dapper_Api.Repositories.ServicesRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesRepository _servicesRepository;

        public ServicesController(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreAdvantagesList()
        {
            var values = await _servicesRepository.GetAllServicesAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServices(CreateServicesDto createServicesDto)
        {
            _servicesRepository.CreateServices(createServicesDto);
            return Ok("Servisler Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteServices(int id)
        {
            _servicesRepository.DeleteServices(id);
            return Ok("Servisler Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServices(UpdateServicesDto updateServicesDto)
        {
            _servicesRepository.UpdateServices(updateServicesDto);
            return Ok("Servisler Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIDServices(int id)
        {
            var value = await _servicesRepository.GetServices(id);
            return Ok(value);
        }
    }
}
