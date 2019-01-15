using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.AuthHelper.OverWrite;
using Blog.Core.Model;
using Blog.Core.Model.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Login")]
    [ApiController]
    [EnableCors("MyLimitRequests")]
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
            JWTTokenModel tokenModel = new JWTTokenModel();
            tokenModel.Uid = id;
            tokenModel.Role = sub;
            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            return Json(jwtStr);
        }

        [HttpGet]
        [Route("Token3")]
        public JsonResult GetJWTStr3(long id = 1, string sub = "Admin")
        {
            JWTTokenModel tokenModel = new JWTTokenModel();
            tokenModel.Uid = id;
            tokenModel.Role = sub;
            string jwtStr = JwtHelper.IssueJWT(tokenModel);
            return Json(jwtStr);
        }

       

        /// <summary>
        ///  
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sub">角色</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Token")]
        public JsonResult GetJWTStr2(long id = 1, string sub = "Admin")
        {
            JWTTokenModel tokenModel = new JWTTokenModel();
            tokenModel.Uid = id;
            tokenModel.Role = sub;
            string jwtStr = JwtHelper.IssueJWT(tokenModel);

            //只需在服务端添加以下两句
            //Response.Headers.Add("Access-Control-Allow-Origin", "*");
            ////跨域可以请求的方式
            //Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET");

            return Json(jwtStr);
        }


        [HttpGet]
        [Route("jsonp")]
        public string Getjsonp(string callBack, long id = 1, string sub = "Admin", int expiresSliding = 30, int expiresAbsoulute = 30)
        {
            JWTTokenModel tokenModel = new JWTTokenModel();
            tokenModel.Uid = id;
            tokenModel.Role = sub;

            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddMinutes(expiresSliding);
            DateTime d3 = d1.AddDays(expiresAbsoulute);
            TimeSpan sliding = d2 - d1;
            TimeSpan absoulute = d3 - d1;

            string jwtStr = JwtHelper.IssueJWT(tokenModel);

            //重要，一定要这么写
            string response = string.Format("\"value\":\"{0}\"", jwtStr);
            string call = callBack + "({" + response + "})";
            return call;
            // Response.WriteAsync(call);
        }
    }
}