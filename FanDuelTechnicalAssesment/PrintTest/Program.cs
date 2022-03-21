using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanDuel;
using FanDuel.Enums;

namespace FanDuelPrintTest
{
    class Program
    {
        public static Player JaelonDarden = new Player("1", "Jaelon Darden");
        public static Player KyleTrask = new Player("2", "Kyle Trask");
        public static Player ScottMiller = new Player("10", "Scott Miller");
        public static Player BlaineGabbert = new Player("11", "Blaine Gabbert");
        public static Player TomBrady = new Player("12", "Tom Brady");
        public static Player MikeEvans = new Player("13", "Mike Evans");

        static void Main(string[] args)
        {
            var team = new Team("Tampa Bay Buccaneers") { TeamSport = Sport.NFL };

            team.CurrentDepthChart.InitialisePosition(Position.QB);
            team.CurrentDepthChart.InitialisePosition(Position.LWR);

            team.CurrentDepthChart.AddPlayer(Position.QB, TomBrady);
            team.CurrentDepthChart.AddPlayer(Position.QB, BlaineGabbert);
            team.CurrentDepthChart.AddPlayer(Position.QB, KyleTrask);

            team.CurrentDepthChart.AddPlayer(Position.LWR, MikeEvans);
            team.CurrentDepthChart.AddPlayer(Position.LWR, JaelonDarden);
            team.CurrentDepthChart.AddPlayer(Position.LWR, ScottMiller);

            Console.Write(team.CurrentDepthChart.GetFullDepthChart());
            Console.ReadLine();

        }
    }
}
