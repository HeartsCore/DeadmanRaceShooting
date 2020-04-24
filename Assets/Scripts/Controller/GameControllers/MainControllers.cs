namespace DeadmanRace
{
    public sealed class MainControllers : Controllers
    {
        #region ClassLifeCycles
        
        public MainControllers(GameContext context, Services services)
        {
            
            Add(new InitializationPlayerController(context, services));
            Add(new InitMyWeapon(context, services));
            
            Add(new InputController(context, services));

            Add(new CarInitializeController(context, services));

            Add(new TimeRemainingController(context, services));
            Add(new AmmunitionApplyDamageController(context, services));
            Add(new AmmunitionLifeCycleController(context, services));
        }

        #endregion
    }
}
