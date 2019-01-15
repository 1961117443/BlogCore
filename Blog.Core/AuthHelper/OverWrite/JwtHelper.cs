using Blog.Core.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.AuthHelper.OverWrite
{
    public class JwtHelper
    {
        public static string secretKey { get; set; } = "TThvj8G5jb6GcTFZmxVwh5Cj";

        /// <summary>
        /// 颁发jwt字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string IssueJWT(JWTTokenModel tokenModel)
        {
            var datetime = DateTime.UtcNow;
            //var claims = new Claim[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),
            //    new Claim("Role",tokenModel.Role),
            //    new Claim(JwtRegisteredClaimNames.Iat,datetime.ToString(),ClaimValueTypes.Integer64)
            //};
            var claims = new Claim[]
                {
                    //下边为Claim的默认配置
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                //这个就是过期时间，目前是过期100秒，可自定义，注意JWT有自己的缓冲过期时间
                new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(10)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Iss,"Blog.Core"),
                new Claim(JwtRegisteredClaimNames.Aud,"wr"),
                //这个Role是官方UseAuthentication要要验证的Role，我们就不用手动设置Role这个属性了
                new Claim(ClaimTypes.Role,tokenModel.Role),
               };

            //秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtHelper.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "Blog.Core",
                claims: claims, //声明集合
              //  expires: datetime.AddHours(2),
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);

            return encodedJwt;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr">jwt字符串</param>
        /// <returns>jwt载体</returns>
        public static JWTTokenModel SerializeJWT(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role = new object(); ;
            try
            {
                jwtToken.Payload.TryGetValue("Role", out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new JWTTokenModel
            {
                Uid = (jwtToken.Id).ObjToInt(),
                Role = role != null ? role.ObjToString() : "",
            };
            return tm;
        }
    }
}
