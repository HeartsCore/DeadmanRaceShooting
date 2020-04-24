using System.Collections;
using UnityEngine;
using DeadmanRace.Components;
using DeadmanRace.Items;

namespace DeadmanRace
{
  
    public sealed class CarTurretBehaviour : BaseCarComponent<Turret>, IWeapon , IRotate
    {
        public GameObject СurrentBullet;

        public float CurentHealth { get; private set; }

        #region IRotate
        public Transform Transform { get; set; }
        public void LookRotation()
        {
            Vector3 MousePos = Input.mousePosition;
            //Convert the player’s coordinates from world to screen
            Vector3 CharacterPos = Camera.main.WorldToScreenPoint(Transform.position);
            var VectorToTarget = MousePos - CharacterPos;
            float angleToTarget = Mathf.Atan2(VectorToTarget.x, VectorToTarget.y) * Mathf.Rad2Deg;
            Transform.rotation = Quaternion.Euler(0, angleToTarget, 0);
        }
        #endregion


        public void Fire()
        {
            if (_description.WeaponVaribles.IsReloading) return;
            if (!_description.WeaponVaribles.IsReady) return;
            if (_description.WeaponVaribles.CurrentBulletCount <= 0) return;           // Если нужно перезаряжать при 0 автоматически, то можно форсированную перезарядку сделать                   
            GameObject bullet = Instantiate(СurrentBullet, _description.BulletSpawnPosition, Quaternion.identity);
            //bullet.AddComponent<BulletBehaviour>();
            
            //bullet.GetComponent<BulletBehaviour>().TargetVector = CalculateFireDirection();
            _description.WeaponVaribles.CurrentBulletCount--;
            _description.WeaponVaribles.IsReady = false;
            StartCoroutine(ReadyShoot());
           
        }

        public void Reloading()
        {
            StartReload();
            StartCoroutine(FinishReload());
        }

        public IEnumerator ReadyShoot()
        {
            yield return new WaitForSeconds(_description.WeaponVaribles.FireRate);
            _description.WeaponVaribles.IsReady = true;
        }

        private IEnumerator FinishReload()
        {
            yield return new WaitForSeconds(_description.WeaponVaribles.ReloadTimer);
            Debug.Log("finishReload!");
            _description.WeaponVaribles.IsReloading = false;
            _description.WeaponVaribles.CurrentBulletCount = _description.MagazineCapacity;
            _description.WeaponVaribles.CurrentMagazineCount--;
        }
        public Vector3 CalculateFireDirection()
        {
            Vector3 dir = transform.right;
            dir.y += Random.Range(-_description.WeaponVaribles.SpreadFactor, _description.WeaponVaribles.SpreadFactor);
            return dir;
        }

        public void StartReload()
        {
            if (_description.WeaponVaribles.CurrentMagazineCount <= 0) return;
            _description.WeaponVaribles.IsReloading = true;
        }
        
        public float MaxHealth
        {
            get
            {
                if (_descriptionIsNull) return 0f;

                return _description.MaxHealth;
            }
        }

        public void SetDamage(float damage)
        {
            CurentHealth -= damage;

            CurentHealth = CurentHealth <= 0f ? 0f : CurentHealth;
        }

    }
}
