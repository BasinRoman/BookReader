using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookReader.Domain.Enum
{
    public enum Genre
    {
        [Display(Name = "BookView about history")]
        Historic,
        [Display(Name = "BookView of some classic writer")]
        Classic,
        [Display(Name = "BookView about Spider-Man or Batman etc..")]
        Comics,
        [Display(Name = "BookView about learning c# or math etc..")]
        Study
    }

}
