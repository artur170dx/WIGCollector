using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WIGCollector.Model;

namespace WIGCollector
{
    public class WIGCollector
    {
        private TimeSpan defaultInterval = new TimeSpan(0, 1, 0);
        private Timer timer;
        private TimeSpan interval;
        private CollectorBrain brain;
      
        public WIGCollector()
        {
            interval = defaultInterval;
            brain = new CollectorBrain(Factory.GetDownloader(), Factory.GetDataBase());
            TimerCallback tmCallback = Callback;
            timer = new Timer(tmCallback, "", Timeout.Infinite, Timeout.Infinite);
        }

        public void Run()
        {
            TimerOn();
        }

        public void ChangeInterval(int intervalInSeconds)
        {
            TimeSpan requestedInterval = new TimeSpan(0, 0, intervalInSeconds);
            bool timerSuccessfullyChanged = timer.Change(requestedInterval, requestedInterval);
            if (timerSuccessfullyChanged)
            {
                interval = requestedInterval;
            }
        }

        private void Callback(object objectInfo)
        {
            brain.Do();
        }

        private void TimerOn()
        {
            timer.Change(interval, interval);
        }
    }
}
