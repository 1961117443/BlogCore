﻿using Blog.Core.Model.Models;
using Blog.Core.IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Blog.Core.SqlSugarRepository.BASE;

namespace Blog.Core.SqlSugarRepository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        //private DbContext context;
        //private SqlSugarClient db;
        //private SimpleClient<Advertisement> entityDB;

        //internal SqlSugarClient Db
        //{
        //    get { return db; }
        //    private set { db = value; }
        //}

        //public DbContext Context
        //{
        //    get { return context; }
        //    set { context = value; }
        //}

        //public AdvertisementRepository()
        //{
        //    DbContext.Init(BaseDBConfig.ConnectionString);
        //    context = DbContext.GetDbContext();
        //    db = context.Db;
        //    entityDB = context.GetEntityDB<Advertisement>(db);
        //}

        //public int Add(Advertisement model)
        //{
        //    var i = db.Insertable(model).ExecuteReturnBigIdentity();
        //    return i.ObjToInt();
        //}

        //public bool Delete(Advertisement model)
        //{
        //    var i = db.Deleteable(model).ExecuteCommand();
        //    return i > 0;
        //}

        //public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        //{
        //    return entityDB.GetList(whereExpression);
        //}
        //public bool Update(Advertisement model)
        //{
        //    var i = db.Updateable(model).ExecuteCommand();
        //    return i > 0;
        //}

        //public int Sum(int i,int j)
        //{
        //    return i + j;
        //}
    }
}
