using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
