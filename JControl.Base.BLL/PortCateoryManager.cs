using JControl.Base.Dal;
using JControl.Base.DTO;
using JControl.Base.IDal;
using JControl.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public class PortCateoryManager : BaseManager
    {
        public async Task<int> AddAsync(PortCateoryDTO dto)
        {
            using (IPortCateoryService rdevSvc = new PortCateoryService())
            {
                var model = ObjectExtend.Mapper<PortCateoryEntity,PortCateoryDTO>(dto);
                return await Task.Run(() =>
                {
                    return rdevSvc.AddAsync(model);
                });
            }

        }

        public async Task<int> EditAsync(PortCateoryDTO dto)
        {
            var model = ObjectExtend.Mapper<PortCateoryEntity, PortCateoryDTO>(dto);
            using (IPortCateoryService rdevSvc = new PortCateoryService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.EditAsync(model);
                });
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (ICateoryService rdevSvc = new CateoryService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.DeleteAsync(id);
                });
            }

        }
        public async Task<int> RealDeleteAsync(int id)
        {
            using (IPortCateoryService rdevSvc = new PortCateoryService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.RealDeleteAsync(id);
                });
            }

        }

        public async Task<List<PortCateoryDTO>> GetAllAsync()
        {
            using (IPortCateoryService rdevSvc = new PortCateoryService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.GetAll().ToList().ConvertAll(x => ObjectExtend.Mapper<PortCateoryDTO, PortCateoryEntity>(x));
                });
            }
        }

        public async Task<PortCateoryDTO> GetOneAsync(int id)
        {
            using (IPortCateoryService rdevSvc = new PortCateoryService())
            {
                return await Task.Run(() =>
                {
                    return ObjectExtend.Mapper<PortCateoryDTO, PortCateoryEntity>(rdevSvc.GetOneAsync(id).Result);

                });
            }
        }
    }
}
