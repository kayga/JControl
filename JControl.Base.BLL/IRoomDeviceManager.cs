using JControl.Base.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public interface IRoomDeviceManager
    {
        Task<int> AddAsync(RoomDeviceDTO dto);
        Task<int> DeleteAsync(int id);
        Task<int> EditAsync(RoomDeviceDTO dto);
        Task<List<RoomDeviceDTO>> GetAllAsync();
        Task<RoomDeviceDTO> GetOneAsync(int id);
        Task<int> RealDeleteAsync(int id);
    }
}