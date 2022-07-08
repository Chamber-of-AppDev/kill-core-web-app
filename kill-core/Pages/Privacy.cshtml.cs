using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kill_core.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly List<Thread> threads = new();
        private readonly Random rand = new();

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            DateTime dt1 = DateTime.Now;

            while (true)
            {
                threads.Add(new Thread(new ThreadStart(KillCore)));
                if (DateTime.Now.Subtract(dt1).TotalSeconds > 30)
                {
                    StopThreads();
                    break;
                }                    
            }
        }
        public void KillCore()
        {
            long num = 0;
            while (true)
            {
                num += int.Parse(rand.Next(10, 100).ToString());
                if (num > 1000000) { num = 0; }
            }
        }
        public void StopThreads()
        {
            foreach (Thread t in threads) { t.Interrupt(); }
        }
    }
}