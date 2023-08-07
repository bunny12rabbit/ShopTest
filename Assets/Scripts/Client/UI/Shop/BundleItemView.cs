using Client.Resources;
using Client.Shop;
using Core;
using Core.Common;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI.Shop
{
    public class BundleItemView : InitializableMonoBehaviour<BundleItemView.Params>
    {
        public readonly struct Params
        {
            public readonly BundleConfig Config;

            public readonly ResourcesProvider ResourcesProvider;

            public Params(BundleConfig config, ResourcesProvider resourcesProvider)
            {
                Config = config;
                ResourcesProvider = resourcesProvider;
            }
        }

        [SerializeField, Required]
        private TMP_Text _nameLabel;

        [SerializeField, Required]
        private Button _buyButton;

        private BundleConfig Config => InputParams.Config;

        private ResourcesProvider ResourcesProvider => InputParams.ResourcesProvider;

        protected override void Init()
        {
            _buyButton.OnClickAsObservable().Subscribe(OnBuyButtonClicked).AddTo(Disposables);
            _nameLabel.text = Config.Name;
            ResourcesProvider.ResourcesChanged.Subscribe(_ => UpdateView()).AddTo(Disposables);

            UpdateView();
        }

        private void OnBuyButtonClicked(Unit _)
        {
            Config.Buy();
            UpdateView();
        }

        private void UpdateView() => _buyButton.interactable = Config.CanBuy;
    }
}