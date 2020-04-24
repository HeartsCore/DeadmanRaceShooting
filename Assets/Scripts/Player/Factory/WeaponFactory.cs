using UnityEngine;

namespace DeadmanRace
{
    public sealed class WeaponFactory
    {
        public Gun CreateGun(PoolObjectAmmunition poolObject)//
        {
            var gun = Resources.Load<WeaponBehaviour>("Prefabs/Gun");
            var player = Object.FindObjectOfType<PlayerBehaviour>();
            var gameObject = Object.Instantiate(gun, player.GunContainer.position, Quaternion.identity,
                player.GunContainer).gameObject;
            
            var result = new Gun(gameObject, poolObject);//
            return result;
        }
        public RpgGun CreateRpgGun(PoolObjectAmmunition poolObject)
        {
            var gun = Resources.Load<WeaponBehaviour>("Prefabs/RpgGun");
            var player = Object.FindObjectOfType<PlayerBehaviour>();
            var gameObject = Object.Instantiate(gun, player.GunContainer.position, Quaternion.identity,
                player.GunContainer).gameObject;

            var result = new RpgGun(gameObject, poolObject);
            return result;
        }
    }
}
