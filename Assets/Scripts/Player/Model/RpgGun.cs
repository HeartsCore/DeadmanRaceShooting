using UnityEngine;


namespace DeadmanRace
{
    public sealed class RpgGun : Weapon
    {
        public RpgGun(GameObject gameObject, PoolObjectAmmunition poolObject) : base(gameObject, poolObject) { }//, PoolObjectAmmunition poolObject , poolObject
        public override void Fire()
        {
            //if (!_timeRemaining.IsTimeRemaining) return;
            if (Clip.CountAmmunition <= 0) return;
            var temAmmunition = _poolObject.GetObject(_weaponBehaviour.Barrel.position, _weaponBehaviour.Barrel.rotation);
            if (temAmmunition == null)
            {
                return;
            }
            temAmmunition.AddForce(_weaponBehaviour.Force);
            
            Clip.CountAmmunition--;
            _timeRemaining.StartTimer(_weaponBehaviour.RechergeTime);
        }
    }
}
