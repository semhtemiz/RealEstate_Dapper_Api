using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var apiEndpoints = new Dictionary<string, string>
            {
                ["ProductCount"] = "Statistics/ProductCount",
                ["EmployeeByMaxProductCount"] = "Statistics/EmployeeByMaxProductCount",
                ["CategoryByMaxProductCount"] = "Statistics/CategoryByMaxProductCount",
                ["DifferentCityCount"] = "Statistics/DifferentCityCount"
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
