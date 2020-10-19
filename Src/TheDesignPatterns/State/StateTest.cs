using FluentAssertions;
using Xunit;

namespace TheDesignPatterns.State
{
    public class StateTest
    {
        [Fact]
        public void ShouldStartVideoPalyer()
        {
            var startedState = new StartedState();
            var videoPlayer = new VideoPlayer();
            videoPlayer.ChangeState(startedState);

            videoPlayer.Operate();

            videoPlayer.CurrentState.Should().BeEquivalentTo(startedState);
        }

        [Fact]
        public void ShouldPauseVideoPalyer()
        {
            var pausedState = new PausedState();
            var videoPlayer = new VideoPlayer();
            videoPlayer.ChangeState(pausedState);

            videoPlayer.Operate();

            videoPlayer.CurrentState.Should().BeEquivalentTo(pausedState);
        }

        [Fact]
        public void ShouldStoppedVideoPalyer()
        {
            var stoppedState = new StoppedState();
            var videoPlayer = new VideoPlayer();
            videoPlayer.ChangeState(stoppedState);

            videoPlayer.Operate();

            videoPlayer.CurrentState.Should().BeEquivalentTo(stoppedState);
        }
    }
}
