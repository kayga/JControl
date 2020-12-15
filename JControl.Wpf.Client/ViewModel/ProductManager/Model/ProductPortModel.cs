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


using System.ComponentModel;

namespace JControl.Wpf.Client.Model
{
    /// <summary>
    /// 产品接口
    /// </summary>
    public class ProductPortModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ProductPortModel(Base.DTO.ProductPortDTO dto)
        {
            this.Id = dto.Id;
            this.PortName = dto.PortName;
            this.PortKey = dto.PortKey;

            this.PortCateory = new PortCateoryModel(dto.PortCateory);
        }

        public Base.DTO.ProductPortDTO Dto
        {
            get
            {
                return new Base.DTO.ProductPortDTO
                {
                    Id = this.Id,
                    PortName = this.PortName,
                    PortKey = this.PortKey,

                    ParentProduct = Parent.Dto,  //TODO 
                    
                    PortCateory = PortCateory.Dto,
                    PortCateoryId = PortCateory.Id,
                };
            }
        }

        #region Feilds

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Id"));
                }

            }
        }

        private ProductModel _Parent;

        public ProductModel Parent
        {
            get { return _Parent; }
            set
            {
                _Parent = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Parent"));
                }

            }
        }


        private string _PortName;

        public string PortName
        {
            get { return _PortName; }
            set
            {
                _PortName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PortName"));
                }

            }
        }

        private string _PortKey;

        public string PortKey
        {
            get { return _PortKey; }
            set
            {
                _PortKey = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PortKey"));
                }

            }
        }

        private PortCateoryModel _PortCateory;

        public PortCateoryModel PortCateory
        {
            get { return _PortCateory; }
            set
            {
                _PortCateory = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PortCateory"));
                }

            }
        }

        #endregion
    }
}
