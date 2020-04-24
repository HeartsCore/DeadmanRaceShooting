using UnityEngine;

namespace DeadmanRace
{
    public sealed class WeaponBehaviour : MonoBehaviour
    {
        public Transform Barrel;
        public float Force = 999;
        public float RechergeTime = 0.2f;
        public int CountClip = 5;
        public AmmunitionType AmmunitionType;
    }
}
