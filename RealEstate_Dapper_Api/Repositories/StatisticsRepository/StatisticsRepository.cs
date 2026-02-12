using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        public readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> ActiveCategoryCount()
        {
            const string query = "SELECT COUNT(*) FROM Category WHERE CategoryStatus = 1";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }


        public async Task<int> ActiveEmployeeCount()
        {
            const string query = "SELECT COUNT(*) FROM Employee WHERE Status = 1";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<int> ApartmentCount()
        {
            const string query = "SELECT COUNT(*) FROM Product WHERE ProductCategory=3";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<decimal> AverageProductPriceByRent()
        {
            const string query = "SELECT AVG(Price) FROM Product WHERE Type = @Type";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<decimal>(query, new { Type = "Kiralık" });
            }
        }

        public async Task<decimal> AverageProductPriceBySale()
        {
            string query = "SELECT AVG(Price) FROM Product WHERE Type = @Type";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<decimal>(query, new { Type = "Satılık" });
            }
        }

        public async Task<int> AverageRoomCount()
        {
            string query = "SELECT AVG(RoomCount) FROM ProductDetails";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<List<string>> CategoryByMaxProductCount()
        {
            string query = "WITH CategoryCounts AS (" +
                "SELECT CategoryName, COUNT(*) AS ProductCount " +
                "FROM Product " +
                "INNER JOIN Category " +
                "ON Product.ProductCategory = Category.CategoryID " +
                "GROUP BY CategoryName) " +
                "SELECT CategoryName, ProductCount " +
                "FROM CategoryCounts " +
                "WHERE ProductCount = (SELECT MAX(ProductCount) FROM CategoryCounts)";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<string>(query);
                return result.ToList();
            }
        }

        public async Task<int> CategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<int> DifferentCityCount()
        {
            string query = "SELECT COUNT(DISTINCT City) AS CityCount FROM Product";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<List<string>> EmployeeByMaxProductCount()
        {
            string query = "WITH EmployeeCounts AS ( " +
                "SELECT e.EmployeeID, e.Name, COUNT(p.ProductID) AS ProductCount " +
                "FROM Employee e " +
                "LEFT JOIN Product p " +
                "ON e.EmployeeID = p.EmployeeID " +
                "GROUP BY e.EmployeeID, e.Name) " +
                "SELECT Name, ProductCount " +
                "FROM EmployeeCounts " +
                "WHERE ProductCount = (SELECT MAX(ProductCount) FROM EmployeeCounts)";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<string>(query);
                return result.ToList();
            }
        }

        public async Task<decimal> LastProductPrice()
        {
            string query = "SELECT TOP 1 Price FROM Product ORDER BY ProductID DESC";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<decimal>(query);
            }
        }

        public async Task<List<string>> MaxCityByProductCount()
        {
            string query = "WITH CityCounts AS ( " +
                "SELECT City, COUNT(*) AS ProductCount " +
                "FROM Product " +
                "GROUP BY City) " +
                "SELECT City " +
                "FROM CityCounts " +
                "WHERE ProductCount = (SELECT MAX(ProductCount) FROM CityCounts)";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<string>(query);
                return result.ToList();
            }
        }

        public async Task<string> NewestBuildingYear()
        {
            string query = "SELECT p.Title FROM ProductDetails pd " +
                "INNER JOIN Product p ON pd.ProductID = p.ProductID " +
                "WHERE pd.BuildYear = (SELECT MAX(BuildYear) FROM ProductDetails)";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<string>(query);
            }
        }

        public async Task<string> OldestBuildingYear()
        {
            string query = "SELECT p.Title FROM ProductDetails pd " +
                            "INNER JOIN Product p ON pd.ProductID = p.ProductID " +
                            "WHERE pd.BuildYear = (SELECT MIN(BuildYear) FROM ProductDetails)";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<string>(query);
            }
        }

        public async Task<int> PassiveCategoryCount()
        {
            const string query = "SELECT COUNT(*) FROM Category WHERE CategoryStatus = 0";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task<int> ProductCount()
        {
            const string query = "SELECT COUNT(*) FROM Product";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }
    }
}
