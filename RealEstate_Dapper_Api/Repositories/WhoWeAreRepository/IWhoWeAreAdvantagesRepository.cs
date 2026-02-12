using RealEstate_Dapper_Api.Dtos.WhoWeAreAdvantagesDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreAdvantagesRepository
    {
        Task<List<ResultWhoWeAreAdvantagesDto>> GetAllWhoWeAreAdvantagesAsync();

        void CreateWhoWeAreAdvantages(CreateWhoWeAreAdvantagesDto createWhoWeAreAdvantagesDto);
        void DeleteWhoWeAreAdvantages(int id);
        void UpdateWhoWeAreAdvantages(UpdateWhoWeAreAdvantagesDto updateWhoWeAreAdvantagesDto);
        Task<GetByIDWhoWeAreAdvantagesDto> GetWhoWeAreAdvantages(int id);
    }
}
