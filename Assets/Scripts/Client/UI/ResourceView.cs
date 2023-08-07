using System.Diagnostics.CodeAnalysis;
using Core;
using Core.Common;
using TMPro;
using UniRx;
using UnityEngine;

namespace Client.UI
{
    public class ResourceView : InitializableMonoBehaviour<ResourceView.Params>
    {
        public readonly struct Params
        {
            public readonly IResource Resource;

            public Params([NotNull] IResource resource)
            {
                Resource = resource;
            }
        }
        
        [SerializeField]
        private TMP_Text _resourceName;

        [SerializeField]
        private TMP_Text _resourceAmount;

        private IResource Resource => InputParams.Resource;
        
        protected override void Init()
        {
            if (Resource == null)
            {
                Debug.LogError($"::ResourceView.Init:: InputParams.Resource is null!");
                return;
            }
            
            _resourceName.text = Resource.Name;
            Resource.CurrentAmountReactive.Subscribe(UpdateAmount).AddTo(Disposables);
        }

        private void UpdateAmount(int amount) => _resourceAmount.text = amount.ToString();
    }
}