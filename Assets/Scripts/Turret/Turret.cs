using UnityEngine;
using DeadmanRace.Enums;
using DeadmanRace.Components;

namespace DeadmanRace.Items
{
    [CreateAssetMenu(fileName = "New Turret", menuName = "Items/Car/Create Turret")]
    public sealed class Turret : CarItemDescription
    {
        
        
        [Range(0f, 100f)]
        [SerializeField]private float _maxHealth;

        [SerializeField]
        [Range(0f, 100f)]
        private float _consumedTurretEnergy;
        [SerializeField]private Vector3 _hitboxSize = new Vector3(0.3f, 0.3f, 1.0f);
        [SerializeField]private Vector3 _spriteScale = Vector3.one;
        [SerializeField]private Vector3 _spriteRotation = new Vector3(90f, 0f, 0f);
        [SerializeField]private Vector3 _turretPosition = new Vector3(0f, 0.03f, 0f);
        [SerializeField]private Vector3 _bulletSpawnPosition = new Vector3(0f, 0f, 1.0f);
        [Header ("WEAPON characteristics")]
        [SerializeField] private string _weaponName;
        [SerializeField] [TextArea(2, 5)] private string _weaponDescription;
        [Range(0f, 100f)]
        [SerializeField] private int _magazineCapacity = 10;
        [Range(0f, 20f)]
        [SerializeField] private int _magazineCount = 5;
        [Range(0.5f, 20f)]
        [SerializeField] private float _reloadSpeed = 2.0f;
        [SerializeField] private float _bulletPerSecond = 20.0f;
        [SerializeField] private float _fireSpread;
        
        public string WeaponName { get => _weaponName; }
        public string WeaponDerscription { get => _weaponDescription; }

        public int MagazineCapacity { get => _magazineCapacity; }
        public int MagazineCount { get => _magazineCount; }
        public float ReloadSpeed { get => _reloadSpeed; }
        public float BulletPerSecond { get => _bulletPerSecond; }
        public float FireSpread { get => _fireSpread; }
        public Vector3 HitboxSize { get => _hitboxSize; }
        public float MaxHealth { get => _maxHealth; }
        public float ConsumedTurretEnergy { get => _consumedTurretEnergy; }
        public Vector3 BulletSpawnPosition { get => _bulletSpawnPosition; }


        public Varibles WeaponVaribles;
        
        public override void InstantiateObject(Transform parent, Vector3 position)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent);

            var collider = obj.AddComponent<BoxCollider>();
            collider.size = _hitboxSize;
            collider.center = position;
            collider.isTrigger = true;

                       
            var spriteObj = new GameObject("SpriteTurret");
            spriteObj.transform.SetParent(obj.transform);
            spriteObj.transform.localPosition = _turretPosition;
            spriteObj.transform.localEulerAngles = _spriteRotation;
            spriteObj.transform.localScale = _spriteScale;
            spriteObj.AddComponent<SpriteRenderer>().sprite = GameSprite;

            if (!_createEmpty) obj.AddComponent<CarTurretBehaviour>().Initialize(this);
            else obj.AddComponent<CarTurretBehaviour>().Initialize(ItemType);
            
            
        }

        protected override void OnEnable()
        {
            ItemType = ItemTypes.Weapon;
        }
    }
}