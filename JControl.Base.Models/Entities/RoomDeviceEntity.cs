/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControler.Entities
*文件名称   ：RoomDeviceEntity.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/20 星期五 10:32:30 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/20 星期五 10:32:30 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JControl.Base.Models
{
    [Table("tbl_RoomDevice")]
    public class RoomDeviceEntity : BaseEntity
    {

        public int RoomId { get; set; } = 0;

        [StringLength(20),Required]
        public string DisName { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        // LinkDevicePort


    }
}
