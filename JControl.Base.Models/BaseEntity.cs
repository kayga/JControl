using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JControl.Base.Models

{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public bool IsRemoved { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
