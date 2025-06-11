using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstConventionsApp.Models
{
    [ComplexType]
    public class Details
    {
        public System.DateTime Time { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
    }
}