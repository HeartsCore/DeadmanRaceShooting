using UnityEngine;


namespace DeadmanRace
{
    public sealed class AmmunitionLifeCycleController : BaseController, IExecuteController
    {
        
        private GameContext _context;
        public AmmunitionLifeCycleController(GameContext context, Services services)
        {
            _context = context;
            
        }

        public void Execute()
        {
            
            var deltaTime = Time.deltaTime * Time.timeScale;
            foreach (var obj in _context.BulletAmmunitions)
            {
                if (!obj.IsActive)
                {
                    continue;
                }

                obj.Transform.Translate(Vector3.forward * (deltaTime * obj.Force));
                
                if (obj.TimeRemaining.IsTimeRemaining)
                {
                    obj.DestroyAmmunition();
                }
            }
            foreach (var obj in _context.RpgBulletAmmunitions)
            {
                if (!obj.IsActive)
                {
                    continue;
                }

                obj.Transform.Translate(Vector3.forward * (deltaTime * obj.Force));

                if (obj.TimeRemaining.IsTimeRemaining)
                {
                    obj.DestroyAmmunition();
                }
            }
        }

        
    }
}
