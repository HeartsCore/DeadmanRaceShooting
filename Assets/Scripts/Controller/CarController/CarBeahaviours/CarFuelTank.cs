﻿using DeadmanRace.Items;
using DeadmanRace.Enums;

namespace DeadmanRace.Components
{
    public sealed class CarFuelTank : BaseCarComponent<FuelTank>, ISetDamage<float>
    {
        public float CurentHealth { get; private set; }

        public float MaxHealth { get; private set; }

        public float CurentFuelValue { get; private set; }

        public FuelTypes CurentFuelType { get; private set; } = FuelTypes.Good;

    
        public override float GetWeight() => _descriptionIsNull ? 0f : _description.Weight * (CurentFuelValue / _description.Capacity);
        
        public float GetFuel(float amount, out FuelTypes type)
        {
            type = CurentFuelType;

            if (CurentFuelValue > amount)
            {
                CurentFuelValue -= amount;

                return amount;
            }

            var valueToReturn = CurentFuelValue;

            CurentFuelValue = 0f;

            return valueToReturn;
        }

        public void AddFuel(float amount, FuelTypes type)
        {
            CurentFuelType = (int)CurentFuelType > (int)type ? type : CurentFuelType;

            CurentFuelValue += amount;

            CurentFuelValue = CurentFuelValue > _description.Capacity ? _description.Capacity : CurentFuelValue;
        }


        public void SetDamage(float damage)
        {
            CurentHealth -= damage;

            CurentHealth = CurentHealth <= 0f ? 0f : CurentHealth;
        }
    }
}