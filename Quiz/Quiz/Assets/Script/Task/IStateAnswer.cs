using UnityEngine;

public interface IStateAnswer
{
    void Init(Transform tr);

    bool TryCheck();

    IStateAnswer Clone();

}

