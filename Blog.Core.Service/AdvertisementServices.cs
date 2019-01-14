using Blog.Core.IService;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Blog.Core.IRepository; 
using Blog.Core.Service.BASE;

namespace Blog.Core.Service
{
    public class AdvertisementServices : BaseService<Advertisement>, IAdvertisementServices
    {
        protected readonly IAdvertisementRepository dal;
        public AdvertisementServices(IAdvertisementRepository advertisementRepository)
        {
            dal = advertisementRepository;
            baseDal = dal;
        } 
    }
}
