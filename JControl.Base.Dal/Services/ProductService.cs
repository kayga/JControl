/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Base.Dal
*文件名称   ：CateoryDal.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/20 星期五 15:09:03 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/20 星期五 15:09:03 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using JControl.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JControl.Base.Dal
{

    public class ProductService : BaseService<ProductEntity>, IDal.IProductService
    {
        public ProductService()
        {
            
        }

        public async Task<int> AddProductAsync(ProductEntity model)
        {
            db.Add(model);
            return await db.SaveChangesAsync();
        }

        public async Task<int> EditProductAsync(ProductEntity newModel, ProductEntity oldModel)
        {
            List<ProductPortEntity> removeList = new List<ProductPortEntity>();

            //if (newModel.ProductPorts.Count >= oldModel.ProductPorts.Count)
            //{
            //    db.Update(newModel);
            //    return await db.SaveChangesAsync();
            //}
            //else if (newModel.ProductPorts.Count < oldModel.ProductPorts.Count)
            //{
            //    int i = 0;

            //    foreach (var m in oldModel.ProductPorts)
            //    {
            //        try
            //        {
            //            var key = m.PortKey;
            //            var item = newModel.ProductPorts.First(x => x.Id == m.Id);
            //            if (oldModel.ProductPorts.First(x => x.Id == m.Id) == null)
            //                removeList.Add(m);
            //            i++;
            //        }
            //        catch (Exception)
            //        {
            //            removeList.Add(m);
            //            continue;
            //        }
            //    }
            //    db.RemoveRange(removeList);
            //}

            foreach (var m in oldModel.ProductPorts)
            {
                try
                {
                    var key = m.PortKey;
                    var item = newModel.ProductPorts.First(x => x.Id == m.Id);
                    if (oldModel.ProductPorts.First(x => x.Id == m.Id) == null)
                        removeList.Add(m);

                }
                catch (Exception)
                {
                    removeList.Add(m);

                    db.ProductPorts.Remove(new ProductPortEntity { Id = m.Id });
                    continue;
                }
            }

            //db.Remove(removeList);

            //newModel.ProductPorts.Remove(removeList);
            db.Update(newModel);

            return await db.SaveChangesAsync();

        }

        public IQueryable<Models.ProductEntity> GetProductIncludePorts()
        {

            var items = GetAll().Include(q => q.ProductPorts)
                                .ThenInclude(x=>x.PortCateory);



            return items;
        }
        public IQueryable<Models.ProductEntity> GetProductIncludePortsByPage(
            int pageSize, 
            int pageIndex, 
            Expression<Func<ProductEntity, bool>> whereLambda, 
            bool isAsc){
           

            var items = GetProductIncludePorts()
                            .Where(whereLambda)
                            .OrderBy(t => t.CreateTime)
                            .Skip(pageSize * (pageIndex - 1))
                            .Take(pageSize);

            return items;
        }
    }
}
