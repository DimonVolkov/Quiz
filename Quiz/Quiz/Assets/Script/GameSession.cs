
//using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    private Data _data;

    [SerializeField]
    private int MaxTasksInLevel;
    private const int MAXLEVEL = 3;
    
    [SerializeField]
    private EventStartSession eventStartSession; //передает задания итератору

    private List<Task> tasks = new List<Task>();
    private List<string> IdTasks = new List<string>();//список id заданий который дали в текущей сессии
    private List<CardData> CurrentCardData = new List<CardData>();//список доступных заданий для текущего уровня из текущей выборки данных
    private CardBundleData _currentCardBundleData; // текущая выборка данных

    public Task[] Tasks => tasks.ToArray();

    private void NewLevel()
    {
        CurrentCardData.Clear();
        //формирует CurrentCardData - нужен для меньшей выборки при рандомизации задания(задание не повторялись)
        _currentCardBundleData = _data.CardBundleDatas[Random.Range(0, _data.CardBundleDatas.Length)];
        for (int i = 0; i < _currentCardBundleData.CardData.Length; i++)
        {
            if (!IdTasks.Contains(_currentCardBundleData.CardData[i].id))
            {
                CurrentCardData.Add(_currentCardBundleData.CardData[i]);
            }
        
        }
    }

    private Task GetTask(int level)
    {
        int LigthRange = CurrentCardData.Count - 1;
        int randomTask = Random.Range(0, LigthRange);

        Task task = new Task(CurrentCardData[randomTask], _currentCardBundleData, level);

        CurrentCardData.RemoveAt(randomTask);
        IdTasks.Add(task.Question);

        return task;
    }

    public void SessiaStart()
    {
        tasks.Clear();
        IdTasks.Clear();
        for (int i = 1; i <= MAXLEVEL; i++)
        {
            NewLevel();
            for (int y = 0; y < MaxTasksInLevel; y++)
            {
                if(CurrentCardData.Count > 0)//если дать задание не откуда
                    tasks.Add(GetTask(i));
            }
        }
        
        eventStartSession?.Invoke(Tasks);
    }

    private void Start()
    {
        SessiaStart();
    }
}
[System.Serializable]
public class EventStartSession : UnityEvent<Task[]> { }