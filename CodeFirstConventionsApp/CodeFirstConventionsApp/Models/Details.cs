using System.ComponentModel.DataAnnotations.Schema;

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