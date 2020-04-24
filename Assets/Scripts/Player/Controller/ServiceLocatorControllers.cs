namespace DeadmanRace
{
    public sealed class ServiceLocatorControllers
    {
        private readonly IExecute[] _executeControllers;

        public int Length => _executeControllers.Length;
        public ServiceLocatorControllers()
        {
            
            //ServiceLocator.SetService(new InitAllWeapons());
            
           // ServiceLocator.SetService(new WeaponController());
            //ServiceLocator.SetService(new TimeRemainingController());
            //ServiceLocator.SetService(new AmmunitionLifeCycleController());
            //ServiceLocator.SetService(new AmmunitionApplyDamageController());
            
            _executeControllers = new IExecute[3];
            
            //_executeControllers[0] = ServiceLocator.Resolve<TimeRemainingController>();
            //_executeControllers[1] = ServiceLocator.Resolve<AmmunitionLifeCycleController>();
            //_executeControllers[2] = ServiceLocator.Resolve<AmmunitionApplyDamageController>();
        }
        
        public IExecute this[int index] => _executeControllers[index];

        public void Initialization()
        {
            //ServiceLocator.Resolve<InitAllWeapons>().Initialization();
            foreach (var controller in _executeControllers)
            {
                if (controller is IInitialization initialization)
                {
                    initialization.Initialization();
                }
            }

            
            //ServiceLocator.Resolve<TimeRemainingController>().On();
            //ServiceLocator.Resolve<AmmunitionLifeCycleController>().On();
            //ServiceLocator.Resolve<AmmunitionApplyDamageController>().On();
        }
    }
}
