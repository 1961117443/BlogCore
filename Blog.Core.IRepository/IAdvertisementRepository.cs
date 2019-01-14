using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Core.IRepository.BASE;
using Blog.Core.Model.Models;

namespace Blog.Core.IRepository
{
    public interface IAdvertisementRepository : IBaseRepository<Advertisement>
    {
        //int Add(Advertisement model);
        //bool Delete(Advertisement model);
        //List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression);
        //int Sum(int i, int j);
        //bool Update(Advertisement model);
    }
}