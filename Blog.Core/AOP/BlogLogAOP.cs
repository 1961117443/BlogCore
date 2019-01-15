using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.AOP
{
    public class BlogLogAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //日志信息
            StringBuilder logData = new StringBuilder();
            var d1 = DateTime.Now;
            logData.AppendFormat("时间:{0}\r\n", d1.ToString("yyyyMMddHHmmss"));
            logData.AppendFormat("当前执行方法:{0}\r\n", invocation.Method.Name);
            logData.AppendFormat("参数是:{0}\r\n", string.Join(",", invocation.Arguments?.Select(w => (w ?? "").ToString())));  
            //继续执行当前方法
            invocation.Proceed();

            logData.AppendFormat("方法执行完毕耗时:{0}毫秒\r\n", (DateTime.Now-d1).TotalMilliseconds);
            logData.AppendFormat("返回结果:{0}\r\n", invocation.ReturnValue);
            logData.Append("==========================================================================================\r\n");

            #region 输出日志
            var path = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath + @"\Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = Path.Combine(path, $"InterceptLog-{DateTime.Now.ToString("yyyyMMdd")}.log");           
            using (StreamWriter streamWriter = File.AppendText(fileName))
            {
                streamWriter.WriteLine(logData.ToString());
                streamWriter.Close();
            }
            #endregion
        }
    }
}
