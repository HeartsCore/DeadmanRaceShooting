using UnityEngine;


namespace DeadmanRace
{
    public sealed class AmmunitionFactory
    {
        
        public Bullet CreateBullet(PoolObjectAmmunition poolObject)
        {
            var bullet = Resources.Load<AmmunitionBehaviour>("Prefabs/Bullet");
            var gameObject = Object.Instantiate(bullet).gameObject;
            var result = new Bullet(gameObject, poolObject);
            
            return result;
        }
        public RpgBullet CreateRpgBullet(PoolObjectAmmunition poolObject)
        {
            var bullet = Resources.Load<AmmunitionBehaviour>("Prefabs/RpgBullet");
            var gameObject = Object.Instantiate(bullet).gameObject;
            var result = new RpgBullet(gameObject, poolObject);
            return result;
        }
    }
}
