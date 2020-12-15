/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Wpf.Client.Model
*文件名称   ：ProductProvider.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/12/11 星期五 13:37:18 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/12/11 星期五 13:37:18 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Wpf.Client.Model
{
    public class ProductProvider
    {
        /*-------------------------------------- Fields ----------------------------------------*/

        /*-------------------------------------Properties --------------------------------------*/

        /*------------------------------- Dependency Properties --------------------------------*/

        /*----------------------------------- Constructors -------------------------------------*/

        /*---------------------------------- Public Methods ------------------------------------*/
      
        /// <summary>
        /// 读取接口并统计数量
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="productPorts"></param>
        /// <returns></returns>
        public static ObservableCollection<PortInputModel> LoadPortInputs(
            Model.ProductModel vm,
            ObservableCollection<ProductPortModel> productPorts)
        {
            var portInputs = new ObservableCollection<PortInputModel>();


            var groups = productPorts.GroupBy(x => x
                                            .PortCateory.Code)
                                            .ToList();


            foreach (var g in groups)
            {
                var cateory = GetPortCateories().First(x => x.Code == g.Key);
                var count = g.Count();

                portInputs.Add(new PortInputModel(vm)
                {
                    PortCateory = cateory,
                    PortCount = count
                });
            }


            return portInputs;
        }
       
        /// <summary>
        /// 弹出编辑框
        /// </summary>
        /// <param name="vm"></param>
        public static void ShowEditProduct(Model.ProductModel vm)
        {

            GlobalViewHelper.ShowDialog(
                                new Views.AddDeviceItemView(),
                                vm);
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="ProductId"></param>
        public static async void DeleteProduct(int ProductId)
        {
            await FactoryManager.productManager.DeleteAsync(ProductId);
            RefreshProducts();
        }

        /// <summary>
        /// 保存并关闭窗口
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static async void SaveDtoAndCloseAsync(Base.DTO.ProductDTO dto)
        {

            var item = dto as Base.DTO.ProductDTO;
            if (item.Id != 0)
                await FactoryManager.productManager.EditAsync(item);
            else
                await FactoryManager.productManager.AddAsync(item);

            var devManagerVm = SimpleIoc.Default.GetInstance<ViewModel.ProductManagerViewModel>();
            devManagerVm.GetProducts();

            GlobalViewHelper.CloseDialog();
        }        
        
        public static async void SaveDtoAndCloseAsync(
            Base.DTO.ProductDTO OldDto,
            Base.DTO.ProductDTO NewDto)
        {

            if (NewDto.Id != 0)
            { 
                
                await FactoryManager.productManager.EditAsync(OldDto,NewDto);
            }
            else
                await FactoryManager.productManager.AddAsync(NewDto);

            var devManagerVm = SimpleIoc.Default.GetInstance<ViewModel.ProductManagerViewModel>();
            devManagerVm.GetProducts();

            GlobalViewHelper.CloseDialog();
        }


        /*---------------------------------- Private Method ------------------------------------*/
        /// <summary>
        /// 获取接口类型
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Model.PortCateoryModel> GetPortCateories()
        {
            return  SimpleIoc.Default.GetInstance
                            <ObservableCollection<Model.PortCateoryModel>>();
        }
      
        /// <summary>
        /// 刷新产品列表
        /// </summary>
        public static void RefreshProducts()
        {
            var devManagerVm = SimpleIoc.Default.GetInstance<ViewModel.ProductManagerViewModel>();
            devManagerVm.GetProducts();
        }
    }
}
