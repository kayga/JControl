/************************************************************************

*Copyright  (c) 2020   All Rights Reserved .
*CLR版本    ：4.0.30319.42000
*机器名称   ：JSOUND
*公司名称   : 
*命名空间   ：JControl.Base.BLL
*文件名称   ：FactoryManager.cs
*版本号     : 2020|V1.0.0.0 

*=================================

*创 建 者    ：kayga.mo
*创建日期    ：2020/11/27 星期五 16:57:50 
*电子邮箱    ：mo.jj@topauthor.com
*个人主站    ：http://www.topauthor-tech.com
*功能描述    ：
*使用说明    ：

*=================================

*修改日期    ：2020/11/27 星期五 16:57:50 
*修改者      ：kayga.mo
*修改描述    ：
*版本号      : 2020|V1.0.0.0 

***********************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public class FactoryManager
    {
        private static FactoryManager instance = null;
        private static readonly object syncObj = new object();


        private static CateoryManager cateoryManager = null;
        public static CateoryManager GetCateoryManager()
        {
            if (cateoryManager == null)
                cateoryManager = new CateoryManager();
            return cateoryManager;
        }
        

        private static ProductManager deviceManager = null;
        public static ProductManager GetDeviceManager()
        {
            if (deviceManager == null)
                deviceManager = new ProductManager();
            return deviceManager;
        }
        
        private static RoomDeviceManager roomDeviceManager = null;
        public static RoomDeviceManager GetRoomDeviceManager()
        {
            if (roomDeviceManager == null)
                roomDeviceManager = new RoomDeviceManager();
            return roomDeviceManager;
        }        

        private static RouterLinkManager routerLinkManager = null;
        public static RouterLinkManager GetRouterLinkManager()
        {
            if (routerLinkManager == null)
                routerLinkManager = new RouterLinkManager();
            return routerLinkManager;
        }

        

        /// <summary>  
        /// 业务逻辑创建工厂实例
        /// </summary>
        public static FactoryManager GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObj)
                    {
                        if (instance == null)
                        {
                            instance = new FactoryManager();
                        }
                    }
                }

                return instance;
            }
        }



        

    }

    public enum EnumManager
    {
        Cateory,
        Device,
        RoomDevice,
        RouterLink
    }
}
