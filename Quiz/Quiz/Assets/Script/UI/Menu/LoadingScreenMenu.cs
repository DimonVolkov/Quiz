using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingScreenMenu : MonoBehaviour, IFadeMenu
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private BackgroundMenu _backgroundMenu;

    [SerializeField]
    private GameObject UILoadingScreen;

    public void FadeIn()
    {
        UILoadingScreen.SetActive(true);
        _text.DOFade(0, 0);
        _text.DOFade(1, .5f);
    }

    public void FadeOut()
    {
        _text.DOFade(0, .2f).SetLoops(1, LoopType.Yoyo).OnComplete(FinishLoading);
    }

    private void FinishLoading()
    {
        UILoadingScreen.SetActive(false);
        _backgroundMenu.FadeOut();
    }
}
