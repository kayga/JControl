/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Base.BLL
*文件名称   ：ObjectExtend.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/25 星期三 12:38:52 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/25 星期三 12:38:52 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public static class ObjectExtend
    {


        /// <summary>
        /// 判断两个相同引用类型的对象的属性值是否相等
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <typeparam name="M"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static D Mapper<D, M>(M model)
        {
            D dto = Activator.CreateInstance<D>();
            var modelType = model.GetType();
            var dtoType = typeof(D);
            foreach (PropertyInfo sP in modelType.GetProperties())
            {
                foreach (PropertyInfo dP in dtoType.GetProperties())
                {
                    try
                    {
                        if (dP.Name == sP.Name)
                        {
                             dP.SetValue(dto, sP.GetValue(model));
                             break;
                        
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                }
            }
            return dto;
        }        
    }
}
