using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.AuthHelper.OverWrite;
using Blog.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {
        /// <summary>
        /// 获取JWT的重写方法，推荐这种，注意在文件夹OverWrite下
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sub">角色</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token2")]
        public JsonResult GetJWTStr(long id=1,string sub = "Admin")
        {
            TokenModelJWT tokenModel = new TokenModelJWT();
            tokenModel.Uid = id;
            tokenModel.Role = sub;
            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            return Json(jwtStr);
        }
    }
}