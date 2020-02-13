using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DragonArmy
{
    public class Dragon
    {
        public string Type { get; set; }

        public Stats DragonStats { get; set; }

        public List<Stats> DragonStatsList { get; set; }

        public double DragonCount { get; set; }
        
        public double TotalDamage { get; set; }

        public double TotalHealth { get; set; }

        public double TotalArmor { get; set; }

    }
}
