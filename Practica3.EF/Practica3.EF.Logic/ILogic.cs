using System.Collections.Generic;

namespace Practica3.EF.Logic
{
    public interface ILogic<T>
    {
        bool Delete(int id);
        List<T> GetAll();
        T Insert(T value);
        T Update(T value);
    }
}
