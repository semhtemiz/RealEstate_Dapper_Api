using Dapper;
using RealEstate_Dapper_Api.Dtos.WhoWeAreAdvantagesDtos;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreAdvantagesRepository : IWhoWeAreAdvantagesRepository
    {
        public readonly Context _context;

        public WhoWeAreAdvantagesRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreAdvantages(CreateWhoWeAreAdvantagesDto createWhoWeAreAdvantagesDto)
        {
            string query = "insert into WhoWeAreAdvantages(AdvantagesName, AdvantagesStatus) values (@advantagesName, @advantagesStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@advantagesName", createWhoWeAreAdvantagesDto.AdvantagesName);  
            parameters.Add("@advantagesStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreAdvantages(int id)
        {
            string query = "delete from WhoWeAreAdvantages Where WhoWeAreadvantagesID=@whoWeAreAdvantagesID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreAdvantagesID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreAdvantagesDto>> GetAllWhoWeAreAdvantagesAsync()
        {
            string query = "Select * From WhoWeAreAdvantages";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreAdvantagesDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreAdvantagesDto> GetWhoWeAreAdvantages(int id)
        {
            string query = "Select * from WhoWeAreAdvantages Where WhoWeAreAdvantagesID=@whoWeAreAdvantagesID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreAdvantagesID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreAdvantagesDto>(query, parameters);
                return values;

            }
        }

        public async void UpdateWhoWeAreAdvantages(UpdateWhoWeAreAdvantagesDto updateWhoWeAreAdvantagesDto)
        {
            string query = "Update WhoWeAreAdvantages Set AdvantagesName=@advantagesName, AdvantagesStatus=@advantagesStatus where AdvantagesID=@advantagesID";
            var parameters = new DynamicParameters();
            parameters.Add("@advantagesName", updateWhoWeAreAdvantagesDto.AdvantagesName);
            parameters.Add("@advantagesStatus", updateWhoWeAreAdvantagesDto.AdvantagesStatus);
            parameters.Add("@advantagesID", updateWhoWeAreAdvantagesDto.AdvantagesID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
