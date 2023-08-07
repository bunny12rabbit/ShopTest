using System;
using System.Collections.Generic;
using System.Linq;
using Client.Resources.Gold;
using Client.Resources.Health;
using Client.Resources.Rating;
using Core;
using UniRx;

namespace Client.Resources
{
    public class ResourcesProvider
    {
        // Лучше сделать по типу, но ТЗ запрещает видимость доменов снаружи.
        private readonly Dictionary<ResourceTypes, IResource> _resources;

        public IObservable<Unit> ResourcesChanged => _resources?.Values.Select(x => x.CurrentAmountReactive).Merge().AsUnitObservable() ?? Observable.Empty<Unit>();

        public ResourcesProvider()
        {
            var gold = GoldManager.Instance.Resource;
            var health = HealthManager.Instance.Resource;
            var rating = RatingManager.Instance.Resource;
            
            _resources = new Dictionary<ResourceTypes, IResource>
            {
                {gold.ResourceType, gold},
                {health.ResourceType, health},
                {rating.ResourceType, rating}
            };
        }

        public bool TryGetResource(ResourceTypes resourceType, out IResource resource) => _resources.TryGetValue(resourceType, out resource);

    }
}