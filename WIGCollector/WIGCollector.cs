using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WIGCollector.Model;

namespace WIGCollector
{
    /* Aplikacja pobiera kursy ze strony http://stooq.pl <http://stooq.pl/> . 
     * Dokładniej aplikacja ma pobierać w określonych konfigurowalnych 
     * odstępach czasowych (wstępnie co 1 minutę) wartości WIG, WIG20, WIG20 
     * Fut, mWIG40, sWIG80 i zapisywać w wybranym miejscu 
     * czas pobrania i wartości. Wartości zapisujemy tylko wtedy
     * gdy się zmieniły od poprzedniego razu.*/
    public class WIGCollector
    {
        private TimeSpan defaultInterval = new TimeSpan(0, 1, 0);
        private Timer timer;
        private CollectorBrain brain;
      
        public WIGCollector()
        {
            brain = new CollectorBrain(Factory.GetDownloader(), Factory.GetDataBase());
            TimerCallback tmCallback = Callback;
            timer = new Timer(tmCallback, "", Timeout.Infinite, Timeout.Infinite);
        }

        public void Run()
        {
            TimerOn();
        }

        public void ChangeInterval(uint intervalInSeconds)
        {
            TimeSpan requestedInterval = new TimeSpan(0, 0, Convert.ToInt32(intervalInSeconds));
            bool timerSuccessfullyChanged = timer.Change(requestedInterval, requestedInterval);
        }

        private void Callback(object objectInfo)
        {
            brain.Do();
        }

        private void TimerOn()
        {
            timer.Change(defaultInterval, defaultInterval);
        }
    }
}
