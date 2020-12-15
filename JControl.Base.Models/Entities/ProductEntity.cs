/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControler.Entities
*文件名称   ：DeviceEntity.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/20 星期五 10:27:37 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/20 星期五 10:27:37 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JControl.Base.Models
{
    [Table("tbl_Device")]
    public class ProductEntity :BaseEntity
    {
        public ProductEntity()
        {
            ProductPorts = new List<ProductPortEntity>();
        }
        /// <summary>
        /// 设备名称
        /// </summary>
        [StringLength(30),Required]
        public string Name { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// 设备描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public string Cateory { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        public IList<ProductPortEntity> ProductPorts { get; set; }

        public IList<RoomDeviceEntity> RoomDevices { get; set; }

    }
}
