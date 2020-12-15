using JControl.Base.Dal;
using JControl.Base.DAL;
using JControl.Base.IDal;
using JControl.Base.Models;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.DbDesginer
{
    class Program
    {
        //private static async void AddCatoryAsync(string[] args)
        //{
        //    var c = new CateoryEntity { Name = "控制主机" };
        //    using (ICateoryDal dal = new CateoryDal())
        //    {
        //        var i = await dal.AddAsync(c);
        //        //dal.AddAsync(d2);
        //        //dal.AddAsync(d3);
        //        //dal.AddAsync(d4);
        //    };
        //}
        //private static async void AddDeviceAsync(string[] args)
        //{
        //    CateoryEntity c;
        //    using (ICateoryDal dal = new CateoryDal())
        //    {
        //        c = dal.Query().First();
        //        //dal.AddAsync(d2);
        //        //dal.AddAsync(d3);
        //        //dal.AddAsync(d4);
        //    };

        //    using (IDeviceDal dal = new DeviceDal())
        //    {
        //        DeviceEntity d = new DeviceEntity
        //        {
        //            Catoeory = c,
        //            Name = "123",
        //            Remark = ""

        //        };

        //        var i = await dal.AddAsync(d);
        //    }
        //}
        // private static async void DelDeviceAsync(string[] args)
        //{
        //    using (IDeviceDal dal = new DeviceDal())
        //    {
        //        await dal.DeleteAsync(1);


        //    }
        //}

        //private static async void AddRoomDeviceAsync(string[] ars) {

        //    DeviceEntity dev;
        //    using(IDeviceDal dal = new DeviceDal())
        //    {
        //       dev = dal.Query().First();
        //    }


        //    RoomDeviceEntity rd1 = new RoomDeviceEntity { Device = dev  };
        //    RoomDeviceEntity rd2 = new RoomDeviceEntity { Device = dev  };
        //    RoomDeviceEntity rd3 = new RoomDeviceEntity { Device = dev  };
        //    RoomDeviceEntity rd4 = new RoomDeviceEntity { Device = dev  };

        //    using (IRoomDeviceDal dal = new RoomDeviceDal())
        //    {
        //        await dal.AddAsync(rd1);
        //        await dal.AddAsync(rd2);
        //        await dal.AddAsync(rd3);
        //        await dal.AddAsync(rd4);
        //    }
        //}
        static void Main(string[] args)
        {
            //   AsyncContext.Run(() => AddCatoryAsync(args));
            //AsyncContext.Run(() => AddDeviceAsync(args));
            //AsyncContext.Run(() => AddRoomDeviceAsync(args));
            //AsyncContext.Run(() => DelDeviceAsync(args));

            //using (IDeviceDal dal =new DeviceDal())
            //{
            //    var i = dal.Query().First();
            //}

            //using (ControlSystemContext DbContext = new ControlSystemContext())
            //{
            //    DbContext.Devices.Add(new DeviceEntity { Name = "中控主机", Remark = "测试" });
            //    DbContext.SaveChanges();
            //}
            //using (ControlSystemContext DbContext = new ControlSystemContext())
            //{
            //   var t = DbContext.Devices.First();

            //    DbContext.RoomDevices.Add(new RoomDeviceEntity { Device = t, DisplayName = "控制器" });
            //    DbContext.SaveChanges();
            //}
            using (ControlSystemContext DbContext = new ControlSystemContext())
            {
                //var items = DbContext.RoomDevices.ToList();

                //var i = new RouterLinkEntity
                //{
                //    CtrlDev = items[0],
                //    CtrlDevId = items[0].Id,
                //    MasterDev = items[1],
                //    MasterDevId = items[1].Id,
                //    RouterKey = "123",
                //    RouterType = 1
                //};

                //DbContext.Add(i);
                //DbContext.SaveChanges();
            }

            using (RouterLinkService router = new RouterLinkService())
            {
               // var t = router.GetRoutersIncludeDevices();

               // var item = t.First();
            }

            Console.Read();
        }
    }
}
