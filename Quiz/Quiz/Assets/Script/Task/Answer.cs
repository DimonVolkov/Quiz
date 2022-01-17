
public class Answer 
{
    private IStateAnswer _state;
    private CardData _info;

    public CardData Info => _info;
    public IStateAnswer State => _state;

    public Answer(IStateAnswer state, CardData cardData)
    {
        _state = state;
        _info = cardData;
    }

    

}
