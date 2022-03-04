using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using MVVM_GUI.Logic;
using MVVM_GUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_GUI.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IArmyLogic logic;
        public ObservableCollection<Trooper> Barrack { get; set; }
        public ObservableCollection<Trooper> Army { get; set; }

        private Trooper selectedFromBarrack;

        public Trooper SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set
            {
                SetProperty(ref selectedFromBarrack, value);
                (AddToArmy as RelayCommand).NotifyCanExecuteChanged();
                (EditTrooper as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Trooper selectedFromArmy;

        public Trooper SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmy as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public int AllCost { get { return logic.AllCost; } }
        public double AvgPower { get { return logic.AvgPower; } }
        public double AvgSpeed { get { return logic.AvgSpeed; } }
        public ICommand AddToArmy { get; set; }
        public ICommand RemoveFromArmy { get; set; }
        public ICommand EditTrooper { get; set; }
         public static bool IsInDesignMode 
        { 
            get 
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel(IArmyLogic logic)
        {
            Barrack = new ObservableCollection<Trooper>();
            Army = new ObservableCollection<Trooper>();
            this.logic = logic;
            Barrack.Add(new Trooper() { Type = "marine", Speed = 1, Power = 2 });
            Barrack.Add(new Trooper() { Type = "tank", Speed = 2, Power = 10 });
            Barrack.Add(new Trooper() { Type = "medic", Speed = 5, Power = 0 });
            Barrack.Add(new Trooper() { Type = "pilot", Speed = 4, Power = 3 });

            Army.Add(Barrack[1].GetCopy());
            Army.Add(Barrack[3].GetCopy());

            logic.SetupCollections(Barrack, Army);

            AddToArmy = new RelayCommand(
                () => logic.AddToArmy(selectedFromBarrack.GetCopy()),
                () => selectedFromBarrack != null
                );
            RemoveFromArmy = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy),
                () => selectedFromArmy != null
                );
            EditTrooper = new RelayCommand(
                () => logic.EditTrooper(SelectedFromBarrack),
                () => selectedFromBarrack != null
                );
            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (rec, msg) =>
            {
                OnPropertyChanged("AllCost");
                OnPropertyChanged("AvgPower");
                OnPropertyChanged("AvgSpeed");
            });
        }
        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
        {

        }
       
    }
}
