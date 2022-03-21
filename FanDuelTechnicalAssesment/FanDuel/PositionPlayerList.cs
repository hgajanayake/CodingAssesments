using System.Collections.Generic;
using System.Linq;


namespace FanDuel
{
    internal class PositionPlayerList
    {
        private List<Player> _playerList;

        internal PositionPlayerList()
        {
            _playerList = new List<Player>();
        }

        internal bool AddPlayer(Player player, int? positionDepth = null)
        {
            if (_playerList.Any(p => p.Equals(player)))
                return false;

            if(positionDepth == null)
            {
                _playerList.Add(player);
                return true;
            }

            var depth = positionDepth.GetValueOrDefault();

            if (depth >= 0)
            {
                if (depth > _playerList.Count)
                    return false;

                _playerList.Insert(depth, player);
                return true;
            }    

            return false;
        }

        internal bool RemovePlayer(Player player)
        {
            return _playerList.Remove(player);
        }

        internal List<Player> GetBackups(Player player)
        {
            var playerIndex = _playerList.IndexOf(player);

            if (playerIndex < 0 || _playerList.Count == 1 || playerIndex == _playerList.Count - 1)
                return new List<Player>();

            return _playerList.GetRange(playerIndex + 1, _playerList.Count - (playerIndex + 1));
        }

        internal int GetPlayerDepth(Player player)
        {
            return _playerList.IndexOf(player);
        }        

        internal List<Player> GetAllPlayers()
        {
            return _playerList;
        }
    }
}
