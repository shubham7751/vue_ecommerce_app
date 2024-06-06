

namespace webapi.Services.ProductServices
{
    public interface IProductRepository<T>
    {
        bool Exists(string imageURL);
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);

    }
}

