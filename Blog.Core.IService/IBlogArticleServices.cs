using Blog.Core.IService.BASE; 
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IService
{
    public interface IBlogArticleServices : IBaseService<BlogArticle>
    {
        Task<List<BlogArticle>> getBlogs();
    }
}
