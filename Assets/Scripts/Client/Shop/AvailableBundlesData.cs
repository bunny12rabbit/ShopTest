using System.Collections.Generic;
using UnityEngine;

namespace Client.Shop
{
    [CreateAssetMenu(fileName = nameof(AvailableBundlesData), menuName = "Shop / Available Bundles")]
    public class AvailableBundlesData : ScriptableObject
    {
        [SerializeField]
        private BundleConfig[] _bundleConfigs;

        public IEnumerable<BundleConfig> Configs => _bundleConfigs;
    }
}