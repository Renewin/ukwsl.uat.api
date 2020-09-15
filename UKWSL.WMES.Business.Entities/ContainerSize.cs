using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKWSL.WMES.Business.Entities
{
   public class ContainerSize :Log
    {
        public int ContainerSizeId { get; set; }
        public string ContainerSizeName { get; set; }

        public string ContainerSizeDesc { get; set;}

        public decimal VolumeInLitres { get; set; }

    }
}
