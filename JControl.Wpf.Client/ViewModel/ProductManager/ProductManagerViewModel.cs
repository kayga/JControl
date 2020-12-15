/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Wpf.Client.Views.DeviceManager
*文件名称   ：DeviceManagerPlugin.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/25 星期三 14:00:24 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/25 星期三 14:00:24 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight;
using System;
using JControl.Base.BLL;
using System.Collections.ObjectModel;
using JControl.Base.DTO;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.Composition;
using JControl.Wpf.Client.Views;
using System.Collections.Generic;
using System.ComponentModel;

namespace JControl.Wpf.Client.ViewModel
{
    public class ProductManagerViewModel : ViewModelBase
    {
        #region Ctor

        public ProductManagerViewModel()
        {
            Initialize();
        }

        #endregion

        #region Initialize Methods

        public void Initialize()
        {


            if (Products == null)
                Products = new ObservableCollection<Model.ProductModel>();

            // AddNewCateries();

            GetProducts();

        }
        public async void GetProducts()
        {

            List<ProductDTO> dtos = new List<ProductDTO>();
            if (QueryWhereText == string.Empty)
            {
                 dtos = await FactoryManager.productManager.GetAllByPageAsync(PageItemSize, PageNum, x=>x!=null, true);



            }
            else
            {
                 dtos = await FactoryManager.productManager.GetAllByPageAsync(PageItemSize, PageNum, x => x.Name == QueryWhereText, true);
            }

            Products = new ObservableCollection<Model.ProductModel>(
                                dtos.ConvertAll(x =>
                                new Model.ProductModel(x))

                                );
        }

        #endregion

        #region Fields

        /// <summary>
        /// 一页显示多少个
        /// </summary>
        private int PageItemSize = 10;
        /// <summary>
        /// 页码
        /// </summary>
        private int PageNum = 1;

        #endregion

        #region Devices mvvm Prop
        /// <summary>
        /// 设备集合
        /// </summary>
        public ObservableCollection<Model.ProductModel> Products
        {
            get { return _Products; }
            set { Set(ref _Products, value); }
        }

        private ObservableCollection<Model.ProductModel> _Products;


        /// <summary>
        /// 选中单个
        /// </summary>
        public Model.ProductModel SelectedProduct
        {
            get { return _SelecteProduct; }
            set
            {
                Set(ref _SelecteProduct, value);
            }
        }

        private Model.ProductModel _SelecteProduct;



        public string QueryWhereText
        {
            get { return _QueryWhereText; }
            set { Set(ref _QueryWhereText, value); }
        }

        private string _QueryWhereText = string.Empty;


        /// <summary>
        /// 全选
        /// </summary>
        public bool IsSelectedAll
        {
            get
            {
                return _IsSelectedAll;
            }
            set
            {
                Set(ref _IsSelectedAll, value);
                foreach (var d in Products)
                    d.IsSelected = value;
            }
        }

        private bool _IsSelectedAll;




        #endregion

        #region Command

        private RelayCommand<object> _AddAndSaveCommand;
        private RelayCommand<object> _AddItemToRoomCommand;
        private RelayCommand _DeleteItemsCommand;
        private RelayCommand<object> _PageNumCommand;


        private RelayCommand _QueryCommand;

        /// <summary>
        /// Gets the QueryCommand.
        /// </summary>
        public RelayCommand QueryCommand
        {
            get
            {
                return _QueryCommand
                    ?? (_QueryCommand = new RelayCommand(
                    () =>
                    {
                        this.GetProducts();
                    }));
            }
        }


        /// <summary>
        /// 添加一个新的产品
        /// </summary>
        public RelayCommand<object> AddAndSaveCommand
        {
            get
            {
                return _AddAndSaveCommand
                    ?? (_AddAndSaveCommand = new RelayCommand<object>(
                    p =>
                    {
                        string id = p.ToString();

                        //ID = 0 ,默认为添加
                        if (id == "0")
                        {

                            GlobalViewHelper.ShowDialog(
                                new AddDeviceItemView(),
                                new Model.ProductModel());
                        }
                        else
                        {
                            var editObj = Products.First(x => x.Id == int.Parse(id));
                            GlobalViewHelper.ShowDialog(
                                new AddDeviceItemView(),
                                editObj);
                        }
                    }));
            }
        }


        /// <summary>
        /// 删除一个产品
        /// </summary>
        public RelayCommand DeleteItemsCommand
        {
            get
            {
                return _DeleteItemsCommand
                    ?? (_DeleteItemsCommand = new RelayCommand(
                    () =>
                    {
                        DeleteSelectedProduct();

                    }));
            }
        }


        /// <summary>
        /// 快速添加设备至指定房间.
        /// </summary>
        private RelayCommand _AddSelectedToRoomCommand;

        /// <summary>
        /// Gets the AddSelectedToRoomCommand.
        /// </summary>
        public RelayCommand AddSelectedToRoomCommand
        {
            get
            {
                return _AddSelectedToRoomCommand
                    ?? (_AddSelectedToRoomCommand = new RelayCommand(
                    () =>
                    {
                        var selectedItems = Products.Where(x => x.IsSelected).ToList();

                        DeviceAddToRoom(selectedItems);
                    }));
            }
        }

        //public RelayCommand<object> AddItemToRoomCommand
        //{
        //    get
        //    {
        //        return _AddItemToRoomCommand
        //            ?? (_AddItemToRoomCommand = new RelayCommand<object>(
        //            p =>
        //            {
        //                    var selectedItems = Products.Where(x => x.IsSelected).ToList().ConvertAll(i => i.deviceDto);

