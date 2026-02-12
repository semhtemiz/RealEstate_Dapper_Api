using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var apiEndpoints = new Dictionary<string, string>
            {
                ["CategoryCount"] = "Statistics/CategoryCount",
                ["ActiveCategoryCount"] = "Statistics/ActiveCategoryCount",
                ["PassiveCategoryCount"] = "Statistics/PassiveCategoryCount",
                ["ProductCount"] = "Statistics/ProductCount",
                ["ApartmentCount"] = "Statistics/ApartmentCount",
                ["EmployeeByMaxProductCount"] = "Statistics/EmployeeByMaxProductCount",
                ["CategoryByMaxProductCount"] = "Statistics/CategoryByMaxProductCount",
                ["AverageProductPriceByRent"] = "Statistics/AverageProductPriceByRent",
                ["AverageProductPriceBySale"] = "Statistics/AverageProductPriceBySale",
                ["MaxCityByProductCount"] = "Statistics/MaxCityByProductCount",
                ["DifferentCityCount"] = "Statistics/DifferentCityCount",
                ["LastProductPrice"] = "Statistics/LastProductPrice",
                ["NewestBuildingYear"] = "Statistics/NewestBuildingYear",
                ["OldestBuildingYear"] = "Statistics/OldestBuildingYear",
                ["AverageRoomCount"] = "Statistics/AverageRoomCount",
                ["ActiveEmployeeCount"] = "Statistics/ActiveEmployeeCount"
            };

            var client = _httpClientFactory.CreateClient();

            foreach (var endpoint in apiEndpoints)
            {
                var responseMessage = await client.GetAsync($"https://localhost:44349/api/{endpoint.Value}");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewData[endpoint.Key] = jsonData;
            }
            return View();
        }
    }
}
