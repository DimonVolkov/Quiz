
using System;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField]
    private string _id;
    [SerializeField]
    private Sprite _sprite;

    public string id => _id;
    public Sprite sprite => _sprite;
}
