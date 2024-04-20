using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Services.Repositories;

public interface IGenericRepositoryAsync<T> where T : BaseEntity
{
    Task<List<T>> GetAsync();

    Task<T?> GetAsync(string id);

    Task CreateAsync(T entity);

    Task UpdateAsync(string id, T updatedEntity);

    Task RemoveAsync(string id);
}