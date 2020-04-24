using UnityEngine;

namespace DeadmanRace
{
    public class WallBehaviour : MonoBehaviour, ISelectObj
    {
        public string GetMessage()
        {
            return name;
        }
    }
}
