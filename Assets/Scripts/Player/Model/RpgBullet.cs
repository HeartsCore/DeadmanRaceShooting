using System;
using UnityEngine;


namespace DeadmanRace
{
    public sealed class RpgBullet : Ammunition, IDisposable
    {
        private readonly TrailRenderer _trailRenderer;
        private readonly float _timeTrailRenderer;
        //private PoolObjectAmmunition _poolObject;
        public RpgBullet(GameObject gameObject, PoolObjectAmmunition poolObject) : base(gameObject, poolObject)
        {
            _trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
            _timeTrailRenderer = _trailRenderer.time;
            //_poolObject = poolObject;
        }

        public override void SetActive(bool value)
        {
            base.SetActive(value);
            if (value)
            {
                _trailRenderer.time = _timeTrailRenderer;
                _trailRenderer.enabled = true;
            }
            else
            {
                _trailRenderer.Clear();
                _trailRenderer.time = 0.0f;
                _trailRenderer.enabled = false;
            }
        }

        public void Dispose()
        {
            //_poolObject.RemoveTime(TimeRemaining);
        }
    }
}
