using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TRPZ.Business;
using System.Windows;

namespace TRPZ
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IOrderService orderService;
        public ObservableCollection<Dish> Dishes { get; set; }
        public ObservableCollection<OrderedDishWithAmount> AmountOfOrderedDishes { get; set; }

        private Order lastOrder;

        private Dish selectedDish;
        public Dish SelectedDish
        {
            get { return selectedDish; }
            set 
            { 
                selectedDish = value;
                OnPropertyChanged(nameof(SelectedDish));
            }
        }

        private RelayCommand addDishToOrder;
        public RelayCommand AddDishToOrder
        {
            get
            {
                return addDishToOrder ??= new RelayCommand(parameter =>
                    {
                        if (parameter is Dish selectedDish)
                        {
                            OrderedDishWithAmount pair = AmountOfOrderedDishes.FirstOrDefault(x => x.OrderedDish == selectedDish);
                            if (pair != null)
                            {
                                pair.Amount++;
                            }
                            else
                            {
                                AmountOfOrderedDishes.Add(new OrderedDishWithAmount { OrderedDish = selectedDish });
                            }
                        }
                    });
            }
        }

        private RelayCommand makeOrder;
        public RelayCommand MakeOrder
        {
            get
            {
                return makeOrder ??= new RelayCommand(parametr =>
                {
                    if (lastOrder != null)
                    {
                        var result = MessageBox.Show("You've made order few minutes ago. Do you want to make new order?",
                            "Wait.", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.No)
                            return;
                    }

                    List<Dish> dishes = new List<Dish>();
                    foreach (OrderedDishWithAmount dishWithAmount in AmountOfOrderedDishes)
                    {
                        for (int i = 0; i < dishWithAmount.Amount; i++)
                        {
                            dishes.Add(dishWithAmount.OrderedDish);
                        }
                    }

                    lastOrder = orderService.CreateOrder(dishes);
                    string request = "Wait " + (int)(orderService.GetTimeWhenAllDishesAreCooked(lastOrder) - DateTime.Now).TotalMinutes + " minutes";
                    MessageBox.Show(request);
                },
                parametr =>
                {
                    return AmountOfOrderedDishes.Count != 0;
                });
            }
        }

        private RelayCommand getWaitingTime;

        public RelayCommand GetWaitingTime
        {
            get
            {
                return getWaitingTime ??= new RelayCommand(parametr =>
                {
                    string request = "Wait " + (int)(orderService.GetTimeWhenAllDishesAreCooked(lastOrder) - DateTime.Now).TotalMinutes + " minutes";
                    MessageBox.Show(request);
                },
                parametr =>
                {
                    return lastOrder != null;
                });
            }
        }

        private RelayCommand removeFromOrder;
        public RelayCommand RemoveFromOrder
        {
            get
            {
                return removeFromOrder ??= new RelayCommand(obj =>
                {
                    if (obj is OrderedDishWithAmount selectedDish)
                    {
                        if (selectedDish.Amount <= 1)
                        {
                            AmountOfOrderedDishes.Remove(selectedDish);
                        }
                        else
                        {
                            selectedDish.Amount--;
                        }
                    }
                });
            }
        }


        public MainViewModel(IOrderService orderService)
        {
            AmountOfOrderedDishes = new ObservableCollection<OrderedDishWithAmount>();
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

            this.orderService = orderService;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class OrderedDishWithAmount : INotifyPropertyChanged
    {
        public Dish OrderedDish { get; set; }

        private int amount = 1;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

