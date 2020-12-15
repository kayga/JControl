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


using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace JControl.Wpf.Client.Model
{
    /// <summary>
    /// 界面接口输入类
    /// </summary>
    public class PortInputModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PortInputModel(ProductModel product)
        {
            this.Product = product;

            foreach (var p in product.PortCateories)
                Ports.Add(p);

        }

        private ObservableCollection<PortCateoryModel> Ports { get; set; } 
                = new ObservableCollection<PortCateoryModel>();
        private ProductModel Product { get; set; }

        private int _PortCount;

        public int PortCount
        {
            get { return _PortCount; }
            set
            {
                _PortCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PortCount"));
                }

            }
        }

        private RelayCommand _RemovePortCommand;

        /// <summary>
        /// Gets the RemovePortCommand.
        /// </summary>
        public RelayCommand RemovePortCommand
        {
            get
            {
                return _RemovePortCommand
                    ?? (_RemovePortCommand = new RelayCommand(
                    () =>
                    {
                                             Product.PortInputs.Remove(this);
                    }));
            }
        }

        private PortCateoryModel _PortCateory;

        public PortCateoryModel PortCateory
        {
            get { return _PortCateory; }
            set
            {
                //if (value!=null)
                //{
                //    if (_PortCateory != value)
                //    { 
                //        var oldValue = _PortCateory;

                //        _PortCateory = value;

                //        if(oldValue!=_PortCateory)
                //            Product.PortCateories.Remove(value);

                //        if (oldValue != null)
                //            Product.PortCateories.Add(oldValue);
                //    }
                //}
                 _PortCateory = value;
                 PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortCateory"));

            }
        }

    }
}
