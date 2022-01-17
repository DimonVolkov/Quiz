using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField]
    private CardBundleData[] _cardBundleDatas;

    public CardBundleData[] CardBundleDatas  => _cardBundleDatas;
}
