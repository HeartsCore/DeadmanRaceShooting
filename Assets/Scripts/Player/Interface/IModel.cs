using UnityEngine;

namespace DeadmanRace
{
    public interface IModel
    {
        Transform Transform { get; }
        GameObject GameObject { get; }
    }
}
