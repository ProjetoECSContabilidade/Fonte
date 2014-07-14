using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contabilidade.Job;

namespace Contabilidade
{
    public class CallJob
    {
        static CallJob()
        {
        }

        public static void Execute()
        {
            CronJobOS cronJobOS = new CronJobOS();
            cronJobOS.Execute();
        }
    }
}
