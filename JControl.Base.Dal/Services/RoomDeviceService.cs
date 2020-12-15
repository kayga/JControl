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
using System.Text;

namespace JControl.Base.Dal
{

    public class RoomDeviceService : BaseService<RoomDeviceEntity>, IDal.IRoomDeviceService
    {
        public RoomDeviceService()
        {

        }

        public IQueryable<Models.RoomDeviceEntity> GetRoomDeivces()
        {

            var items = GetAll().Include(q => q.Product)
                        .ThenInclude(p => p.ProductPorts)
                        .ThenInclude(ms=>ms.PortCateory)
                        ;

            var i = items.ToList();

            return items;

        }
    }
}