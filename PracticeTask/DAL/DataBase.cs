using PracticeTask.Repository.Interfaces;
using PracticeTask.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.DAL
{
    internal class DataBase
    {
        public  FastFoodRepository _fastFoods;
        public  DesertRepository _desers;
        public  DrinkRepository _drinks;
        public  MealRepository _meals;

       

        public DataBase()
        {
            _fastFoods = new();
            _desers = new();
            _meals = new();
            _drinks = new();
        }
    }
}
