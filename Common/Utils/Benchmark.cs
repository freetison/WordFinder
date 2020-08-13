using System;
using System.Diagnostics;

namespace Common.Utils
{
    public class Benchmark : IDisposable
    {
        private readonly string _message;
        private readonly Stopwatch _timer = new Stopwatch();

        public Benchmark(string message)
        {
            _message = message;
            _timer.Start();
        }

        public void Dispose()
        {
            _timer.Stop();
            Console.WriteLine($"{_message} {_timer.Elapsed:dd\\:hh\\:mm\\:ss\\.fff}");
        }
    }
}