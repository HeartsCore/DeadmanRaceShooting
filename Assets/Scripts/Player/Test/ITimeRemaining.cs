﻿using System;

namespace DeadmanRace
{
    public interface ITimeRemaining
    {
        float Time { get; set; }
        bool IsTimeRemaining { get; set; }
        event EventHandler<RemoveUserEventArgs> StartTimerEventHandler;
        void StartTimer(float rechergeTime);
        void StopTimer();
    } 
    
    public sealed class RemoveUserEventArgs : EventArgs
    {
        public float Time { get; }
        public RemoveUserEventArgs(float time)
        {
            Time = time;
        }
    }
}
