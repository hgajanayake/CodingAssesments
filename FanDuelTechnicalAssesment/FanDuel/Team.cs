using FanDuel.Enums;

namespace FanDuel
{
    public class Team
    {
        public string Name { get; set; } //unique name
        public Sport TeamSport { get; set; }       
        public DepthChart CurrentDepthChart { get; set; }

        public Team(string teamName)
        {
            Name = teamName;
            CurrentDepthChart = new DepthChart();
        }
    }
}
