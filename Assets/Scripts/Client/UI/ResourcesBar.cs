using Client.Resources;
using Core;
using Core.Common;
using Core.Extensions;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Client.UI
{
    public class ResourcesBar : InitializableMonoBehaviour<ResourcesBar.Params>
    {
        public readonly struct Params
        {
            public readonly PrefabPool PrefabPool;

            public readonly ResourcesProvider ResourceProvider;

            public Params(PrefabPool prefabPool, ResourcesProvider resourceProvider)
            {
                PrefabPool = prefabPool;
                ResourceProvider = resourceProvider;
            }
        }

        [SerializeField]
        private ResourceTypes _resourcesToDisplay = ResourceTypes.Gold | ResourceTypes.Health | ResourceTypes.Rating;

        [SerializeField, Required]
        private RectTransform _anchor;
        
        [SerializeField, Required]
        private ResourceView _resourceViewPrefab;

        private PrefabPool PrefabPool => InputParams.PrefabPool;
        
        private ResourcesProvider ResourceProvider => InputParams.ResourceProvider;
        
        protected override void Init()
        {
            var resourceTypes = _resourcesToDisplay.GetFlags();

            foreach (var resourceType in resourceTypes)
            {
                if (ResourceProvider.TryGetResource(resourceType, out var resource))
                    PrefabPool.Get(_resourceViewPrefab, new ResourceView.Params(resource), _anchor).AddTo(Disposables);
            }
        }
    }
}