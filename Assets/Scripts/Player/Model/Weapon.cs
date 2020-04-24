using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DeadmanRace
{
    public abstract class Weapon : IModel, IInitialization
    {
        private Queue<Clip> _clips = new Queue<Clip>();
        private int _maxCountAmmunition = 40;
        private int _minCountAmmunition = 20;

        protected readonly ITimeRemaining _timeRemaining;
        protected readonly WeaponBehaviour _weaponBehaviour;
        protected PoolObjectAmmunition _poolObject;
        
        public HashSet<ITimeRemaining> _timeRemainings;
        public Clip Clip;
        public int CountClip => _clips.Count;
        public Transform Transform { get; }
        public GameObject GameObject { get; }
        
        public bool IsVisible
        {
            set
            {
                foreach (Transform d in Transform)
                {
                    var tempRenderer = d.GetComponent<Renderer>();
                    if (tempRenderer)
                    {
                        tempRenderer.enabled = value;
                    }
                }
            }
        }

        protected Weapon(GameObject weaponObject, PoolObjectAmmunition poolObject)
        {
            GameObject = weaponObject;
            Transform = weaponObject.transform;
            _weaponBehaviour = GameObject.GetComponent<WeaponBehaviour>();
            _poolObject = poolObject;
            _timeRemainings = new HashSet<ITimeRemaining>();
            _timeRemaining = new TimeRemaining();
            AddTime(_timeRemaining);
            Initialization();
        }

        public void Initialization()
        {
            for (var i = 0; i <= _weaponBehaviour.CountClip; i++)
            {
                AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });
            }

            ReloadClip();

        }

        public abstract void Fire();
        protected void AddClip(Clip clip) => _clips.Enqueue(clip);
        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
            //UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
        }
        public void AddTime(ITimeRemaining value)
        {
            //if (_timeRemainings.Contains(value))
            //{
            //    return;
            //}
            _timeRemainings.Add(value);
            value.StartTimerEventHandler += ValueOnStartTimerEventHandler;
        }

        public void Remove(ITimeRemaining value)
        {
            if (!_timeRemainings.Contains(value))
            {
                return;
            }
            _timeRemainings.Remove(value);
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
                
    }
}
