using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardStack : MonoBehaviour
{

    private List<Card> cards = new List<Card>();

    public void AddCardOnTop(Card card)
    {
        cards.Add(card);
        //card.tranform.pos=....
        transform.DOMove(new Vector3(1, 1, 1), 1).OnComplete(() =>
        {
            int a = 1;
            a++;
        });
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }
}

public class Card
{
    private CardStack container;


}
