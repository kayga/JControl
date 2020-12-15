/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Base.DTO
*文件名称   ：DeviceDTO.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/25 星期三 12:19:01 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/25 星期三 12:19:01 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using JControl.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.DTO
{
    public class ProductDTO:ICloneable
    {
        public ProductDTO()
        {
            ProductPorts = new List<ProductPortDTO>();
        }


        public ProductDTO(ProductEntity model)
        {
            ProductPorts = new List<ProductPortDTO>();

            foreach (var p in model.ProductPorts)
            {
                ProductPorts.Add(new ProductPortDTO(this,p));
            }
            this.Id = model.Id;
            this.Name = model.Name;
            this.Brand = model.Brand;
            this.Model = model.Model;
            this.Origin = model.Origin;
            this.Description = model.Description;
            this.Cateory = model.Cateory;
            this.Remark = model.Remark;

        }


        public int Id { get; set; }
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
        /// 设备类型
        /// </summary>
        public string Cateory { get; set; }
       
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public IList<ProductPortDTO> ProductPorts { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
