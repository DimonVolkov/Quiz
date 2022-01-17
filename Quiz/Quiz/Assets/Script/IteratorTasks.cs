using UnityEngine;
using UnityEngine.Events;

public class IteratorTasks : MonoBehaviour
{
    [SerializeField]
    private GridAnswers _UIGrid;

    [SerializeField]
    private UIQuestion _textQuestion;
    
    [SerializeField]
    private UnityEvent EventTasksCompleted;

    private Task current;
    private int inter = 0;
    private Task[] _tasks;

    private void HendlerCompleteTask()
    {
        NextTask();
    }

    private void OnEnable()
    {
        CorrectAnswer.EventCompleteTask += HendlerCompleteTask;
    }

    private void OnDisable()
    {
        CorrectAnswer.EventCompleteTask -= HendlerCompleteTask;
    }

    public void NextTask()
    {
        if (inter == _tasks.Length)
        {
            EventTasksCompleted?.Invoke();
            return;
        }
        current = _tasks[inter];
        _UIGrid.AddAnswers(current.Answer);
        inter++;

        _textQuestion.SetQuestion(current.Question);
    }

    public void HendlerStartIterator(Task[] tasks)
    {
        inter = 0;
        _UIGrid.Init();
        _textQuestion.Init();
        _tasks = tasks;
        NextTask();
    }

    
}
