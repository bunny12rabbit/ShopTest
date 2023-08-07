using Client.Resources;
using Client.UI;
using Client.UI.Shop;
using Core;
using Core.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField, Required]
        private PrefabPool _prefabPool;

        [SerializeField, Required]
        private ResourcesBar _resourcesBar;

        [SerializeField]
        private ShopView _shopView;
        
        private readonly ResourcesProvider _resourcesProvider = new();

        private void Awake()
        {
            _resourcesBar.Init(new ResourcesBar.Params(_prefabPool, _resourcesProvider));
            _shopView.Init(new ShopView.Params(_prefabPool, _resourcesProvider));
        }
    }
}