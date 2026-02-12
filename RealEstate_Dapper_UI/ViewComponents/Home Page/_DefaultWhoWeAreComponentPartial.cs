using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Home_Page
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        internal class WhoWeAreViewModel
        {
            public List<ResultWhoWeAreDetailDto> Detail { get; set; }
            public List<ResultWhoWeAreAdvantagesDto> Advantages { get; set; }
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage= await client.GetAsync("https://localhost:44349/api/WhoWeAreDetail");
            var responseMessage2= await client.GetAsync("https://localhost:44349/api/WhoWeAreAdvantages");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var values2= JsonConvert.DeserializeObject<List<ResultWhoWeAreAdvantagesDto>>(jsonData2);
                var model = new WhoWeAreViewModel
                {
                    Detail = values,
                    Advantages = values2
                };

                return View(model);
            }
            return View();
        }
    }
}
