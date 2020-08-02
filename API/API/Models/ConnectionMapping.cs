using System.Collections.Generic;
using System.Linq;

namespace API.Models
{
    public class ConnectionMapping<T>
    {
        private readonly Dictionary<string, HashSet<string>> _connections =
            new Dictionary<string, HashSet<string>>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public void Add(string key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(string key)
        {
            HashSet<string> connections;
            if (_connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public IEnumerable<string> GetPassengers()
        {
            return new List<string>(_connections.Keys);
        }

        public IEnumerable<string> GetPassengerConnections()
        {
            List<string> passengerConnections = new List<string>();
            GetPassengers().ToList().ForEach(p => passengerConnections.Add(_connections[p].FirstOrDefault()));
            return passengerConnections;
        }

        public void Remove(string key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        _connections.Remove(key);
                    }
                }
            }
        }
    }
}
