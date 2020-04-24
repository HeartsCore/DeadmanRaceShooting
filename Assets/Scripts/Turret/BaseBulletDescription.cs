using UnityEngine;
using DeadmanRace.Enums;
using DeadmanRace.Components;
using DeadmanRace.Interfaces;

namespace DeadmanRace.Items
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "Bullets/BaseBullet")]
    public class BaseBulletDescription : ScriptableObject, IItemDescription
    {
        
        [SerializeField]
        private int _iD;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private float _weight;

        [SerializeField]
        private Sprite _gameSprite;
                
        public Sprite GameSprite { get => _gameSprite; }
        [SerializeField] private string _bulletName;
        [SerializeField] private string _bulletDescription;
           
        [SerializeField] private float _bulletSpeed = 20.0f;
        [SerializeField] private float _bulletDamage = 30.0f;
        [SerializeField] private float _bulletLifetime = 5.0f;
        [SerializeField] private int _bulletClipCount = 5;

        [SerializeField] private BulletType _bulletType;

        public int BulletClipCount { get => _bulletClipCount; }
        public BulletType BulletType { get => _bulletType; }
        public string BulletName { get => _bulletName; }
        public string BulletDerscription { get => _bulletDescription; }
       
        public float BulletSpeed { get => _bulletSpeed; }
        public float BulletDamage { get => _bulletDamage; }

        public float BulletLifetime { get => _bulletLifetime; }
        public int ID { get => _iD; }

        public ItemTypes ItemType { get; protected set; }

        public Sprite Icon { get => _icon; }

        public float Weight { get => _weight; }

       
        
    }
}
