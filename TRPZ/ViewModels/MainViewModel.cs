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
        private readonly IDishService dishService;

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


        public MainViewModel(IOrderService orderService, IDishService dishService)
        {
            this.orderService = orderService;
            this.dishService = dishService;

            AmountOfOrderedDishes = new ObservableCollection<OrderedDishWithAmount>();
            Dishes = new ObservableCollection<Dish>(dishService.GetAll());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

