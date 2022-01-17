
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIQuestion : MonoBehaviour
{
    private Text _text;
    private bool _startEffect;
    public void SetQuestion(string text)
    {
        if (_startEffect)
        {
            StartEffect();
        }
        _text.text = "Find " + text;
    }

    public void Init()
    {
        _text = GetComponent<Text>();
        _startEffect = true;
    }

    private void StartEffect()
    {
        _startEffect = false;
        _text.DOFade(0, 0);
        _text.DOFade(1,2);
    }
}
