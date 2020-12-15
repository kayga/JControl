
namespace JControl.Base.DTO
{
    public class RouterLinkDto
    {
        public int RouterType { get; set; }
        public string RouterKey { get; set; }

        public int MasterDevId { get; set; }
        public RoomDeviceDTO MasterDev { get; set; }

        public int CtrlDevId { get; set; }
        public RoomDeviceDTO CtrlDev { get; set; }



    }
}
