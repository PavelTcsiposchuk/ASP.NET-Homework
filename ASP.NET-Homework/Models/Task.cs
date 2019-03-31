using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Homework.Models
{
    public class Task
    {
        public int ID { get; set; }
        public bool Finished { get; set; }
        public string Text { get; set; }
        public string IsFinished()
        {
            return (this.Finished == true) ? "Сделано" : "В процессе";
        }


    
    }
}