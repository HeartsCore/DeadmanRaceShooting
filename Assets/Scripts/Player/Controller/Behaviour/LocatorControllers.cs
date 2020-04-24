using UnityEngine;


namespace DeadmanRace
{
    public sealed class LocatorControllers : MonoBehaviour
    {
        private ServiceLocatorControllers _controllers;
        private void Start()
        {
            _controllers = new ServiceLocatorControllers();
            _controllers.Initialization();
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute();
            }
        }
    }
}
