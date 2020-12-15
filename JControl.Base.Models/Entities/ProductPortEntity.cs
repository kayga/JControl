/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Base.Models
*文件名称   ：ProductPortEntity.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/12/10 星期四 9:52:00 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/12/10 星期四 9:52:00 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JControl.Base.Models
{
    public class ProductPortEntity:BaseEntity
    {
        public string PortName { get; set; }
        public string PortKey { get; set; }

        [ForeignKey("ParentProduct")]
        public int ParentProductId { get; set; }
        public ProductEntity ParentProduct { get; set; }

        [ForeignKey("PortCateory")]
        public int PortCateoryId { get; set; }
        public PortCateoryEntity PortCateory { get; set; }

    }
}
