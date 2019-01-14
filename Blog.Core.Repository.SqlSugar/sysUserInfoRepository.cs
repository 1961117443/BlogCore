using Blog.Core.IRepository;
using Blog.Core.SqlSugarRepository.BASE;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.SqlSugarRepository
{
    public class sysUserInfoRepository : BaseRepository<sysUserInfo>, IsysUserInfoRepository
    {
    }
}
