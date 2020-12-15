using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using JControl.Wpf.Client.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Hosting;
using System.Threading.Tasks;

namespace JControl.Wpf.Client.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register(GetViews);

            //ProuctManager
            SimpleIoc.Default.Register<ProductManagerViewModel>();
            RegisterPortCateoriesAysnc();
            
            //RoomManager
            SimpleIoc.Default.Register<RoomManagerViewModel>();
            SimpleIoc.Default.Register<AddDevToRoomDialogView>();





        }


        #region Main And Cleanup

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public static void Cleanup()
        {
            SimpleIoc.Default.GetInstance<MainViewModel>().Cleanup();
        }
        
        #endregion

        #region ProductManager

        public async void RegisterPortCateoriesAysnc()
        {
            if(PortCateories==null)
            {
                var ls = await FactoryManager.portCateoryManager.GetAllAsync();
                PortCateories = new ObservableCollection<Model.PortCateoryModel>(
                                                ls.ConvertAll(x => new Model.PortCateoryModel(x)));
            }

            SimpleIoc.Default.Register(GetPortCateories);
        }
        public ProductManagerViewModel ProductManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductManagerViewModel>();
            }
        }
        public List<Model.PortCateoryModel> PortCateory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<List<Model.PortCateoryModel>>();
            }
        }

        private ObservableCollection<Model.PortCateoryModel> PortCateories;

        public ObservableCollection<Model.PortCateoryModel> GetPortCateories()
        {
            
            return PortCateories;
            
        }

        #endregion

        public RoomManagerViewModel RoomDevice
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RoomManagerViewModel>();
            }
        }

        public Model.ProductModel DesginProduct
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Model.ProductModel>();
            }
        }


        #region 子页面

        private List<IModule> modules { get; set; }
        public List<IModule> GetViews()
        {
            if (modules == null)
            {

                modules = new List<IModule>();
                modules.Add(new BaseViewPlugin<DeviceManagerView>(1, string.Empty, "设备基本数据管理"));
                modules.Add(new BaseViewPlugin<RoomDeviceManagerView>(2, string.Empty, "房间设备管理"));
            }

            return modules;
        }

        #endregion

    }
}