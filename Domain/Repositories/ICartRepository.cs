using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(Guid id);
    }
}
