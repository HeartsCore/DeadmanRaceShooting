using System;

namespace DeadmanRace
{
    public sealed class TimeRemaining : ITimeRemaining
    {
        public float Time { get; set; }
        public bool IsTimeRemaining { get; set; } = true;
        public event EventHandler<RemoveUserEventArgs> StartTimerEventHandler;

        public void StartTimer(float rechergeTime)
        {
            StartTimerEventHandler?.Invoke(this, new RemoveUserEventArgs(rechergeTime));
        }
        
        public void StopTimer()
        {
            IsTimeRemaining = true;
        }
    }
}
