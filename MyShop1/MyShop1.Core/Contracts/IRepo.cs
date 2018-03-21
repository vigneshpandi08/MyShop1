using System;
using MyShop1.Core.Models;

namespace MyShop1.Core.Contracts
{
    public interface IRepo<T>
     where T : BaseEntity
    {
        System.Linq.IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}
