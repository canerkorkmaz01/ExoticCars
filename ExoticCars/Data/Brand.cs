using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoticCars.Data
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }

        public ICollection<Model> Models { get; set; } = new HashSet<Model>();

    }
}
