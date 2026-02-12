namespace RealEstate_Dapper_Api.Repositories.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<int> CategoryCount();
        Task<int> ActiveCategoryCount();
        Task<int> PassiveCategoryCount();
        Task<int> ProductCount();
        Task<int> ApartmentCount();
        Task<List<string>> EmployeeByMaxProductCount();
        Task<List<string>> CategoryByMaxProductCount();
        Task<decimal> AverageProductPriceByRent();
        Task<decimal> AverageProductPriceBySale();
        Task<List<string>> MaxCityByProductCount();
        Task<int> DifferentCityCount();
        Task<decimal> LastProductPrice();
        Task<string> NewestBuildingYear();
        Task<string> OldestBuildingYear();
        Task<int> AverageRoomCount();
        Task<int> ActiveEmployeeCount();
    }
}
