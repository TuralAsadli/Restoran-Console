using PracticeTask.Entitie;
using PracticeTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Repository
{
    public class FastFoodRepository : FoodRepository<FastFood>, IFastFoodRepository
    {
    }
}
