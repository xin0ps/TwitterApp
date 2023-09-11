using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.NotificationNamespace
{
    public  class Notificaiton
    {
        public string content { get; set; }
        public DateTime time { get; set; }
        public Notificaiton(string _cont) {
        
        content= _cont;
        time = DateTime.Now;
        }
        public override string ToString()
        {
            string? txt=content+"\tTime:"+time;
            return content;
           

        }
    }
}
