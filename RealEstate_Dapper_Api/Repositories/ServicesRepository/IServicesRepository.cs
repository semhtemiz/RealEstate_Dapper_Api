using RealEstate_Dapper_Api.Dtos.ServicesDtos;

namespace RealEstate_Dapper_Api.Repositories.ServicesRepository
{
    public interface IServicesRepository
    {
        Task<List<ResultServicesDto>> GetAllServicesAsync();
        void CreateServices(CreateServicesDto createServicesDto);
        void DeleteServices(int id);
        void UpdateServices(UpdateServicesDto updateServicesDto);
        Task<GetByIDServicesDto> GetServices(int id);
    }
}
