using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Das.Domain.Enum
{
    public enum BuildingTypeEnum {
        [Description("Apartment")]
        Apartment,

        [Description("House")]
        House,

        [Description("Row / Townhouse")]
        RowTownhouse,

        [Description("Duplex")]
        Duplex,

        [Description("Fourplex")]
        Fourplex,

        [Description("Mobile Home")]
        MobileHome,

        [Description("Manufactured Home/Mobile")]
        ManufacturedHome,

        [Description("Multi-Family")]
        MultiFamily,

        [Description("Parking")]
        Parking,

        [Description("Triplex")]
        Triplex,

        [Description("Unknown")]
        Unknown,
    }
    
}
