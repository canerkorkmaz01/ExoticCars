using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExoticCars.Data
{
    public class Model
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        [Display(Name="Marka Adı")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz...")]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Brand Brand { get; set; }
    }
}
