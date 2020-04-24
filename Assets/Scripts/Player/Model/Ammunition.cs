using System.Collections;
using UnityEngine;


namespace DeadmanRace
{
    public abstract class Ammunition : IModel
    {
        #region PrivateData
        
        private readonly PoolObjectAmmunition _poolObject;
        private float _contactOffSet;
        #endregion
        
        #region Property
        public float Force { get; private set; }
        public ITimeRemaining TimeRemaining { get; }
        public GameObject GameObject { get; }
        public Transform Transform { get; }
        public AmmunitionBehaviour AmmunitionProviders { get; }
        public float CurDamage { get; }
        public float TimeToDestruct { get; }
        public float MaxDistance { get; } = 5;
        public bool IsActive { get; private set; }
        #endregion

        protected Ammunition(GameObject bulletObject, PoolObjectAmmunition poolObject)
        {
            _poolObject = poolObject;
            TimeRemaining = poolObject.TimeRemaining;
            GameObject = bulletObject;
            Transform = GameObject.transform;
            AmmunitionProviders = GameObject.GetComponent<AmmunitionBehaviour>();

            TimeToDestruct = AmmunitionProviders.TimeToDestruct;
            CurDamage = AmmunitionProviders.CurDamage;
            _contactOffSet = GameObject.GetComponent<Renderer>().bounds.extents.z;
            MaxDistance += _contactOffSet;
            
        }

        public virtual void SetActive(bool value)
        {
            IsActive = value;
            if (value)
            {
                Transform.SetParent(null);
                GameObject.SetActive(true);
                
                TimeRemaining.StartTimer(AmmunitionProviders.TimeToDestruct);
            }
            else
            {
                GameObject.SetActive(false);
                Transform.position = Vector3.zero;
                TimeRemaining.StopTimer();
                Force = 0;
            }
        }

        public void DestroyAmmunition()
        {
            _poolObject.ReturnToPool(GetHashCode());
        }
                
        public void AddForce(float force)
        {
            Force = force;
        }

        public IEnumerator DespawnAfterSomeTime(float someTime)
        {
            
            yield return new WaitForSeconds(someTime);
            CustomDebug.Log(someTime);
            DestroyAmmunition();

        }
        
    }
}