        //                    DeviceAddToRoom(selectedItems);
        //                if (p == null)
        //                {
        //                }
        //                else
        //                {


        //                    int index = int.Parse(p.ToString());

        //                    var addToRoomItem = Devices.First(x => x.deviceDto.Id == index);


        //                    GlobalViewHelper.ShowDialog(new AddDevToRoomDialogView(),null)
        //                }

        //            }));
        //    }
        //}



        /// <summary>
        /// 跳页按钮
        /// </summary>
        public RelayCommand<object> PageNumCommand
        {
            get
            {
                return _PageNumCommand
                    ?? (_PageNumCommand = new RelayCommand<object>(
                    p =>
                    {
                        PageNum = int.Parse(p.ToString());
                        GetProducts();

                    }));
            }
        }

        #endregion

        #region Private Methods

        private async void DeleteSelectedProduct()
        {
            var items = Products.Where(x => x.IsSelected).ToList();

            foreach (var item in items)
            {
                await FactoryManager.productManager.DeleteAsync(item.Id);

            }

            GetProducts();
        }

        private async void DeviceAddToRoom(List<Model.ProductModel> products)
        {
            int num = 0;
            RoomDeviceManager roomDevMgr = new RoomDeviceManager();

            //foreach (var i in products)
            //{
            //    var t = await Task.Run(() =>
            //    {
            //        return roomDevMgr.AddAsync(new RoomDeviceDTO { id Device = i,DeviceId = i.Id , DisplayName = i.Name });
            //    });

            //    if (t == 1) num++;
            //}

            foreach (var item in products)
            {
                await roomDevMgr.AddAsync(
                    new RoomDeviceDTO {
                        DisName = item.Name, 
                        Product = item.Dto, 
                        ProductId = item.Dto.Id, 
                        RoomId = 0
                    });

                num++;
            }


            System.Windows.Forms.MessageBox.Show($"成功添加 {num} 个设备");

        }

        #endregion
    }
}

namespace JControl.Wpf.Client.Model
{
    public class RoomDeviceModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Ctor

        public RoomDeviceModel()
        {
        }

        public RoomDeviceModel(Base.DTO.RoomDeviceDTO dto)
        {
            this.Id = dto.Id;
            this.RoomId = dto.RoomId;
            this.DisName = dto.DisName;
            this.ProductId = dto.ProductId;
            this.Product = new ProductModel(dto.Product);

            this.LinkDevicePorts = new ObservableCollection<LinkDevicePortModel>();


            foreach (var p in Product.ProductPorts)
            {

                LinkDevicePorts.Add(new LinkDevicePortModel {
                    Id = p.Id,
                    LinkDevice = new RoomDeviceModel(),
                    DevicePort = p.PortCateory,
                    Name = p.PortName

                }) ;

            }
            this._dto = dto;
         
        }
        private Base.DTO.RoomDeviceDTO _dto;
        public Base.DTO.RoomDeviceDTO DTO
        {
            get
            {
                _dto.RoomId = this.RoomId;
                _dto.Id = this.Id;
                _dto.DisName = this.DisName;
                _dto.ProductId = this.ProductId;
                _dto.Product = this.Product.Dto;

                return _dto;
            }
        }

        #endregion



        #region Properties


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


        private int _RoomId;

        public int RoomId
        {
            get { return _RoomId; }
            set
            {
                _RoomId = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RoomId"));
                }

            }
        }

        private string _DisName;

        public string DisName
        {
            get { return _DisName; }
            set
            {
                _DisName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DisName"));
                }

            }
        }

        private int _ProductId;

        public int ProductId
        {
            get { return _ProductId; }
            set
            {
                _ProductId = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductId"));
                }

            }
        }

        private ObservableCollection<LinkDevicePortModel> _LinkDevicePorts;

        public ObservableCollection<LinkDevicePortModel> LinkDevicePorts
        {
            get { return _LinkDevicePorts; }
            set
            {
                _LinkDevicePorts = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LinkDevicePorts"));
                }

            }
        }



        private ProductModel _Product;

        public ProductModel Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Product"));
                }

            }
        }

        //TODO: LinkDevicePort
        #endregion


    }

    public class LinkDevicePortModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region ctor
        public LinkDevicePortModel()
        {

        }

        public LinkDevicePortModel(Model.RoomDeviceModel linkDevice ,Base.DTO.LinkDevicePortDto dto)
        {
            this._dto = dto;

            this.Id = dto.Id;
            this.Name = dto.Name;
            this.DevicePort = new PortCateoryModel(dto.DevicePort);
            this.LinkDevice = linkDevice;

        }

        public Base.DTO.LinkDevicePortDto _dto;


        public Base.DTO.LinkDevicePortDto DTO
        {
            get
            {
                _dto.Id = this.Id;
                _dto.Name = this.Name;
                _dto.DevicePort = this.DevicePort.Dto;
                _dto.linkDevice = this.LinkDevice.DTO;
                _dto.LinkDeviceId = this.LinkDeviceId;

                return _dto;
            }
        }
       
        #endregion

        #region properties

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

        private PortCateoryModel _DevicePort;

        public PortCateoryModel DevicePort
        {
            get { return _DevicePort; }
            set
            {
                _DevicePort = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DevicePort"));
                }

            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }

            }
        }

        private int _LinkDeviceId;

        public int LinkDeviceId
        {
            get { return _LinkDevice.Id; }
        }

        private RoomDeviceModel _LinkDevice;

        public RoomDeviceModel LinkDevice
        {
            get { return _LinkDevice; }
            set
            {
                _LinkDevice = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LinkDevice"));
                }

            }
        }

        #endregion
    }

}