using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace BookReader.Domain.Enum
{
    public enum Gender
    {
        [Display(Name = "Male")] Male = 1,
        [Display(Name = "Female N")] Female = 2,
        [Display(Name = "Other")] Other = 3
    }
}
