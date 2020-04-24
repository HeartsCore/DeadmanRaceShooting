﻿using System.Collections.Generic;


namespace DeadmanRace
{
    public abstract class Controllers : IInitializeController, IExecuteController, ICleanupController, ITearDownController
    {
        #region Fields
        
        protected readonly List<IInitializeController> _initializeSystems;
        protected readonly List<IExecuteController> _executeSystems;
        protected readonly List<ICleanupController> _cleanupSystems;
        protected readonly List<ITearDownController> _tearDownSystems;

        #endregion 


        #region ClassLifeCycles
        
        protected Controllers()
        {
            _initializeSystems = new List<IInitializeController>();
            _executeSystems = new List<IExecuteController>();
            _cleanupSystems = new List<ICleanupController>();
            _tearDownSystems = new List<ITearDownController>();
        }

        #endregion


        #region Methods

        protected virtual Controllers Add(IController controller)
        {
            if (controller is ICleanupController cleanupController)
                    _cleanupSystems.Add(cleanupController);

            if (controller is IExecuteController executeController)
                    _executeSystems.Add(executeController);

            if (controller is IInitializeController initializeController)
                    _initializeSystems.Add(initializeController);

            if (controller is ITearDownController tearDownController)
                    _tearDownSystems.Add(tearDownController);
            
            return this;
        }

        #endregion


        #region IInitializeController
        
        public virtual void Initialize()
        {
            for (var index = 0; index < _initializeSystems.Count; ++index)
            {
                _initializeSystems[index].Initialize();
            }
        }

        #endregion


        #region IExecuteController
        
        public virtual void Execute()
        {
            for (var index = 0; index < _executeSystems.Count; ++index)
            {
                _executeSystems[index].Execute();
            }
        }

        #endregion


        #region ICleanupController

        public virtual void Cleanup()
        {
            for (var index = 0; index < _cleanupSystems.Count; ++index)
            {
                _cleanupSystems[index].Cleanup();
            }
        }

        #endregion

        #region ITearDownController

        public virtual void TearDown()
        {
            for (var index = 0; index < _tearDownSystems.Count; ++index)
            {
                _tearDownSystems[index].TearDown();
            }
        }

        #endregion
    }
}
