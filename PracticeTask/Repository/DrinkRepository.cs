using PracticeTask.Entities;
using PracticeTask.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Repository.Interfaces
{
    public class DrinkRepository: FoodRepository<Drink>, IDrinkRepository
    {
        
    }
}
