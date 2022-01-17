using DG.Tweening;
using System;
using UnityEngine;

public class CorrectAnswer : IStateAnswer
{
    public static event Action EventCompleteTask;

    private ParticleSystem _particle;

    private Transform _transformAnswer;

    public void Init(Transform tr)
    {
        _transformAnswer = tr;
        _particle = _transformAnswer.GetComponentInChildren<ParticleSystem>();
    }

    public bool TryCheck()
    {
        _particle.Play();
        var bounce = DOTween.Sequence();
        bounce.Append(_transformAnswer.DOScale(0, 0)).
            Append(_transformAnswer.DOScale(1.2f, 0.3f)).
            Append(_transformAnswer.DOScale(0.95f, 0.3f)).
            Append(_transformAnswer.DOScale(1, 0.3f)).
            OnComplete(CompleteTask);

        return true;
    }
    public IStateAnswer Clone()
    {
        return new CorrectAnswer();
    }

    private void CompleteTask()
    {
        DOTween.KillAll();
        EventCompleteTask?.Invoke();
    }

}
