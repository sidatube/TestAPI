using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    class MenuModel
    {
        public string Name { get; set; }
        public string NamePage { get; set; }
        public string Icon { get; set; }
        public DataMenu Category {get;set;}
    }
}
