using System;

namespace FitTakip.Application.Interfaces.Repositories;

public interface IRepository<T>
{
    Task CreateAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int Id);
    Task UpdateAsync(T entity);
}
