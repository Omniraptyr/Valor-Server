using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace wServer.realm
{
    public class FLLogicTicker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(FLLogicTicker));

        private readonly RealmManager _manager;
        private readonly ConcurrentQueue<Action<RealmTime>>[] _pendings;

        public readonly int TPS;
        public readonly int MsPT;

        private readonly ManualResetEvent _mre;
        private Task _worldTask;
        private RealmTime _worldTime;

        public FLLogicTicker(RealmManager manager) {
            _manager = manager;
            MsPT = 1000 / manager.TPS;
            _mre = new ManualResetEvent(false);
            _worldTime = new RealmTime();

            _pendings = new ConcurrentQueue<Action<RealmTime>>[5];
            for (int i = 0; i < 5; i++)
                _pendings[i] = new ConcurrentQueue<Action<RealmTime>>();
        }

        public void TickLoop() {
            var loopTime = 0;
            var t = new RealmTime();
            var watch = Stopwatch.StartNew();
            do {
                t.TotalElapsedMs = watch.ElapsedMilliseconds;
                _mre.WaitOne(Math.Max(0, MsPT
                    - (int)(watch.ElapsedMilliseconds - t.TotalElapsedMs)));

                t.TickDelta = loopTime / MsPT;
                t.TickCount += t.TickDelta;
                t.ElapsedMsDelta = t.TickDelta * MsPT;

                if (_manager.Terminating)
                    break;

                DoLogic(t);

                loopTime += (int)(watch.ElapsedMilliseconds - t.TotalElapsedMs) - t.ElapsedMsDelta;
            } while (true);
        }

        private void DoLogic(RealmTime t) {
            var clients = _manager.Clients.Keys;

            foreach (var i in _pendings) {
                while (i.TryDequeue(out var callback))
                    try {
                        callback(t);
                    }
                    catch (Exception e) {
                        Log.Error(e);
                    }
            }

            _manager.ConMan.Tick(t);
            _manager.Monitor.Tick(t);
            _manager.InterServer.Tick(t.ElapsedMsDelta);

            if (t.TotalElapsedMs % 900000 == 0) {
                GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                GC.Collect();
            }

            TickWorlds(t);

            foreach (var client in clients) {
                if (t.TickCount % 300 == 0)
                    client.PacketCount = 0;

                if (client.PacketCount > 7000)
                    client.Disconnect();

                if (client.Player?.Owner != null)
                    client.Player.Flush();
            }
        }

        private void TickWorlds(RealmTime t) {
            _worldTime.TickDelta += t.TickDelta;

            try {
                foreach (var w in _manager.Worlds.Values.Distinct())
                    w.TickLogic(t);
            }
            catch (Exception e) {
                Log.Error(e);
            }

            if (_worldTask == null || _worldTask.IsCompleted) {
                t.TickDelta = _worldTime.TickDelta;
                t.ElapsedMsDelta = t.TickDelta * MsPT;

                if (t.ElapsedMsDelta < 200)
                    return;

                _worldTime.TickDelta = 0;
                _worldTask = Task.Factory.StartNew(() => {
                    foreach (var i in _manager.Worlds.Values.Distinct())
                        i.Tick(t);
                }).ContinueWith(e =>
                    Log.Error(e.Exception.InnerException.ToString()),
                    TaskContinuationOptions.OnlyOnFaulted);
            }
        }

        public void AddPendingAction(Action<RealmTime> callback,
            PendingPriority priority = PendingPriority.Normal) {
            _pendings[(int)priority].Enqueue(callback);
        }
    }
}