using System.Collections.Generic;
using System.Linq;
using DeadmanRace.Models;


namespace DeadmanRace
{
    public sealed class GameContext : Contexts
    {

        private Weapon[] _weapons;// = new Weapon[9];
        public Weapon[] Weapons => _weapons;
        private int _selectIndexWeapon = 0;

        private readonly SortedList<TriggerObjectType, List<IOnTrigger>> _onTriggers;
        private readonly SortedList<TimeRemainingObject, List<ITimeRemaining>> _timeRemainings;
        public List<Bullet> AmmunitionsContext;


        public Dictionary<int, Ammunition> BulletContext;
        public Dictionary<int, Ammunition> RpgBulletContext;
        public HashSet<ITimeRemaining> BulletTimeRemainings;
        public HashSet<ITimeRemaining> RpgBulletTimeRemainings;
        public HashSet<Ammunition> BulletAmmunitions;
        public HashSet<Ammunition> RpgBulletAmmunitions;
        #region Fields

        public MyCharacter MyCharacter;
        public CarModel PlayerCar;
        
        
        public WeaponController WeaponController;
        //public TaskManager TaskManager;
        #endregion


        #region ClassLifeCycles

        public GameContext()
        {
            _onTriggers = new SortedList<TriggerObjectType, List<IOnTrigger>>();
            _timeRemainings = new SortedList<TimeRemainingObject, List<ITimeRemaining>>();
            _weapons = new Weapon[9];
            
        }

        #endregion


        #region Methods
        public void AddArrayElement(Weapon weapon)
        {
             List<Weapon> tmpList = _weapons.ToList();
             tmpList.Add(weapon);
             _weapons = tmpList.ToArray();
        }
        public List<Bullet> AddToList(Bullet value, int size)
        {
            AmmunitionsContext = new List<Bullet>();
            for (int i = 0; i < size; i++)
            {
                AmmunitionsContext.Add(value);
            }
            return AmmunitionsContext;

        }



        public void AddTriggers(TriggerObjectType type, IOnTrigger trigger)
        {
            if (_onTriggers.ContainsKey(type))
            {
                _onTriggers[type].Add(trigger);
            }
            else
            {
                _onTriggers.Add(type, new List<IOnTrigger>
                {
                    trigger
                });
            }
        }

        public void AddTiming(TimeRemainingObject obj, ITimeRemaining timing)
        {
            if (_timeRemainings.ContainsKey(obj))
            {
                _timeRemainings[obj].Add(timing);
            }
            else
            {
                _timeRemainings.Add(obj, new List<ITimeRemaining>
                {
                    timing
                });
            }
        }

        public List<T> GetTriggers<T>(TriggerObjectType type) where T : class, IOnTrigger
        {
            return _onTriggers[type].Select(trigger => trigger as T)
                .ToList();
        }


        public List<T> GetTimings<T>(TimeRemainingObject obj) where T : class, ITimeRemaining
        {
            return _timeRemainings[obj].Select(timing => timing as T)
                .ToList();
        }

        public T GetClassTimings<T>(TimeRemainingObject obj) where T : class, ITimeRemaining
        {
            return _timeRemainings[obj].Select(timing => timing as T).FirstOrDefault();

        }

        public Weapon SelectWeapon(int weaponNumber)
        {

            if (weaponNumber < 0 || weaponNumber >= Weapons.Length) return null;
            var tempWeapon = Weapons[weaponNumber];
            return tempWeapon;
        }
        public Weapon SelectWeapon(MouseScrollWheel scrollWheel)
        {
            if (scrollWheel == MouseScrollWheel.Up)
            {
                if (_selectIndexWeapon < Weapons.Length - 1)
                {
                    _selectIndexWeapon++;
                }
                else
                {
                    _selectIndexWeapon = -1;
                }
                return SelectWeapon(_selectIndexWeapon);
            }

            if (_selectIndexWeapon <= 0)
            {
                _selectIndexWeapon = Weapons.Length;
            }
            else
            {
                _selectIndexWeapon--;
            }
            return SelectWeapon(_selectIndexWeapon);
        }
        #endregion
    }
}
