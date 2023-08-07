using Client.Resources;
using Client.Shop;
using Core;
using Core.Common;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Client.UI.Shop
{
    public class ShopView : InitializableMonoBehaviour<ShopView.Params>
    {
        public readonly struct Params
        {
            public readonly PrefabPool PrefabPool;

            public readonly ResourcesProvider ResourcesProvider;
            
            public Params(PrefabPool prefabPool, ResourcesProvider resourcesProvider)
            {
                PrefabPool = prefabPool;
                ResourcesProvider = resourcesProvider;
            }
        }

        [SerializeField, Required]
        private AvailableBundlesData _availableBundles;
        
        [SerializeField, Required]
        private RectTransform _anchor;
        
        [SerializeField, Required]
        private BundleItemView _bundleItemViewPrefab;

        private PrefabPool PrefabPool => InputParams.PrefabPool;
        
        private ResourcesProvider ResourcesProvider => InputParams.ResourcesProvider;
        
        protected override void Init()
        {
            foreach (var bundle in _availableBundles.Configs)
                PrefabPool.Get(_bundleItemViewPrefab, new BundleItemView.Params(bundle, ResourcesProvider), _anchor).AddTo(Disposables);
        }
    }
}