using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Holds information and objects of the cards that the opponent has in her hand. */

public class EnemyHand {
	private List<Card> hand;
	private float cardLength = 5.5f;
	private float handLength;
	private float _y = 5.609684f;
	private float _z = 24.17719f;
	private float _sx = -11.52601f;
	
	public EnemyHand()
	{
		hand = new List<Card>();
		handLength = cardLength * 6;
	}
	
	public void AddToHand(Card card)
	{
		hand.Add(card);
		//card.GetGameObject().transform.eulerAngles = new Vector3(24.0f, 180.0f, 0.0f);
		card.TurnDown();
		//FixPositions();
		card._Coord = CardCoord.ENEMY_HAND;

		for(int i = 0; i < hand.Count; i++)
		{
			hand[i].MoveAndRotate(GetPositionOf(i));
		}
		
		//card.MoveAndRotate(GetPositionOf(hand.Count - 1));
	}

	private Vector3 GetPositionOf(int index)
	{
		float spaceBetweenCards = 0.25f;

		int newIndex = hand.Count - index - 1;

		if(hand.Count <= 6)
		{
			float totalLength = hand.Count * cardLength;
			float margin = (handLength - totalLength) * 0.5f;
			float tempPosition = margin + newIndex * (cardLength + spaceBetweenCards) + _sx;
			return new Vector3(tempPosition, _y, _z);
		}
		else
		{
			float length = handLength / hand.Count;
			return new Vector3(_sx + length * newIndex, _y, _z);	
		}
	}
	
	public Card RemoveFromHand()
	{
		Card cardToReturn = hand[hand.Count - 1];
		hand.RemoveAt(hand.Count - 1);
		FixPositions();
		cardToReturn._Coord = CardCoord.NONE;
		return cardToReturn;
	}
	
	public Card RemoveFromHand(int pos)
	{
		Card cardToReturn = hand[pos];
		hand.RemoveAt(pos);
		FixPositions();
		cardToReturn._Coord = CardCoord.NONE;
		return cardToReturn;
	}
	
	public void RemoveFromHand(Card c)
	{
		hand.Remove(c);
		FixPositions();
		c._Coord = CardCoord.NONE;
	}
	
	public void Update()
	{
		for(int i = 0; i < hand.Count; i++)
		{
			hand[i].Update();	
		}
	}
	
	public int GetIndex(Card c)
	{
		for(int i = 0; i < hand.Count; i++)
		{
			if(hand[i] == c)
			{
				return i;	
			}
		}
		return -1;
	}
	
	private void FixPositions()
	{
		if(hand.Count <= 6)
		{
			float totalLength = hand.Count * cardLength;
			float margin = (handLength - totalLength) * 0.5f;
			for(int i = 0; i < hand.Count; i++)
			{
				float tempPosition = margin + i * cardLength + _sx;
				hand[i].GetGameObject().transform.position = new Vector3(tempPosition, _y, _z);
			}
		}
		else
		{
			float length = handLength / hand.Count;
			for(int i = 0; i < hand.Count; i++)
			{
				hand[i].GetGameObject().transform.position = new Vector3(_sx + length * i, _y, _z);	
			}
		}
	}
	
	public int Size()
	{
		return hand.Count;	
	}
	
	public void HideAllCards()
	{
		for(int i = 0; i < hand.Count; i++)
		{
			hand[i].TurnDown();
		}
	}
	
	//Retrieve the card object at index position.
	public Card GetCardAtIndex(int index)
	{
		//Sanity Check
		if(index < hand.Count)	
		{
			return hand[index];	
		}
		
		return null; 
	}
}
