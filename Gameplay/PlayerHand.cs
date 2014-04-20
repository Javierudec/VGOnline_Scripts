using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHand {
	private List<Card> hand;
	private float cardLength = 5.5f;
	private float handLength;
	private float _y = 2.056796f;
	private float _z = -26.8099f;
	private float _sx = -13.82581f;
	public bool bBlockHand = false;
	bool bFixHandPosition = false;

	private Card CurrentSelectedCard = null;
	
	public PlayerHand()
	{
		hand = new List<Card>();
		handLength = cardLength * 6;
	}
	
	public Card GetByID(CardIdentifier id)
	{
		for(int i = 0; i < hand.Count; i++)
		{
			if(hand[i].cardID == id)
			{
				return hand[i];	
			}
		}
		return null;
	}
	
	public int GetNumberOfCardsWithClanName(string clanName)
	{
		int cnt = 0;
		for(int i = 0; i < hand.Count; i++)
		{
			if(hand[i].clan == clanName)
			{
				cnt++;
			}
		}
		return cnt;
	}
	
	public int GetNumberOfCardsWithClanNameAndGrade(string clanName, int grade)
	{
		int cnt = 0;
		for(int i = 0; i < hand.Count; i++)
		{
			if(hand[i].clan == clanName && hand[i].grade == grade)
			{
				cnt++;
			}
		}
		return cnt;
	}
	
	public Card GetCardAtIndex(int idx)
	{
		if(idx < hand.Count)
		{
			return hand[idx];	
		}
		else
		{
			return null;	
		}
	}
	
	public void FixPositions()
	{
		float spaceBetweenCards = 0.25f;

		if(hand.Count <= 6)
		{
			float totalLength = hand.Count * cardLength;
			float margin = (handLength - totalLength) * 0.5f;
			for(int i = 0; i < hand.Count; i++)
			{
				float tempPosition = margin + i * (cardLength + spaceBetweenCards) + _sx;
				hand[i].GetGameObject().transform.position = new Vector3(tempPosition, _y, _z);
			}
		}
		else
		{
			float length = handLength / hand.Count;
			for(int i = 0; i < hand.Count; i++)
			{
				hand[i].GetGameObject().transform.position = new Vector3(_sx + (length + spaceBetweenCards) * i, _y, _z - 0.01f * i);	
			}
		}
	}

	public Vector3 GetPositionOf(int index)
	{
		float spaceBetweenCards = 0.25f;
		
		if(hand.Count <= 6)
		{
			float totalLength = hand.Count * cardLength;
			float margin = (handLength - totalLength) * 0.5f;
			float tempPosition = margin + index * (cardLength + spaceBetweenCards) + _sx;
			return new Vector3(tempPosition, _y, _z);
		}
		else
		{
			float length = handLength / hand.Count;
			return new Vector3(_sx + (length + spaceBetweenCards) * index, _y, _z - 0.01f * index);	
		}
	}

	public void AddToHand(Card card)
	{
		hand.Add(card);	

		for(int i = 0; i < hand.Count - 1; i++)
		{
			hand[i].MoveAndRotate(GetPositionOf(i));
		}

		card._Coord = CardCoord.HAND;

		//FixPositions();
		//card.GetGameObject().transform.eulerAngles = new Vector3(24.0f, 180.0f, 0.0f);
		card.MoveAndRotate(GetPositionOf(hand.Count - 1));
		bFixHandPosition = true;
		card.TurnUp();

		//card.TurnUp();
		card.bIsInhand = true;
	}
	
	public void Update()
	{
		/*
		if(bFixHandPosition)
		{
			bool bNoAnim = true;
			for(int i = 0; i < hand.Count; i++)
			{
				if(hand[i].AnimationOngoing())
				{
					bNoAnim = false;
					break;
				}
			}

			if(bNoAnim)
			{
				bFixHandPosition = false;
				//FixPositions();
			}
		}
		*/

		for(int i = 0; i < hand.Count; i++)
		{
			hand[i].Update();	
		}
	}
	
	public int GetCurrentCard()
	{
		for(int i = 0; i < hand.Count; i++)
		{
			if(CurrentSelectedCard == hand[i])
			{
				return i;	
			}
		}
		
		return -1;	
	}
	
	public Card GetCurrentCardObject()
	{
		return CurrentSelectedCard;	
	}
	
	public void SetCardSelected(Card card)
	{
		CurrentSelectedCard = card;	
	}
	
	public Card RemoveFromHand(int index)
	{
		if(index >= 0 && index < hand.Count)
		{
			Card cardToReturn = hand[index];
			cardToReturn.bIsInhand = false;
			hand.RemoveAt(index);		
			FixPositions();
			return cardToReturn;
		}
		else
		{
			return null;	
		}
	}
	
	public void RemoveFromHand(Card card)
	{
		hand.Remove(card);
		card.bIsInhand = false;
		FixPositions();
	}
	
	public int Size()
	{
		return hand.Count;	
	}
	
	public int GetIndexOf(Card card)
	{
		for(int i = 0; i < hand.Count; i++)
		{
			if(hand[i] == card)
			{
				return i;	
			}
		}
		return -1;
	}
	
	public void CheckHandEffects(CardState cs)
	{
		for(int i = 0; i < hand.Count; i++)
		{
			hand[i].unitAbilities.CheckAbilityOnHand(cs, hand[i]);
		}
	}
}
