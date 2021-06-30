namespace EdwinGameDev.Events
{
    public interface ISubject
    {
        // Attach an observer to the subject.
        void Subscribe(IObserver observer);

        // Detach an observer from the subject.
        void UnSubscribe(IObserver observer);

        // Notify all observers about an event.
        void Notify();
    }
}