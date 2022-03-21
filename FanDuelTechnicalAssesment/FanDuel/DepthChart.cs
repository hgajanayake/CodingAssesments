using System.Collections.Generic;
using System.Text;
using FanDuel.Enums;

namespace FanDuel
{
    public class DepthChart
    {
        private Dictionary<Position, PositionPlayerList> _positions;

        public DepthChart()
        {
            _positions = new Dictionary<Position, PositionPlayerList>();
        }

        public bool InitialisePosition(Position position)
        {
            if (_positions.ContainsKey(position))
                return false;

            _positions[position] = new PositionPlayerList();

            return true;
        }

        public bool AddPlayer(Position position, Player player, int? positionDepth = null)
        {
            if (player == null)
                return false;

            if (!_positions.ContainsKey(position))
                return false;

            var depthChartPosition = _positions[position];

            if (depthChartPosition == null)
                return false;

            return depthChartPosition.AddPlayer(player, positionDepth);
        }

        public List<Player> RemovePlayer(Position position, Player player)
        {
            if (player == null)
                return new List<Player>();

            if (!_positions.ContainsKey(position))
                return new List<Player>();

            if (_positions[position] == null)
                return new List<Player>();

            if(_positions[position].RemovePlayer(player))
                return new List<Player>(){ player };

            return new List<Player>();
        }

        public List<Player> GetBackups(Position position, Player player)
        {
            if (player == null)
                return new List<Player>();

            if (!_positions.ContainsKey(position))
                return new List<Player>();

            if (_positions[position] == null)
                return new List<Player>();

            return _positions[position].GetBackups(player);
        }

        public int GetPlayerDepth(Position position, Player player)
        {
            if (player == null)
                return -1;

            if (!_positions.ContainsKey(position))
                return -1;

            if (_positions[position] == null)
                return -1;

            return _positions[position].GetPlayerDepth(player);
        }

        public string GetFullDepthChart()
        {
            var chartstr = new StringBuilder();

            foreach (var pos in _positions)
            {
                chartstr.Append($"{pos.Key.ToString()} - ");

                var players = pos.Value.GetAllPlayers();

                foreach(var player in players)
                {
                    chartstr.Append($"(#{player.Number}, {player.Name}), ");
                }

                if (players.Count >= 1)
                    chartstr.Remove(chartstr.Length - 2, 2);

                chartstr.Append("\r\n");
            }

            return chartstr.ToString();
        }
    }
}
