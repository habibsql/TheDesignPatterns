using System.Diagnostics;

namespace TheDesignPatterns.State
{
    public interface IState
    {
        void Handle(VideoPlayer videoPalyer);      
    }


    public class StartedState : IState
    {
        public void Handle(VideoPlayer videoPalyer)
        {
            if (!(videoPalyer.CurrentState is StartedState))
            {
                Debug.WriteLine($"Video is started");
            }
        }
    }

    public class PausedState : IState
    {
        public void Handle(VideoPlayer videoPalyer)
        {
            if (!(videoPalyer.CurrentState is PausedState))
            {
                Debug.WriteLine($"Video is Paused");
            }
        }
    }

    /// <summary>
    /// State
    /// </summary>
    public class StoppedState : IState
    {
        public void Handle(VideoPlayer videoPalyer)
        {
            if (!(videoPalyer.CurrentState is PausedState))
            {
                Debug.WriteLine($"Video is Stopped");
            }
        }
    }

    /// <summary>
    /// Context class
    /// </summary>
    public class VideoPlayer
    {
        public IState CurrentState { get; private set; }

        public void ChangeState(IState state)
        {
            this.CurrentState = state;
        }

        public void Operate()
        {
            CurrentState.Handle(this);
        }       
    }



}
