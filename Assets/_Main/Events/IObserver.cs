﻿namespace EdwinGameDev.Events
{
    public interface IObserver
    {
        // Receive update from subject
        void ReceiveNotification(ISubject subject);
    }
}