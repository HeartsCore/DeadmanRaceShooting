using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DeadmanRace
{
    public sealed class PoolObjectAmmunition : IPoolObject<Ammunition>, IDisposable
    {
        
        private readonly AmmunitionType _ammunitionType;
        private readonly AmmunitionFactory _ammunitionFactory;
        private readonly int _sizePool;
        private readonly Transform _root;

        public Dictionary<int, Ammunition> PoolObjectsAmmunition;
        public HashSet<ITimeRemaining> TimeRemainings;
        public HashSet<Ammunition> Ammunitions;
        public ITimeRemaining TimeRemaining { get; set; }
        public AmmunitionBehaviour AmmunitionProviders { get; set; }
                
        public PoolObjectAmmunition(AmmunitionType ammunitionType)
        {
            PoolObjectsAmmunition = new Dictionary<int, Ammunition>(10);
            TimeRemainings = new HashSet<ITimeRemaining>();
            Ammunitions = new HashSet<Ammunition>();

            _ammunitionType = ammunitionType;
            _ammunitionFactory = new AmmunitionFactory();
            _sizePool = 50;
            _root = new GameObject("Root Pool Object Ammunition").transform;
            InitializationPool();
        }

        private void InitializationPool()
        {
            for (var i = 0; i < _sizePool; i++)
            {
                TimeRemaining = new TimeRemaining();
                var ammunition = CreateAmmunition();
                
                AddTime(TimeRemaining);
                PoolObjectsAmmunition[ammunition.GetHashCode()] = ammunition;
                AddAmmunition(ammunition);
                ReturnToPool(ammunition.GetHashCode());
            }
        }

        public Ammunition GetObject(Vector3 position, Quaternion rotation)
        {
            var result = PoolObjectsAmmunition.Values.FirstOrDefault(ammunition => !ammunition.GameObject.activeSelf);
            if (result == null)
            {
                InitializationPool();
                GetObject(position, rotation);
                return null;
            }
            
            result.Transform.position = position;
            result.Transform.rotation = rotation;
            result.SetActive(true);
            return result;
        }

        public void ReturnToPool(int hash)
        {
            
            var ammunition = PoolObjectsAmmunition[hash];
            ammunition.SetActive(false);
            ammunition.Transform.SetParent(_root);
        }

        public void ReturnAmmunitionToPool(Ammunition ammunition)
        {            
            ammunition.SetActive(false);
            ammunition.Transform.SetParent(_root);
        }

        private Ammunition CreateAmmunition()
        {
            Ammunition ammunition = null;
            switch (_ammunitionType)
            {
                case AmmunitionType.Bullet:
                    ammunition = _ammunitionFactory.CreateBullet(this);
                    break;
                case AmmunitionType.Rpg:
                    ammunition = _ammunitionFactory.CreateRpgBullet(this);
                    break;
                default:
                    break;
            }
            return ammunition;
        }

        public void Dispose()
        {
            foreach (var t in PoolObjectsAmmunition.Values)
            {
                Object.Destroy(t.GameObject);
            }
            Object.Destroy(_root.gameObject);
        }

        public void PutObjectBackInTub(GameObject gameObj)
        {
            PutObjectAway(gameObj);
        }
        private void PutObjectAway(GameObject gameObj)
        {
            gameObj.GetComponents<Ammunition>().ToList()
                .ForEach(poolableObj => poolableObj.DestroyAmmunition());
        }
        public void AddTime(ITimeRemaining value)
        {
            //if (_timeRemainings.Contains(value))
            //{
            //    return;
            //}
            TimeRemainings.Add(value);
            value.StartTimerEventHandler += ValueOnStartTimerEventHandler;
        }

        public void RemoveTime(ITimeRemaining value)
        {
            if (!TimeRemainings.Contains(value))
            {
                return;
            }
            TimeRemainings.Remove(value);
            value.StartTimerEventHandler -= ValueOnStartTimerEventHandler;
        }
        private void ValueOnStartTimerEventHandler(object sender, RemoveUserEventArgs e)
        {
            if (sender is ITimeRemaining obj)
            {
                obj.Time = e.Time;
                obj.IsTimeRemaining = false;
            }
        }
        public void AddAmmunition(Ammunition ammunition)
        {
            Ammunitions.Add(ammunition);
        }
    }
}
