using System.Linq.Expressions;
using LeaderBoardAPI.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace LeaderBoardAPI.Repositories.Abstract;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> Get(int id);
    IQueryable<T> GetAll();
    Task Add(T entity);
    Task Delete(int id);
    Task Update(T entity);
}