/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Base.Models
*文件名称   ：PortCateoryEntity.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/12/10 星期四 9:11:53 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/12/10 星期四 9:11:53 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace JControl.Base.Models
{
    public class PortCateoryEntity:BaseEntity
    {
        public PortCateoryEntity()
        {
            ProductPorts = new List<ProductPortEntity>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }

        public string Code { get; set; }

        public int Value { get; set; }

        public IList<ProductPortEntity> ProductPorts { get; set; }
    }
}
