using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreAdvantagesDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreAdvantagesController : ControllerBase
    {
        private readonly IWhoWeAreAdvantagesRepository _whoWeAreAdvantagesRepository;

        public WhoWeAreAdvantagesController(IWhoWeAreAdvantagesRepository whoWeAreAdvantagesRepository)
        {
            _whoWeAreAdvantagesRepository = whoWeAreAdvantagesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreAdvantagesList()
        {
            var values = await _whoWeAreAdvantagesRepository.GetAllWhoWeAreAdvantagesAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreAdvantages(CreateWhoWeAreAdvantagesDto createWhoWeAreAdvantagesDto)
        {
            _whoWeAreAdvantagesRepository.CreateWhoWeAreAdvantages(createWhoWeAreAdvantagesDto);
            return Ok("Avantajlar Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAreAdvantages(int id)
        {
            _whoWeAreAdvantagesRepository.DeleteWhoWeAreAdvantages(id);
            return Ok("Avantajlar Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreAdvantages(UpdateWhoWeAreAdvantagesDto updateWhoWeAreAdvantagesDto)
        {
            _whoWeAreAdvantagesRepository.UpdateWhoWeAreAdvantages(updateWhoWeAreAdvantagesDto);
            return Ok("Avantajlar Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIDWhoWeAreAdvantages(int id)
        {
            var value = await _whoWeAreAdvantagesRepository.GetWhoWeAreAdvantages(id);
            return Ok(value);
        }
    }
}
