﻿using UnityEngine;
using DeadmanRace.Enums;
using DeadmanRace.Components;

namespace DeadmanRace.Items
{
    [CreateAssetMenu(fileName = "New Engine", menuName = "Items/Car/Create engine")]
    public class Engine : CarItemDescription
    {
        [SerializeField]
        private Vector3 _hitboxSize;

        [SerializeField]
        private float _maxSpeed;

        [SerializeField]
        private float _power;

        [SerializeField]
        private float _maxHealth;

        [SerializeField]
        [Range(0f, 100f)]
        private float _fuelConsumption;
         
        [SerializeField]
        [Range(0f, 1f)]
        private float _reducePowerByFuel;

        [SerializeField]
        [Min(0f)]
        private float _damageByFuel;

        public float ReducePowerByFuel { get => 1f - _reducePowerByFuel; }

        public float MaxSpeed { get => _maxSpeed; }

        public float Power { get => _power; }

        public float MaxHealth { get => _maxHealth; }

        public float FuelConsumption { get => _fuelConsumption; }

        public override void InstantiateObject(Transform parent, Vector3 position)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent);

            var collider = obj.AddComponent<BoxCollider>();
            collider.size = _hitboxSize;
            collider.center = position;
            collider.isTrigger = true;

            if (!_createEmpty) obj.AddComponent<CarEngine>().Initialize(this);
            else obj.AddComponent<CarEngine>().Initialize(ItemType);
        }

        protected override void OnEnable()
        {
            ItemType = ItemTypes.Engine;
        }
    }
}