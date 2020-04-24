using UnityEngine;

namespace DeadmanRace
{
    public sealed class AmmunitionBehaviour : MonoBehaviour
    {
        public float TimeToDestruct = 5;
        public float BaseDamage = 10;
        public float CurDamage;
        public AmmunitionType Type = AmmunitionType.Bullet;
        
        private void Awake()
        {
            CurDamage = BaseDamage;
            
        }
        #region Пробы

        //private IEnumerator DespawnAfterSomeTime(float someTime)
        //{
        //    yield return new WaitForSeconds(someTime);
        //    Pool.PutObjectBackInTub(gameObject); //(Ammunition)gameObject
        //}

        //public void InitializeForUse()
        //{
        //    //transform.localPosition = Vector3.zero;
        //    //rb.velocity = Vector3.zero;
        //    //rb.angularVelocity = Vector3.zero;
        //    StartCoroutine(DespawnAfterSomeTime(TimeToDestruct));
        //}
        //private void OnEnable()
        //{
        //    PoolObjectAmmunition.OnGetPoolObject += InitializeForUse;
        //    //PoolObjectAmmunition.OnGetPoolObject += AddBulletToPool;
        //    //InputController.OnInputFire += AddBulletToPool;
        //    //Weapon.StartWeaponTimer += AddBulletToPool;
        //}
        //private void OnDisable()
        //{
        //    PoolObjectAmmunition.OnGetPoolObject -= InitializeForUse;
        //    //PoolObjectAmmunition.OnGetPoolObject -= AddBulletToPool;
        //    //InputController.OnInputFire -= AddBulletToPool;
        //    //Weapon.StartWeaponTimer -= AddBulletToPool;
        //}
        #endregion
    }
}
