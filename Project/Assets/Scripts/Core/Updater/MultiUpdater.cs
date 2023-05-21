using System.Collections.Generic;

namespace Core.Updater
{
    public class MultiUpdater : IUpdater
    {
        private readonly List<IUpdater> _updaters;

        public MultiUpdater(List<IUpdater> updaters)
        {
            _updaters = updaters;
        }

        public void Update(float ts)
        {
            foreach (var updater in _updaters)
            {
                updater.Update(ts);
            }
        }
    }
}