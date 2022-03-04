using Microsoft.Toolkit.Mvvm.Messaging;
using MVVM_GUI.Models;
using MVVM_GUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_GUI.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<Trooper> Barracks;
        IList<Trooper> Army;
        IMessenger messenger;
        ITrooperEditorService service;
        public ArmyLogic(IMessenger messenger, ITrooperEditorService service)
        {
            this.messenger = messenger;
            this.service = service;
        }
        public void SetupCollections(IList<Trooper> barracks, IList<Trooper> army)
        {
            Barracks = barracks;
            Army = army;
        }
        public void AddToArmy(Trooper trooper)
        {
            this.Army.Add(trooper);
            messenger.Send("TrooperAdded", "TrooperInfo");
        }
        public void RemoveFromArmy(Trooper trooper)
        {
            this.Army.Remove(trooper);
            messenger.Send("TrooperRemoved", "TrooperInfo");
        }
        public void EditTrooper(Trooper trooper)
        {
            service.Edit(trooper);
        }
        public int AllCost { get { return Army.Count == 0 ? 0 : Army.Sum(y => y.Cost); } }
        public double AvgPower { get { return Math.Round(Army.Count == 0 ? 0 : Army.Average(y => y.Power),2); } }
        public double AvgSpeed { get { return Math.Round(Army.Count == 0 ? 0 : Army.Average(y => y.Speed),2); } }

    }
}
