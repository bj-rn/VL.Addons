using VL.Lib.Collections;
using VL.Core.CompilerServices;
using System.Reactive.Subjects;

namespace VL.Stride.Input
{
    [Serializable]
    public class GameControllerDeviceEnum : DynamicEnumBase<GameControllerDeviceEnum, GameControllerDeviceEnumDefinition>
    {
        public GameControllerDeviceEnum(string value) : base(value)
        {
        }

        [CreateDefault]
        public static GameControllerDeviceEnum CreateDefault()
        {
            return CreateDefaultBase();
        }
    }

    public class GameControllerDeviceEnumDefinition : DynamicEnumDefinitionBase<GameControllerDeviceEnumDefinition>
    {
        Dictionary<string, object> entries = new Dictionary<string, object>();
        Subject<object> trigger = new Subject<object>();


        public void AddEntry(string name)
        {
            entries[name] = null;
            trigger.OnNext("");
        }

        public void RemoveEntry(string name)
        {
            entries.Remove(name);
            trigger.OnNext("");
        }

        public void ClearEntries()
        {
            entries.Clear();
            trigger.OnNext("");
        }

        protected override IReadOnlyDictionary<string, object> GetEntries()
        {
            return entries;
        }

        protected override IObservable<object> GetEntriesChangedObservable()
        {
            return trigger;
        }

        protected override bool AutoSortAlphabetically => true;

    }

}
