using System;
using common.resources;
using log4net;

namespace wServer.realm.entities
{
    public enum PlayerShootStatus
    {
        Ok,
        ItemMismatch,
        CooldownStillActive,
        NumProjectileMismatch,
        ClientTooSlow,
        ClientTooFast
    }

    public class TimeCop
    {
        private readonly int[] _clientDeltaLog;
        private readonly int[] _serverDeltaLog;
        private readonly int _capacity;
        private int _index;
        private int _clientElapsed;
        private int _serverElapsed;
        private int _lastClientTime;
        private int _lastServerTime;
        private int _count;

        public TimeCop(int capacity = 20)
        {
            _capacity = capacity;
            _clientDeltaLog = new int[_capacity];
            _serverDeltaLog = new int[_capacity];
        }

        public void Push(int clientTime, int serverTime)
        {
            var dtClient = 0;
            var dtServer = 0;
            if (_count != 0)
            {
                dtClient = clientTime - _lastClientTime;
                dtServer = serverTime - _lastServerTime;
            }
            _count++;
            _index = (_index + 1) % _capacity;
            _clientElapsed += dtClient - _clientDeltaLog[_index];
            _serverElapsed += dtServer - _serverDeltaLog[_index];
            _clientDeltaLog[_index] = dtClient;
            _serverDeltaLog[_index] = dtServer;
            _lastClientTime = clientTime;
            _lastServerTime = serverTime;
        }

        public float LastClientTime()
        {
            return _lastClientTime;
        }

        public int LastServerTime()
        {
            return _lastServerTime;
        }
        
        /*
            a return value of 1 means client time is in sync with server time
            less than 1 means client time is slower than server time
            greater than 1 means client time is faster than server
        */
        public float TimeDiff()
        {
            if (_count < _capacity)
                return 1;

            return (float)_clientElapsed / _serverElapsed;
        }
    }

    partial class Player
    {
        private static readonly ILog CheatLog = LogManager.GetLogger("CheatLog");
        private const float MaxTimeDiff = 1.08f;
        private const float MinTimeDiff = 0.92f;
        private readonly TimeCop _time = new TimeCop();
        private int _shotsLeft;
        private int _lastShootTime;

        public PlayerShootStatus ValidatePlayerShoot(Item item, int time)
        {
            if (item != Inventory[0])
                return PlayerShootStatus.ItemMismatch;
            
            var dt = 1 / Stats.GetAttackFrequency() * (1 / item.RateOfFire);
            if (time < _time.LastClientTime() + dt)
                return PlayerShootStatus.CooldownStillActive;

            if (time != _lastShootTime)
            {
                _lastShootTime = time;

                if (_shotsLeft != 0 && _shotsLeft < item.NumProjectiles)
                {
                    _shotsLeft = 0;
                    _time.Push(time, Environment.TickCount);
                    return PlayerShootStatus.NumProjectileMismatch;
                }
                _shotsLeft = 0;
            }
            
            _shotsLeft++;
            if (_shotsLeft >= item.NumProjectiles)
                _time.Push(time, Environment.TickCount);
            
            var timeDiff = _time.TimeDiff();
            //Log.Info($"timeDiff: {timeDiff}");
            if (timeDiff < MinTimeDiff)
                return PlayerShootStatus.ClientTooSlow;
            if (timeDiff > MaxTimeDiff)
                return PlayerShootStatus.ClientTooFast;
            
            return PlayerShootStatus.Ok;
        }

        public bool IsNoClipping()
        {
            if (Owner == null || !TileOccupied(RealX, RealY) && !TileFullOccupied(RealX, RealY))
                return false;

            CheatLog.Info($"{Name} is walking on an occupied tile.");
            return true;
        }
    }
}
