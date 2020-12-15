/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Wpf.Client
*文件名称   ：DialogHelper.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/12/8 星期二 14:55:41 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/12/8 星期二 14:55:41 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JControl.Base.BLL;
using JControl.Base.DTO;
using JControl.Wpf.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JControl.Wpf.Client
{
    public class GlobalViewHelper
    {
        public static ProductManager  deviceManager { get; set; } = new ProductManager();
        public static void ShowDialog(UserControl diglogView,object viewmodel) 
        {
            var mainVm = SimpleIoc.Default.GetInstance<MainViewModel>();
            mainVm.ShowDialogView = diglogView;
            mainVm.ShowDialogView.DataContext = viewmodel;

        }
        public static void CloseDialog()
        {
            var mainVm = SimpleIoc.Default.GetInstance<ViewModel.MainViewModel>();
            mainVm.IsShowDialog = System.Windows.Visibility.Hidden;
            mainVm.ShowDialogView = null;
        }

        public static async Task SaveDtoAndCloseAsync(object dto)
        {

            
            var type = dto.GetType();

            if (type.Name == "ProductDTO")
            {
                var item = dto as Base.DTO.ProductDTO;
                if (item.Id != 0)
                    await FactoryManager.productManager.EditAsync(item);
                else
                    await FactoryManager.productManager.AddAsync(item);

                var devManagerVm = SimpleIoc.Default.GetInstance<ProductManagerViewModel>();
                devManagerVm.GetProducts();
            }


            CloseDialog();
        }

        
    }


    public class FactoryManager
    {
        public static ProductManager productManager { get; set; } = new ProductManager();

        public static PortCateoryManager portCateoryManager { get; set; } = new PortCateoryManager();


        //public static ObservableCollection<Model.PortCateoryModel> GetPortCateories()
        //{
        //    return await GetPortCateoriesAsync();
        //}


        public static ObservableCollection<Model.PortCateoryModel> _ProductPortCateories; 
        public async Task<ObservableCollection<Model.PortCateoryModel>> GetPortCateoriesAsync() 
        {
            if (_ProductPortCateories == null)
                _ProductPortCateories = new ObservableCollection<Model.PortCateoryModel>();



            if (_ProductPortCateories.Count == 0)
            {
  
                _ProductPortCateories =
                    new ObservableCollection<Model.PortCateoryModel>(
                        (await portCateoryManager.GetAllAsync()).ConvertAll(x =>
                            new Model.PortCateoryModel(x)));
            }
         

            return _ProductPortCateories;
        }




        /// <summary>
        /// 获取所有接口类型(模拟)
        /// </summary>
        /// <returns></returns>
        public static List<PortCateoryDTO> GetDesginPortCateories()
        {
            List<PortCateoryDTO> result;
    
                result = new List<PortCateoryDTO>();

            if (result.Count == 0)
            {
                //Power
                result.Add(new PortCateoryDTO { Id = 1, Name = "power in", Code = "PI", Description = "电源输入", Group = "power", Value = 0 });
                result.Add(new PortCateoryDTO { Id = 2, Name = "power out",Code = "PO" ,Description = "电源输出", Group = "power", Value = 1 });

                //Hdmi
                result.Add(new PortCateoryDTO { Id = 3, Name = "hdmi in",Code = "HI" ,Description = "HDMI输入", Group = "hdmi", Value = 0 });
                result.Add(new PortCateoryDTO { Id = 4, Name = "hdmi out",Code = "HO", Description = "HDMI输出", Group = "hdmi", Value = 1 });

                //Audio
                result.Add(new PortCateoryDTO { Id = 5, Name = "audio in",Code ="AI" ,Description = "音频输入", Group = "audio", Value = 0 });
                result.Add(new PortCateoryDTO { Id = 6, Name = "auddio out",Code = "AO" ,Description = "音频输出", Group = "audio", Value = 1 });

                //io
                result.Add(new PortCateoryDTO { Id = 7, Name = "io", Code = "IO", Description = "IO", Group = "io", Value = 0 });
                result.Add(new PortCateoryDTO { Id = 8, Name = "realy",Code = "TL" ,Description = "继电器", Group = "io", Value = 1 });

                //lan
                result.Add(new PortCateoryDTO { Id = 9, Name = "lan",Code="NW" ,Description = "网络", Group = "network", Value = 2 });
                //serial
                result.Add(new PortCateoryDTO { Id = 10, Name = "serial",Code="SL", Description = "串口", Group = "serial", Value = 2 });
                //ir
                result.Add(new PortCateoryDTO { Id = 11, Name = "ir",Code = "IR", Description = "红外", Group = "ir", Value = 2 });
            
            }

            return result;
        }



    }
}
