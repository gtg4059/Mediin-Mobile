using Microsoft.Azure.Mobile.Server;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class Log : EntityData
    {
        public string names { get; set; }
        public string passwords { get; set; }
        public string date { get; set; }
        public string age { get; set; }
        public string sex { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public int arm { get; set; }
        public int sit { get; set; }
        public int yoga { get; set; }
        public int praise { get; set; }
        public string foot { get; set; }
        /*public string dates { get; set; }
        public string inout { get; set; }
        public string names { get; set; }
        public string tag { get; set; }
        public string gates { get; set; }
        public string works { get; set; }
        public string location { get; set; }
        public int row { get; set; }*/
    }
}