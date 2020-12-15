using JControl.Base.Dal;
using JControl.Base.DAL;
using JControl.Base.DTO;
using JControl.Base.IDal;
using JControl.Base.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public class RouterLinkManager:BaseManager
    {
        //public async Task<int> AddAsync(RoomDeviceDTO dto)
        //{
        //    using (IRoomDeviceService rdevSvc = new RoomDeviceService())
        //    {
        //        var model = ObjectExtend.Mapper<RouterLinkEntity, RoomDeviceDTO>(dto);
        //        return await Task.Run(() =>
        //        {
        //            return rdevSvc.AddAsync(model);
        //        });
        //    }

        //}

        //public async Task<int> EditAsync(RoomDeviceDTO dto)
        //{
        //    var model = ObjectExtend.Mapper<RouterLinkEntity, RoomDeviceDTO>(dto);
        //    using (IRoomDeviceService rdevSvc = new RoomDeviceService())
        //    {
        //        return await Task.Run(() =>
        //        {
        //            return rdevSvc.EditAsync(model);
        //        });
        //    }
        //}
        //public async Task<int> DeleteAsync(int id)
        //{
        //    using (IRoomDeviceService rdevSvc = new RoomDeviceService())
        //    {
        //        return await Task.Run(() =>
        //        {
        //            return rdevSvc.DeleteAsync(id);
        //        });
        //    }

        //}
        //public async Task<int> RealDeleteAsync(int id)
        //{
        //    using (IRoomDeviceService rdevSvc = new RoomDeviceService())
        //    {
        //        return await Task.Run(() =>
        //        {
        //            return rdevSvc.RealDeleteAsync(id);
        //        });
        //    }

        //}

        public async void GetAllAsync()
        {
            using (IRouterLinkService Svc = new RouterLinkService())
            {
                var items = await Task.Run(() =>
                {
                    return Svc.GetAll().ToList();
                });

                //foreach (var i in items)
                //{
                //    i.Device =await new DeviceManager().GetOneAsync(i.DeviceId);
                //}


                //return items;
            }
        }

        //public async Task<RoomDeviceDTO> GetOneAsync(int id)
        //{
        //    using (IRoomDeviceService rdevSvc = new RoomDeviceService())
        //    {
        //        return await Task.Run(() =>
        //        {
        //            return ObjectExtend.Mapper<RoomDeviceDTO, RouterLinkEntity>(rdevSvc.GetOneAsync(id).Result);

        //        });
        //    }
        //}
    }
}
