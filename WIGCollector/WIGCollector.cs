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

        public WIGCollector()
        {
            interval = defaultInterval;
        }

        public void Run()
        {
            TimerCallback tmCallback = Callback;
            timer = new Timer(tmCallback, "", interval, interval);
        }

        public void ChangeInterval(TimeSpan requestedInterval)
        {
            bool timerSuccessfullyChanged = timer.Change(requestedInterval, requestedInterval);
            if (timerSuccessfullyChanged)
            {
                interval = requestedInterval;
            }
        }

        private void Callback(object objectInfo)
        {
            CollectorBrain brain = new CollectorBrain(Factory.GetDownloader(), Factory.GetDataBase());
            brain.Do();
        }

    }
}
