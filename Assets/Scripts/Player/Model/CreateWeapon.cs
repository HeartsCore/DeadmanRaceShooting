using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeadmanRace
{
    public abstract class CreateWeapon : IModel
    {

        private readonly PoolObjectAmmunition _poolObject;
        private readonly Weapon _weapon;
        public GameObject GameObject { get; }
        public Transform Transform { get; }

        public CreateWeapon(Weapon weapon, PoolObjectAmmunition poolObject)
        {

        }
    }

}
