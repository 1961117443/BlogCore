using Blog.Core.Common;
using Blog.Core.IRepository;
using Blog.Core.IService;
using Blog.Core.IService.BASE;
using Blog.Core.Model.Models;
using Blog.Core.Service.BASE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Service
{
    public class BlogArticleServices : BaseService<BlogArticle>, IBlogArticleServices
    { 
        public BlogArticleServices(IBlogArticleRepository blogArticleRepository)
        {
            this.baseDal = blogArticleRepository;
        }
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        
        public async Task<List<BlogArticle>> getBlogs()
        {
            return await this.baseDal.Query(a => a.bID > 0, a => a.bID);
        }
    }
}
