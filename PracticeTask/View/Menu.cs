using PracticeTask.DAL;
using PracticeTask.Entitie;
using PracticeTask.Entities;
using PracticeTask.Entities.Base;
using PracticeTask.Repository;
using PracticeTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PracticeTask.View
{
    public class Menu
    {
        private static DataBase _dataBase = new DataBase();
        private static User _user = new User();

        private static string _username;
        private static string _restoranName = "Italia";

        public enum Role
        {
            User,
            Worker
        }

        public enum FoodType
        {
            Desert,
            FastFood,
            Meal,
            Drink,
        }

        

        //private string _mainTitles = "****    MENU     ****\n" +
        //  


        public static void ShowMainMenu()
        {
            Console.WriteLine("     RESTORAN NAME      ");
            Console.WriteLine("Welcome to the restoran");
            Console.WriteLine("Your worker? y/n");
            var response = Console.ReadLine().ToLower();

            switch (response)
            {
                case "y":
                    ShowWorkerMenu();
                    break;

                case "n":
                    ShowClientMenu();
                    break;
                default:
                    Console.WriteLine("Incorrect value");
                    break;
            }

        }

        public static void ShowClientMenu() 
        {
            Console.WriteLine("Hello!!!!");
            Console.WriteLine("what is your name?");
            _username = Console.ReadLine();
            Console.WriteLine($"        Welcome to {_restoranName}!!!\n" +
                              $"We have a big menu, {_username} chose one of them");
            bool repid = true;
            while (repid)
            {
                Console.WriteLine("Chose category\n");
                ShowRestoranMenuCategories();

                var category = Console.ReadLine().ToUpper();

                switch (category)
                {
                    case "1":
                        DesertManager(Role.User);
                        break;
                    case "2":
                        MealManager(Role.User);
                        break;
                    case "3":
                        FastFoodManager(Role.User);
                        break;
                    case "4":
                        DrinkManager(Role.User);
                        break;
                    case "5":
                        repid = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect Value");
                        break;
                }
            }


        }


        public static void ShowWorkerMenu()
        {
            bool repid = true;
            while (repid)
            {
                Console.WriteLine("Chose category\n");
                Console.WriteLine("1.Deserts\n" +
                                  "2.Meals\n" +
                                  "3.FastFoods\n" +
                                  "4.Drinks" +
                                  "5.Exit");

                var category = Console.ReadLine().ToUpper();

                switch (category)
                {
                    case "1":
                        DesertManager(Role.Worker);
                        break;
                    case "2":
                        MealManager(Role.Worker);
                        break;
                    case "3":
                        FastFoodManager(Role.Worker);
                        break;
                    case "4":
                        DrinkManager(Role.Worker);
                        break;
                    case "5":
                        repid = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect Value");
                        break;
                }
            }
            

            

        }

        public static void ShowRestoranMenuCategories() 
        {
            Console.WriteLine("Chose category\n");
            Console.WriteLine("1.Deserts\n" +
                              "2.Meals\n"+
                              "3.FastFood\n" +
                              "4.Drinks");
        }

        public static void ShowDrinks()
        {
            
            foreach (var item in _dataBase._drinks.GetAll())
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Price}");
            }
        }

        public static void ShowFastFoods()
        {
            foreach (var item in _dataBase._fastFoods.GetAll())
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Price}");
            }
        }
        public static void ShowMeals()
        {
            foreach (var item in _dataBase._meals.GetAll())
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Price}");
            }
        }

        public static void ShowDeserts()
        {
            foreach (var item in _dataBase._desers.GetAll())
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Price}");
            }
        }


        public static void ShowComands()
        {
            Console.WriteLine("1.Add\n" +
                              "2.Delete\n" +
                              "3.Show all\n" +
                              "4.Update\n" +
                              "5.Exit");
        }

        public static void ShowUserComands()
        {
            Console.WriteLine("1.Add\n" +
                              "2.Show all\n" +
                              "3.Show Checklist\n"+
                              "4.Exit");
        }

        public static void AddToUserList(FoodType type)
        {
            
            switch (type)
            {
                case FoodType.Desert:
                    ShowDeserts();
                    Console.WriteLine("Write Id");
                    int desertId = int.Parse(Console.ReadLine());
                    var desert = _dataBase._desers.GetById(desertId);
                    if (desert != null)
                    {
                        _user.Deserts.Append(desert);
                    }
                    break;
                case FoodType.FastFood:
                    ShowFastFoods();
                    Console.WriteLine("Write Id");
                    int fastFoodId = int.Parse(Console.ReadLine());
                    var fast = _dataBase._fastFoods.GetById(fastFoodId);
                    if (fast != null)
                    {
                        _user.FastFoods.Append(fast);
                    }
                    break;
                case FoodType.Meal:
                    ShowMeals();
                    Console.WriteLine("Write Id");
                    int mealsId = int.Parse(Console.ReadLine());
                    var meal = _dataBase._meals.GetById(mealsId);
                    if (meal != null)
                    {
                        _user.Meals.Append(meal);
                    }
                    break;
                case FoodType.Drink:
                    ShowDrinks();
                    Console.WriteLine("Write Id");
                    int id = int.Parse(Console.ReadLine());
                    var Drink = _dataBase._drinks.GetById(id);
                    if (Drink != null)
                    {
                        _user.Drinks.Append(Drink);
                    }
                    break;
                default:
                    break;
            }
            
        }

        public static void CreateCheckList()
        {
            int finalValue = 0;
            Console.WriteLine("Id -- Name -- Price -- Category");
            foreach (var item in _user.Deserts)
            {
                Console.WriteLine($"{item.Id} -- {item.Name} -- {item.Price} -- {item.GetType()}");
                finalValue += item.Price;
            }
            foreach (var item in _user.Meals)
            {
                Console.WriteLine($"{item.Id} -- {item.Name} -- {item.Price}");
                finalValue += item.Price;
            }
            foreach (var item in _user.Drinks)
            {
                Console.WriteLine($"{item.Id} -- {item.Name} -- {item.Price}");
                finalValue += item.Price;
            }
            foreach (var item in _user.FastFoods)
            {
                Console.WriteLine($"{item.Id} -- {item.Name} -- {item.Price}");
                finalValue += item.Price;
            }

            Console.WriteLine($"You should give money:{finalValue}, and 5% bonus for program commission:{finalValue * 1.05}");

        }
        public static void AddDesert()
        {
            Console.WriteLine("Write name of Desert");
            var name = Console.ReadLine();
            Desert desert = new Desert();
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                desert.Id = 0;
                desert.Name = name;
                desert.Price = price;
            }

            _dataBase._desers.Add(desert);
        }

        public static void AddFastFood()
        {
            Console.WriteLine("Write name of FastFood");
            var name = Console.ReadLine();
            FastFood fastFood = new FastFood();
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                fastFood.Id = 0;
                fastFood.Name = name;
                fastFood.Price = price;
            }

            _dataBase._fastFoods.Add(fastFood);
        }

        public static void AddDrink()
        {
            Console.WriteLine("Write name of FastFood");
            var name = Console.ReadLine();
            Drink drink = new Drink();
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                drink.Id = 0;
                drink.Name = name;
                drink.Price = price;
            }

            _dataBase._drinks.Add(drink);
        }

        public static void AddMeal()
        {
            Console.WriteLine("Write name of FastFood");
            var name = Console.ReadLine();
            Meal meal = new Meal();
            if (int.TryParse(Console.ReadLine(), out int price))
            {
                meal.Id = 0;
                meal.Name = name;
                meal.Price = price;
            }

            _dataBase._meals.Add(meal);
        }

        public static void DeleteDesert()
        {
            ShowDeserts();
            Console.WriteLine("write id of desert");
            if (int.TryParse(Console.ReadLine(),out int id))
            {
                _dataBase._desers.Delete(id);
            }
            else
            {
                Console.WriteLine("Incorrect id");
            }
            
        }
        public static void DeleteDrink()
        {
            ShowDrinks();
            Console.WriteLine("write id of drink");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _dataBase._drinks.Delete(id);
            }
            else
            {
                Console.WriteLine("Incorrect id");
            }

        }

        public static void DeleteFastFood()
        {
            ShowFastFoods();
            Console.WriteLine("write id of FastFood");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _dataBase._fastFoods.Delete(id);
            }
            else
            {
                Console.WriteLine("Incorrect id");
            }

        }

        public static void DeleteMeal()
        {
            ShowFastFoods();
            Console.WriteLine("write id of FastFood");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _dataBase._fastFoods.Delete(id);
            }
            else
            {
                Console.WriteLine("Incorrect id");
            }

        }

        public static void UpdateMeal()
        {
            ShowMeals();
            Console.WriteLine("write id,price and name");
            if (int.TryParse(Console.ReadLine(), out int id) && int.TryParse(Console.ReadLine(),out int price))
            {
                var name = Console.ReadLine();
                Meal meal = new Meal()
                {
                    Id = id,
                    Name = name,
                    Price = price
                };
                _dataBase._meals.Update(meal);
            }
        }

        public static void UpdateFastFood()
        {
            ShowFastFoods();
            Console.WriteLine("write id,price and name");
            if (int.TryParse(Console.ReadLine(), out int id) && int.TryParse(Console.ReadLine(), out int price))
            {
                var name = Console.ReadLine();
                FastFood fastFood = new FastFood()
                {
                    Id = id,
                    Name = name,
                    Price = price
                };
                _dataBase._fastFoods.Update(fastFood);
            }
        }
        public static void UpdateDesert()
        {
            ShowDeserts();
            Console.WriteLine("write id,price and name");
            if (int.TryParse(Console.ReadLine(), out int id) && int.TryParse(Console.ReadLine(), out int price))
            {
                var name = Console.ReadLine();
                Desert desert = new Desert()
                {
                    Id = id,
                    Name = name,
                    Price = price
                };
                _dataBase._desers.Update(desert);
            }
        }

        public static void UpdateDrink()
        {
            ShowDrinks();
            Console.WriteLine("write id,price and name");
            if (int.TryParse(Console.ReadLine(), out int id) && int.TryParse(Console.ReadLine(), out int price))
            {
                var name = Console.ReadLine();
                Drink drink = new Drink()
                {
                    Id = id,
                    Name = name,
                    Price = price
                };
                _dataBase._drinks.Update(drink);
            }
        }


        public static void DesertManager(Role userRole)
        {
            bool repid = true;
            if (userRole == Role.Worker)
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddDesert();
                            break;
                        case "2":
                            DeleteDesert();
                            break;
                        case "3":
                            ShowDeserts();
                            break;
                        case "4":
                            UpdateDesert();
                            break;
                        case "5":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }
            else if (userRole == Role.User)
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowUserComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddToUserList(FoodType.Desert);
                            break;
                        
                        case "2":
                            ShowDeserts();
                            break;
                        case "3":
                            CreateCheckList();
                            break;

                        case "4":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }


        }

        public static void MealManager(Role role)
        {
            bool repid = true;
            if (role == Role.Worker)
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddMeal();
                            break;
                        case "2":
                            DeleteMeal();
                            break;
                        case "3":
                            ShowMeals();
                            break;
                        case "4":
                            UpdateMeal();
                            break;
                        case "5":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }
            else if (role == Role.User)
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddToUserList(FoodType.Meal);
                            break;
                        
                        case "2":
                            ShowMeals();
                            break;
                        case "3":
                            CreateCheckList();
                            break;
                        case "4":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }
            



        }

        public static void FastFoodManager(Role role)
        {
            bool repid = true;
            if (role == Role.Worker)
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddFastFood();
                            break;
                        case "2":
                            DeleteFastFood();
                            break;
                        case "3":
                            ShowFastFoods();
                            break;
                        case "4":
                            UpdateFastFood();
                            break;
                        case "5":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }
            else
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddToUserList(FoodType.FastFood);
                            break;
                        
                        case "2":
                            ShowFastFoods();
                            break;
                        case "3":
                            CreateCheckList();
                            break;
                        case "4":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }
            


        }

        public static void DrinkManager(Role role)
        {
            bool repid = true;
            if (role == Role.Worker)
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddDrink();
                            break;
                        case "2":
                            DeleteDrink();
                            break;
                        case "3":
                            ShowDrinks();
                            break;
                        case "4":
                            UpdateDrink();
                            break;
                        case "5":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }
            else
            {
                while (repid)
                {
                    Console.WriteLine("Chose comand");
                    ShowComands();
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            AddToUserList(FoodType.Drink);
                            break;
                        
                        case "2":
                            ShowDrinks();
                            break;
                        case "3":
                            CreateCheckList();
                            break;
                        case "4":
                            repid = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect value");
                            break;
                    }

                }
            }
            


        }

    }
}
