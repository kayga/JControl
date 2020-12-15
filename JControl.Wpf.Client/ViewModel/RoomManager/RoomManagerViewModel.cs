/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Wpf.Client.ViewModel
*文件名称   ：RoomDeviceMgr.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/25 星期三 22:40:26 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/25 星期三 22:40:26 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight;
using JControl.Base.BLL;
using JControl.Base.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace JControl.Wpf.Client.ViewModel
{
    public class RoomManagerViewModel : ViewModelBase
    {

        #region Fields（ 参数 ）

        private RoomDeviceManager roomDeviceManager = new RoomDeviceManager();
        private ProductManager deviceManager = new ProductManager();

        #endregion

        #region Properties ( 属性 )

        public ObservableCollection<ProductDTO> Devices
        {
            get { return _Devices; }
            set { Set(ref _Devices, value); }
        }

        private ObservableCollection<ProductDTO> _Devices = new ObservableCollection<ProductDTO>();


        private ObservableCollection<Model.RoomDeviceModel> _RoomDevices = new ObservableCollection<Model.RoomDeviceModel>();

        public ObservableCollection<Model.RoomDeviceModel> RoomDevices
        {
            get { return _RoomDevices; }
            set
            {
                 Set(ref _RoomDevices, value);
  
            }
        }



        public Model.RoomDeviceModel SelectedRoomDevice
        {
            get { return _SelectedRoomDevice; }
            set { Set(ref _SelectedRoomDevice, value); }
        }

        private Model.RoomDeviceModel _SelectedRoomDevice = new Model.RoomDeviceModel();

        #endregion

        #region Public Method ( 公共方法 )
                


        public async void GetRoomDevices()
        {
            var items = await roomDeviceManager.GetAllByRoomIdAsync(0);

            RoomDevices = new ObservableCollection<Model.RoomDeviceModel>(items.ConvertAll(x => new Model.RoomDeviceModel(x)));




        }

        public async void AddRoomDevices()
        {

            //await roomDeviceManager.AddAsync(
            //    new RoomDeviceDTO
            //    {
            //        Device = Devices.First(),
            //        DeviceId = Devices.First().Id,
            //        DisplayName = "中控主机 1#"
            //    });
            
        }

        #endregion

        #region Ctor ( 构造函数 )
        public RoomManagerViewModel()
        {
            Init();
        }


        #endregion

        #region Private Method（ 私有方法 ）

        /// <summary>
        /// 加载房间设备数据
        /// </summary>
        private void Init()
        {

            GetRoomDevices();

        }

        #endregion

    }

}
