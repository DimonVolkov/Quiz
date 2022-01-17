using DG.Tweening;
using UnityEngine;

public class NoCorrectAnswer : IStateAnswer
{
    private Transform _transformAnswer;
    public bool TryCheck()
    {
        _transformAnswer.DOLocalMoveY(10, 0.1f).SetLoops(4, LoopType.Yoyo).SetEase(Ease.InBounce);
        return false;
    }

    public IStateAnswer Clone()
    {
        return new NoCorrectAnswer();
    }

    public void Init(Transform tr)
    {
        _transformAnswer = tr;
    }

}
