using JControl.Base.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JControl.Base.BLL
{
    public interface IProductManager
    {
        Task<int> AddAsync(ProductDTO dto);
        Task<int> DeleteAsync(int id);
        Task<int> EditAsync(ProductDTO dto);
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetOneAsync(int id);
        Task<int> RealDeleteAsync(int id);
    }
}