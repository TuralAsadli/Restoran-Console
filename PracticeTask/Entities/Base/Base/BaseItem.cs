using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Entities.Base.Base
{
    public class BaseItem
    {
        //I chose int because with console app is difficult to take id of item
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
