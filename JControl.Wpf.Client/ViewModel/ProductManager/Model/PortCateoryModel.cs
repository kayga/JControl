/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Wpf.Client.Model
*文件名称   ：RoomDeviceModel.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/12/8 星期二 12:19:59 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/12/8 星期二 12:19:59 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.ComponentModel;

namespace JControl.Wpf.Client.Model
{
    /// <summary>
    /// 产品接口类型
    /// </summary>
    public class PortCateoryModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PortCateoryModel()
        {

        }
        public PortCateoryModel(Base.DTO.PortCateoryDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            Group = dto.Group;
            Value = dto.Value;
            Code = dto.Code;
        }

        public Base.DTO.PortCateoryDTO Dto
        {
            get
            {
                Base.DTO.PortCateoryDTO result = new Base.DTO.PortCateoryDTO();

                result.Id = this.Id;
                result.Name = this.Name;
                result.Description = this.Description;
                result.Group = this.Group;
                result.Value = this.Value;
                result.Code = this.Code;

                return result;
            }
        }

        


        public Base.DTO.PortCateoryDTO  portCateoryDTO { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }


        #region Fields

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Group { get; set; }

        public int Value { get; set; }

        public string Code { get; set; }

        #endregion

    }
}
