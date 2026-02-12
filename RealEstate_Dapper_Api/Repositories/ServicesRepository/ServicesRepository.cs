using Dapper;
using RealEstate_Dapper_Api.Dtos.ServicesDtos;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServicesRepository
{
    public class ServicesRepository : IServicesRepository
    {
        
        public readonly Context _context;

        public ServicesRepository(Context context)
        {
            _context = context;
        }
        public async void CreateServices(CreateServicesDto createServicesDto)
        {
            string query = "insert into Services(Icon,Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createServicesDto.Icon);
            parameters.Add("@title", createServicesDto.Title);
            parameters.Add("@description", createServicesDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteServices(int id)
        {
            string query = "delete from Services Where ServicesID=@servicesID";
            var parameters = new DynamicParameters();
            parameters.Add("@servicesID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServicesDto>> GetAllServicesAsync()
        {
            string query = "Select * From Services";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServicesDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDServicesDto> GetServices(int id)
        {
            string query = "Select * from Services Where ServicesID=@servicesID";
            var parameters = new DynamicParameters();
            parameters.Add("@servicesID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDServicesDto>(query, parameters);
                return values;

            }
        }

        public async void UpdateServices(UpdateServicesDto updateServicesDto)
        {
            string query = "Update Services Set Icon=@icon, Title=@title, Description=@description where ServicesID=@servicesID";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateServicesDto.Icon);
            parameters.Add("@title", updateServicesDto.Title);
            parameters.Add("@description", updateServicesDto.Description);
            parameters.Add("@servicesID", updateServicesDto.ServicesID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
