using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext context;

        public CartRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> AddAsync(Cart cart)
        {
            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
            return cart.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var cart = context.Carts.FirstOrDefault(x => x.Id == id);
            if (cart != null)
            {
                context.Carts.Remove(cart);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await context.Carts.ToListAsync();
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            return await context.Carts.FindAsync(id);
        }

        public async Task UpdateAsync(Cart cart)
        {
            context.Entry(cart).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
