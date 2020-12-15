using JControl.Base.Dal;
using JControl.Base.DTO;
using JControl.Base.IDal;
using JControl.Base.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public class RoomDeviceManager : BaseManager,IRoomDeviceManager
    {
        public async Task<int> AddAsync(RoomDeviceDTO dto)
        {
            using (IRoomDeviceService rdevSvc = new RoomDeviceService())
            {
                var model = ObjectExtend.Mapper<RoomDeviceEntity, RoomDeviceDTO>(dto);
                return await Task.Run(() =>
                {
                    return rdevSvc.AddAsync(model);
                });
            }

        }

        public async Task<int> EditAsync(RoomDeviceDTO dto)
        {
            var model = ObjectExtend.Mapper<RoomDeviceEntity, RoomDeviceDTO>(dto);
            using (IRoomDeviceService rdevSvc = new RoomDeviceService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.EditAsync(model);
                });
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (IRoomDeviceService rdevSvc = new RoomDeviceService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.DeleteAsync(id);
                });
            }

        }
        public async Task<int> RealDeleteAsync(int id)
        {
            using (IRoomDeviceService rdevSvc = new RoomDeviceService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.RealDeleteAsync(id);
                });
            }

        }

        public async Task<List<RoomDeviceDTO>> GetAllAsync()
        {
            using (IRoomDeviceService rdevSvc = new RoomDeviceService())
            {
                var items = await Task.Run(() =>
                {
                    var devices = rdevSvc.GetRoomDeivces().ToList();
                    List<RoomDeviceDTO> dtos = new List<RoomDeviceDTO>();

                    foreach (var d in devices)
                        dtos.Add(new RoomDeviceDTO(d));


                    return dtos;
                });

                return items;
            }
        }

        public async Task<List<RoomDeviceDTO>> GetAllByRoomIdAsync(int roomId)
        {
            using (IRoomDeviceService rdevSvc = new RoomDeviceService())
            {
                var items = await Task.Run(() =>
                {
                    var devices = rdevSvc.GetRoomDeivces().Where(x=>x.RoomId == roomId).ToList();
                    List<RoomDeviceDTO> dtos = new List<RoomDeviceDTO>();

                    foreach (var d in devices)
                        dtos.Add(new RoomDeviceDTO(d));


                    return dtos;
                });

                return items;
            }
        }

        public async Task<RoomDeviceDTO> GetOneAsync(int id)
        {
            using (IRoomDeviceService rdevSvc = new RoomDeviceService())
            {
                return await Task.Run(() =>
                {
                    return ObjectExtend.Mapper<RoomDeviceDTO, RoomDeviceEntity>(rdevSvc.GetOneAsync(id).Result);

                });
            }
        }
    }
}
