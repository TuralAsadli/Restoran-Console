using PracticeTask.Entitie;
using PracticeTask.Entities.Base;
using PracticeTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Repository
{
    public class FoodRepository<T> : BaseRepository<T>, IFoodRepository<T> where T : Food
    {
        
    }
}
