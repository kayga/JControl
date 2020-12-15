using System;
using System.Collections.Generic;

namespace JControl.Base.Models
{
    public class ProjectEntity : BaseEntity
    {
        public string Name { get; set; }

        public IList<RoomEntity> Rooms { get; set; }

    }
}
