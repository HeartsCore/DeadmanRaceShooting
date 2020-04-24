using System.Collections;

namespace DeadmanRace
{
    public interface IWeapon
    {
        void Fire();
        void Reloading();
        IEnumerator ReadyShoot();
    }
}