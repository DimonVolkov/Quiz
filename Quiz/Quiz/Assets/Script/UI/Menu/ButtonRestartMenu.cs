using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonRestartMenu : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private BackgroundMenu _background;

    [SerializeField]
    private UnityEvent EventClickRestart;

    [SerializeField]
    private GameObject UIButtonRestart;
    public void ShowMenu()
    {
        UIButtonRestart.SetActive(true);
        _background.FadeIn();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        EventClickRestart?.Invoke();
        UIButtonRestart.SetActive(false);
    }
}
