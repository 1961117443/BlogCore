using Blog.Core.IService;
using Blog.Core.IService.BASE; 
using Blog.Core.Model.Models;
using Blog.Core.Service.BASE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Service
{
    public class GuestbookServices  : BaseService<Guestbook>, IGuestbookServices
    {
    }
}
