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

namespace JControl.Base.DTO
{
    /// <summary>
    /// 产品接口
    /// </summary>
    public class ProductPortDTO
    {
        public ProductPortDTO()
        {
        }

        public ProductPortDTO(ProductDTO parent ,ProductPortEntity model)
        {
            this.Id = model.Id;
            this.PortName = model.PortName;
            this.PortKey = model.PortKey;
            this.ParentProduct = parent;

            this.PortCateory = new PortCateoryDTO(model.PortCateory);
        }
        public int Id { get; set; }
        public string PortName { get; set; }
        public string PortKey { get; set; }

        public int ParentProductId
        {
            get
            {
                return ParentProduct.Id;
            }
        }
        public ProductDTO ParentProduct { get; set; }

        private int _PortCateoryId;
        public int PortCateoryId
        {
            set
            {
                if (PortCateory == null)
                    _PortCateoryId = value;
            }
            get
            {
                if (PortCateory != null)
                    return PortCateory.Id;
                else
                    return _PortCateoryId;
            }
        }
        public PortCateoryDTO PortCateory { get; set; }

    }
}
