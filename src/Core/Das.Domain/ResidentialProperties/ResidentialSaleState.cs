﻿using Das.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Das.Domain.Entities
{
    public class ResidentialSaleState
    {
        public BuildingTypeEnum BuildingType { get; set; }
        public int SalesCount { get; set; }
        public decimal SalesPercentage { get; set; }
        

        public ResidentialSaleState(BuildingTypeEnum buildingType, int salesCount, decimal salesPercentage)
        {
            BuildingType = buildingType;
            SalesCount = salesCount;
            SalesPercentage = salesPercentage;
        }
    }
}
