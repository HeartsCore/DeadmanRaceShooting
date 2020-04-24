using UnityEngine;

namespace DeadmanRace
{
    public sealed class PlayerBehaviour : MonoBehaviour
    {
        #region Properties
        
        public Collider Collider { get; private set; }
        public Transform GunContainer;
        #endregion


        #region UnityMethods

        private void Awake()
        {
            Collider = GetComponent<Collider>();
        }

        #endregion
    }
}
