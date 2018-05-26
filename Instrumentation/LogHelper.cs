using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Instrumentation
{
    public class LogHelper
    {
        /*public static void Setup()
        {
            if (!EventLog.SourceExists("ParkApp"))
            {
                EventLog.CreateEventSource("ParkApp", "ParkSystemApp");
            }

            TextWriterTraceListener txt =
                new TextWriterTraceListener("log.txt");

            EventLogTraceListener eventLog =
                new EventLogTraceListener("ParkApp");

            MailTraceListener mail =
                new MailTraceListener();

            Trace.Listeners.Add(txt);
            Trace.Listeners.Add(eventLog);
            Trace.Listeners.Add(mail);
            Trace.AutoFlush = true;
            //Cogitar o uso de breadcrumb
        }

        public static void Log(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Mensagem: " + ex.Message);
            sb.AppendLine("Pilha de Chamada: " + ex.StackTrace);
            sb.AppendLine("Hora: " + DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss"));
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            localIPs.ToList().ForEach(c => sb.AppendLine("IP: " + c.Address));
            Trace.Write(sb.ToString());
        }
        */
    }
}
