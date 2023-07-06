using ECommerce.Data;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //protected readonly IDBHelper _dbhelper;
        protected readonly IConfiguration _configuration;
        protected readonly ApplicationDbContext _context;
        private DbSet<T> _entitySet;

        public GenericRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _entitySet = _context.Set<T>();
            _configuration = configuration;
        }

        public async Task Add(T entity)
        {
            await _entitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            T entidad = await _entitySet.FindAsync(id);
            _entitySet.Remove(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _entitySet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entitySet.ToListAsync();
        }

        public void Update(T entity)
        {
            _entitySet.Update(entity);
            _context.SaveChanges();
        }

        //public async Task<List<T>> ExecuteStoreProcedure<T>(
        //       string procedure,
        //       List<ExecuteParameter> objectParameters
        //       )
        //{
        //    var cnn = _configuration.GetConnectionString("DefaultConnection");
        //    return await _dbhelper.ExcecuteStoreProcedure<T>(procedure, objectParameters, cnn);
        //}
    }
}
