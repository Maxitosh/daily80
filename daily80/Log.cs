using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily80
{
    class Log
    {
        public void LogMessage(string msg, MessageType msgType)
        {
            switch (msgType)
            {
                case MessageType.Normal:
                    Console.WriteLine("[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + msg);
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + msg);
                    Console.ResetColor();
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + msg);
                    Console.ResetColor();
                    break;
                case MessageType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "] " + msg);
                    Console.ResetColor();
                    break;
            }
        }
    }
}
