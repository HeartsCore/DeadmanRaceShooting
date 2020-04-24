using System;

namespace DeadmanRace.Items
{
    [Serializable]
    public class Varibles
    {
        public bool IsReady = true;

        public float ReloadTimer;
        public bool IsReloading;

        public int CurrentBulletCount;
        public int CurrentMagazineCount;

        public float SpreadFactor;
        public float FireRate;
    }
}