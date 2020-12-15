
using System.Collections.Generic;

namespace JControl.Base.DTO
{
    /// <summary>
    /// 房间设备表
    /// </summary>
    public class RoomDeviceDTO
    {
        public RoomDeviceDTO()
        {
            LinkDevicePort = new List<LinkDevicePortDto>();
        }

        public RoomDeviceDTO(Base.Models.RoomDeviceEntity model)
        {
            this.LinkDevicePort = new List<LinkDevicePortDto>();
            this.Id = model.Id;
            this.DisName = model.DisName;
            this.Product = new ProductDTO(model.Product);
            this.ProductId = model.Product.Id;
            this.RoomId = model.RoomId;
        }

        /// <summary>
        /// 房间ID 预留
        /// </summary>
        public int RoomId { get; set; } = 0;

        public int Id { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisName { get; set; }
        public int ProductId { get; set; }

        private ProductDTO product;
        public ProductDTO Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                if (product == null)
                    return;
                if (product.ProductPorts.Count > 0)
                {
                    this.ProductId = product.Id;
                    foreach (var i in product.ProductPorts)
                    {
                        LinkDevicePort.Add(new LinkDevicePortDto
                        {
                            Name = i.PortName,
                            DevicePort = i.PortCateory
                        }) ;

                    }
                }
            }
        }
        public List<LinkDevicePortDto> LinkDevicePort { get; set; }
    }

    /// <summary>
    /// 设备路由信息表
    /// </summary>
    public class LinkDevicePortDto
    {
        public int Id { get; set; } 

        public PortCateoryDTO DevicePort { get; set; }
        public string Name { get; set; }

        public int LinkDeviceId { get; set; }

        public RoomDeviceDTO linkDevice;
        public RoomDeviceDTO LinkDevice
        {
            get { return linkDevice; }
            set
            {
                linkDevice = value;
                this.LinkDeviceId = linkDevice.Id;
                this.Name = LinkDevice.DisName;
            }
        }

    }


    //public class CtrlMasterDto
    //{
    //    public IList<RoomDeviceDTO> CtrlDevices { get; set; }
    //}


    //public class VideoRouterDto
    //{
    //    public int Id { get; set; }
    //    public string DisplayName { get; set; }

    //    public string MyProperty { get; set; }
    //}
}
