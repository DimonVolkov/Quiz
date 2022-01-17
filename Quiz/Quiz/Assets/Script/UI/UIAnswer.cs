using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIAnswer : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private ParticleSystem _particle;

    public IStateAnswer State => _state;

    [SerializeField]
    private Transform _transformImage;

    [SerializeField]
    private Ease ease;

    private IStateAnswer _state;
    private RectTransform trRect;
    public void StartEffect()
    {
        var bounce = DOTween.Sequence();
        bounce.Append(trRect.DOScale(0,0)).
            Append(trRect.DOScale(1.2f, 0.3f)).
            Append(trRect.DOScale(0.95f, 0.3f)).
            Append(trRect.DOScale(1, 0.3f));
    }

    public void Init(Answer answer)
    {
        trRect = GetComponent<RectTransform>();
        _state = answer.State;
        //отправлю данные состоянию ответа а тот выберет данные которые ему нужны

        _state.Init(_transformImage);
        image.sprite = answer.Info.sprite;
    }


    





}
