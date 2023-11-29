namespace Runtracker.Models
{
    public class RunningRoute
    {
        public int ID { get; set; }
        public float DistanceKm { get; set; }
        public int Time { get; set; }
        public string Notes { get; set; }

        //Constructor
        public RunningRoute()
        {

        }
    }
}
