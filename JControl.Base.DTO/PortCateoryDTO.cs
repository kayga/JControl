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
    /// 产品接口类型
    /// </summary>
    public class PortCateoryDTO
    {
        public PortCateoryDTO()
        {

        }

        public PortCateoryDTO(PortCateoryEntity model)
        {
            if (model != null)
            {
                this.Id = model.Id;
                this.Name = model.Name;
                this.Description = model.Description;
                this.Group = model.Group;
                this.Code = model.Code;
                this.Value = model.Value;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// Group 为同组的 0 和 1 为一对组合
        ///         0 为 输入
        ///         1 为 输出
        /// Group 为同组的 2 为 单独
        /// </summary>
        public int Value { get; set; }

    }
}
