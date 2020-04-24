using UnityEngine;

namespace DeadmanRace
{
    public interface IRotate
    {
        Transform Transform { get; set; }
        void LookRotation();
    }
}
