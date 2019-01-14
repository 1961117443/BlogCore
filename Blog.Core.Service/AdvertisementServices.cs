using Blog.Core.IService;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Blog.Core.IRepository;
using Blog.Core.SqlSugarRepository;
using Blog.Core.Service.BASE;

namespace Blog.Core.Service
{
    public class AdvertisementServices : BaseService<Advertisement>, IAdvertisementServices
    {
        //public IAdvertisementRepository dal = new AdvertisementRepository();

        //public async int Add(Advertisement model)
        //{
        //    return a dal.Add(model);
        //}

        //public bool Delete(Advertisement model)
        //{
        //    return dal.Delete(model);
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    return dal.Query(whereExpression);
        //}

        //public int Sum(int i, int j)
        //{
        //    return dal.Sum(i, j);
        //}

        //public bool Update(Advertisement model)
        //{
        //    return dal.Update(model);
        //}
    }
}
