using System.Linq.Expressions;
using LeaderBoardAPI.Entities;
using LeaderBoardAPI.Helpers;
using LeaderBoardAPI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace LeaderBoardAPI.Repositories.Concrete;

public class Repository<T> : IRepository<T> where T: BaseEntity
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();

    public async Task<T> Get(int id)
    {
        var query = Table.AsQueryable();
        return await query.FirstOrDefaultAsync(i => i.Id == id);
    }

    public IQueryable<T> GetAll()
    {
        var query = Table.AsQueryable();
        return query;
    }

    public async Task Add(T entity)
    {
        Table.Add(entity);
        await _context.SaveChangesAsync();
    }

   

    public async Task Delete(int id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
        Table.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        EntityEntry entry = Table.Update(entity);
        await _context.SaveChangesAsync();
    }
}