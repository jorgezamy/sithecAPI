using Microsoft.AspNetCore.Mvc;
using sithecAPI.Models.Entities;

namespace sithecAPI.Services.interfaces
{
    public interface IHumanosService
    {
        List<Humano> GetHumanosMock();
        Task<List<Humano>> GetHumanosAsync();
        Task<Humano> GetHumanoByIdAsync(Guid id);
        Task<Humano> CreateHumanoAsync(Humano humano);
        Task<bool> UpdateHumanoByIdAsync(Guid id, Humano humano);
        Task<bool> DeleteHumanoByIdAsync(Guid id);
    }
}
