using System;

namespace TheDesignPatterns.NullObject
{
    public interface IMathService
    {
        public int Addition(int x, int y);
    }

    public class MathService : IMathService
    {
        private readonly ILogger logger;

        public MathService(ILogger logger)
        {
            this.logger = logger;
        }

        public int Addition(int x, int y)
        {
            logger.Log($"For addition the value of x={x} and y={y}");

            return x + y;
        }
    }

    public interface ILogger
    {
        public void Log(string logData);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string logData)
        {
            Console.WriteLine(logData);
        }
    }

    public class NullLogger : ILogger
    {
        public void Log(string logData)
        {
           // Do nothing
        }
    }
}
