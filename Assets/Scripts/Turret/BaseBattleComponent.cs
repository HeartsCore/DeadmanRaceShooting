using DeadmanRace.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeadmanRace
{
    public abstract class BaseBattleComponent<T> : IWeightComponent where T : class, IItemDescription
    {

        protected T _description;

        protected bool _descriptionIsNull = true;
        public virtual float GetWeight() => _descriptionIsNull ? 0f : _description.Weight;

        protected virtual void SetItem(IItemDescription description)
        {
            _description = description as T;
            if (_description != null) _descriptionIsNull = false;
        }

        protected virtual void ClearItem()
        {
            _description = null;
            _descriptionIsNull = true;
        }
    }
}

