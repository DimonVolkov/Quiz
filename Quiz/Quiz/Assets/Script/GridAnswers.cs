
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GridAnswers : MonoBehaviour, IPointerDownHandler
{
    //создает список объектов(ответов) в ui
    //очищает
    //обрабатывает клики по ответам(воздействует на состояние ответов, если состояние ответа(правильный) создает событие), 
    
    private Transform _tr;
    [SerializeField]
    private UIAnswer PrefUIAnswer;
    private List<UIAnswer> answers = new List<UIAnswer>();

    private bool ActivePointerEventData;

    private bool _startEffect;

    public void Init()
    {
        _startEffect = true;
        _tr = GetComponent<Transform>();
    }

    public void AddAnswers(Answer[] data)
    {
        ActivePointerEventData = true;
        ClearAnswers();
        
        for (int i = 0; i < data.Length; i++)
        {
            
            UIAnswer answer = Instantiate(PrefUIAnswer, _tr);
            answer.Init(data[i]);
            if (_startEffect)
            {
                answer.StartEffect();
            }
            answers.Add(answer);
        }
        if (_startEffect)
            _startEffect = false;

    }

    private void ClearAnswers()
    {
        foreach (var anser in answers)
        {
            Destroy(anser.gameObject);
        }
        answers.Clear();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ActivePointerEventData)//нельзя несколько раз отвечат правильно 
        {
            UIAnswer answer = eventData.pointerCurrentRaycast.gameObject.GetComponent<UIAnswer>();

            if (answer.State.TryCheck())
            {
                ActivePointerEventData = false; 
            }    
        }
    }
}
