/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Base.Dal
*文件名称   ：ICateoryDal.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/20 星期五 15:10:19 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/20 星期五 15:10:19 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/
using System.Linq;

namespace JControl.Base.IDal
{

    public interface IRoomDeviceService : IDal.IBaseService<Models.RoomDeviceEntity>
    {
        IQueryable<Models.RoomDeviceEntity> GetRoomDeivces();
    }
}
