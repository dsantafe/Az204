using Az204.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Az204.Domain.Repositories.Implements
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly Az204Context context;
        public CustomerRepository(Az204Context context) : base(context)
        {
            this.context = context;
        }

        public new async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);

            if (customer == null)
                throw new Exception("The entity is null");

            var flag = context.Projects.Any(x => x.CustomerId == id);

            if (flag) throw new Exception("Foreign Key");

            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersByLocationAsync(string location)
        {
            var customers = await context.Customers
                .Where(x => x.Location != null && x.Location.ToLower().Contains(location.ToLower()))
                .ToListAsync();
            return customers;
        }
    }
}
