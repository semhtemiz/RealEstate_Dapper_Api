using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
        {
            var result = await _statisticsRepository.ActiveCategoryCount();
            return Ok(result);
        }
        [HttpGet("ActiveEmployeeCount")]
        public async Task<IActionResult> ActiveEmployeeCount()
        {
            var result = await _statisticsRepository.ActiveEmployeeCount();
            return Ok(result);
        }
        [HttpGet("ApartmentCount")]
        public async Task<IActionResult> ApartmentCount()
        {
            var result = await _statisticsRepository.ApartmentCount();
            return Ok(result);
        }
        [HttpGet("AverageProductPriceByRent")]
        public async Task<IActionResult> AverageProductPriceByRent()
        {
            var result = await _statisticsRepository.AverageProductPriceByRent();
            return Ok(result);
        }
        [HttpGet("AverageProductPriceBySale")]
        public async Task<IActionResult> AverageProductPriceBySale()
        {
            var result = await _statisticsRepository.AverageProductPriceBySale();
            return Ok(result);
        }
        [HttpGet("AverageRoomCount")]
        public async Task<IActionResult> AverageRoomCount()
        {
            var result = await _statisticsRepository.AverageRoomCount();
            return Ok(result);
        }
        [HttpGet("CategoryByMaxProductCount")]
        public async Task<IActionResult> CategoryByMaxProductCount()
        {
            var result = await _statisticsRepository.CategoryByMaxProductCount();
            return Ok(result);
        }
        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            var result = await _statisticsRepository.CategoryCount();
            return Ok(result);
        }
        [HttpGet("DifferentCityCount")]
        public async Task<IActionResult> DifferentCityCount()
        {
            var result = await _statisticsRepository.DifferentCityCount();
            return Ok(result);
        }
        [HttpGet("EmployeeByMaxProductCount")]
        public async Task<IActionResult> EmployeeByMaxProductCount()
        {
            var result = await _statisticsRepository.EmployeeByMaxProductCount();
            return Ok(result);
        }
        [HttpGet("LastProductPrice")]
        public async Task<IActionResult> LastProductPrice()
        {
            var result = await _statisticsRepository.LastProductPrice();
            return Ok(result);
        }
        [HttpGet("MaxCityByProductCount")]
        public async Task<IActionResult> MaxCityByProductCount()
        {
            var result = await _statisticsRepository.MaxCityByProductCount();
            return Ok(result);
        }
        [HttpGet("NewestBuildingYear")]
        public async Task<IActionResult> NewestBuildingYear()
        {
            var result = await _statisticsRepository.NewestBuildingYear();
            return Ok(result);
        }
        [HttpGet("OldestBuildingYear")]
        public async Task<IActionResult> OldestBuildingYear()
        {
            var result = await _statisticsRepository.OldestBuildingYear();
            return Ok(result);
        }
        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
        {
            var result = await _statisticsRepository.PassiveCategoryCount();
            return Ok(result);
        }
        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            var result = await _statisticsRepository.ProductCount();
            return Ok(result);
        }
    }
}
