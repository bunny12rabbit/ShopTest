using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Shop
{
    [CreateAssetMenu(fileName = "Bundle Config", menuName = "Config/ShopBundle")]
    public class BundleConfig : SerializedScriptableObject
    {
        [SerializeField]
        private string _name;
        
        [SerializeReference]
        private ISpend _spend;

        [SerializeReference, Space]
        private IReward _reward;

        public string Name => _name;

        public bool CanBuy => _spend.CanSpend;
        
        public void Buy()
        {
            if(_spend.TrySpend())
                _reward.GiveReward();
        }
    }
}