using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TRPZ
{
    public class DishesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Dish> Dishes { get; set; }

        public DishesViewModel()
        {
            Dishes = new ObservableCollection<Dish>
            {
                new Dish
                {
                    Name = "Fahitos",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.American,
                    Price = 100m,
                    Weight = 150
                },
                new Dish
                {
                    Name = "Fish & Chips",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.English,
                    Price = 100m,
                    Weight = 100
                },
                new Dish
                {
                    Name = "Varenyky",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.Ukrainian,
                    Price = 100m,
                    Weight = 200
                },
                new Dish
                {
                    Name = "Pasta Bolognese",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.Italian,
                    Price = 100m,
                    Weight = 250
                },
                new Dish
                {
                    Name = "Pelmeni",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.Russian,
                    Price = 100m,
                    Weight = 200
                },
            };
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
