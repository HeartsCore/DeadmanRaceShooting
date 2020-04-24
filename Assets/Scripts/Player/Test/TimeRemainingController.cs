using System.Linq;
using UnityEngine;


namespace DeadmanRace
{
    public sealed class TimeRemainingController : BaseController, IExecuteController
    {
        
        private GameContext _context;
        public TimeRemainingController(GameContext context, Services services)
        {
            _context = context;
        }

        public void Execute()
        {
            
            var deltaTime = Time.deltaTime * Time.timeScale;
            foreach (var obj in _context.BulletTimeRemainings.Where(obj => !obj.IsTimeRemaining))
            {
                obj.Time -= deltaTime;
                if (obj.Time <= 0.0f)
                {
                    CompletedTimeRemaining(obj);
                }
            }
            foreach (var obj in _context.RpgBulletTimeRemainings.Where(obj => !obj.IsTimeRemaining))
            {
                obj.Time -= deltaTime;
                if (obj.Time <= 0.0f)
                {
                    CompletedTimeRemaining(obj);
                }
            }
        }

        private void CompletedTimeRemaining(ITimeRemaining value)
        {
            value.IsTimeRemaining = true;
        }
                
    }
}
