using System.Collections.Generic;
using UnityEngine;

namespace DeadmanRace
{
    public sealed class AmmunitionApplyDamageController : BaseController, IExecuteController
    {
        private GameContext _context;
        

        public AmmunitionApplyDamageController(GameContext context, Services services)
        {
            _context = context;
            
            
        }

        public void Execute()
        {
            if (!IsActive)
            {
                return;
            }

            foreach (var ammunitionObject in _context.BulletAmmunitions)
            {
                if (!ammunitionObject.IsActive)
                {
                    continue;
                }
                if (Physics.Raycast(ammunitionObject.Transform.position, ammunitionObject.Transform.TransformDirection(Vector3.forward),
                    out var hit, ammunitionObject.MaxDistance))
                {
                    AmmunitionApplyDamage(ammunitionObject, hit.collider);
                }
            }
            foreach (var ammunitionObject in _context.RpgBulletAmmunitions)
            {
                if (!ammunitionObject.IsActive)
                {
                    continue;
                }
                if (Physics.Raycast(ammunitionObject.Transform.position, ammunitionObject.Transform.TransformDirection(Vector3.forward),
                    out var hit, ammunitionObject.MaxDistance))
                {
                    AmmunitionApplyDamage(ammunitionObject, hit.collider);
                }
            }
        }
              

        private void AmmunitionApplyDamage(Ammunition ammunition, Collider collision)
        {
            // дописать доп урон
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();

            if (tempObj != null)
            {
                tempObj.SetDamage(new InfoCollision(ammunition.CurDamage));
            }

            ammunition.DestroyAmmunition();
        }
    }
}
