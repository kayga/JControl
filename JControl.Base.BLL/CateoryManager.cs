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
    public class CateoryManager : BaseManager
    {
        public async Task<int> AddAsync(CateoryDTO dto)
        {
            using (ICateoryService rdevSvc = new CateoryService())
            {
                var model = ObjectExtend.Mapper<CateoryEntity, CateoryDTO>(dto);
                return await Task.Run(() =>
                {
                    return rdevSvc.AddAsync(model);
                });
            }

        }

        public async Task<int> EditAsync(CateoryDTO dto)
        {
            var model = ObjectExtend.Mapper<CateoryEntity, CateoryDTO>(dto);
            using (ICateoryService rdevSvc = new CateoryService())
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
            using (ICateoryService rdevSvc = new CateoryService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.RealDeleteAsync(id);
                });
            }

        }

        public async Task<List<CateoryDTO>> GetAllAsync()
        {
            using (ICateoryService rdevSvc = new CateoryService())
            {
                return await Task.Run(() =>
                {
                    return rdevSvc.GetAll().ToList().ConvertAll(x => ObjectExtend.Mapper<CateoryDTO, CateoryEntity>(x));
                });
            }
        }

        public async Task<CateoryDTO> GetOneAsync(int id)
        {
            using (ICateoryService rdevSvc = new CateoryService())
            {
                return await Task.Run(() =>
                {
                    return ObjectExtend.Mapper<CateoryDTO, CateoryEntity>(rdevSvc.GetOneAsync(id).Result);

                });
            }
        }
    }
}
