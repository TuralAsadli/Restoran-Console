using PracticeTask.Entitie;
using PracticeTask.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Entities
{
    public class User : Person
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public IEnumerable<FastFood> FastFoods { get; set; }
        public IEnumerable<Desert> Deserts { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
}
