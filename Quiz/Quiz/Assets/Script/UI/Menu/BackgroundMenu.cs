using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BackgroundMenu : MonoBehaviour, IFadeMenu
{
    private Image ImageBackgeround;

    [SerializeField]
    private GameObject _backgeround;

    public void FadeIn()
    {
        _backgeround.SetActive(true);
        ImageBackgeround.DOFade(0, 0);
        ImageBackgeround.DOFade(1, .5f);
    }

    public void FadeOut()
    {
        _backgeround.SetActive(false);
        ImageBackgeround.DOFade(0, .2f);
    }

    private void Start()
    {
        ImageBackgeround = _backgeround.GetComponent<Image>();
    }
}
