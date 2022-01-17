
using System.Collections.Generic;
using UnityEngine;

public class Task 
{

    private CardData _cardData;
    private CardBundleData _currentCardBundleData;//задание формирует ответы
    private int _level;

    private List<Answer> _answers = new List<Answer>();

    public Answer[] Answer => _answers.ToArray();

    private const int DIFFICULTYLEVEL = 3;

    private string _question;

    public string Question => _question;


    //состояние ответа под общим интерфейсом 
    private NoCorrectAnswer NocorrectAnswer;
    private CorrectAnswer CorrectAnswer;

    

    //давай зделаем список возможных ответов



    public Task(CardData cardData, CardBundleData currentCardBundleData, int level)
    {
        _cardData = cardData;
        _question = _cardData.id;
        _currentCardBundleData = currentCardBundleData;
        _level = level;

        NocorrectAnswer = new NoCorrectAnswer();
        CorrectAnswer = new CorrectAnswer();

        SetAnswers();
        

    }

    

    private void SetAnswers()
    {
        //ответы должны быть разбросаны
        int countAnswer = _level * DIFFICULTYLEVEL;
        int correctAnswer = Random.Range(0, countAnswer);

        List<CardData> tempData = new List<CardData>();//чтоб ответы не повторялись буду брать отсюда
        foreach (var d in _currentCardBundleData.CardData)
        {
            if (d.id == _cardData.id)
                continue;
            tempData.Add(d);
        }

        for (int i=0; i < countAnswer; i++)
        {
            Answer answer;
            if (i == correctAnswer)
            {
                answer = new Answer(CorrectAnswer, _cardData);
                _answers.Add(answer);
                continue;
            }
            int randorNoCorrectAnswer = Random.Range(0, tempData.Count);//ищем случайный ответ 
            answer = new Answer(NocorrectAnswer.Clone(), tempData[randorNoCorrectAnswer]);
            _answers.Add(answer);
            tempData.RemoveAt(randorNoCorrectAnswer);

            
        }
        
    }
}
