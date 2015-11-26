using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.LightstoneAuto.Database.Domain.Models
{
    public class AutoCarSpecifcations
    {
        int? CarId { get; set; }
        int? Year { get; set; }
        string Vin { get; set; }
        string ImageUrl { get; set; }
        string Quarter { get; set; }
        string CarFullname { get; set; }
        string Model { get; set; }
    }
}
