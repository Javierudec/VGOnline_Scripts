using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDeck {
	//Provide information about positions and rotations of the cards on the field.
	private EnemyFieldInformation fieldInfo; 	
	//Array with the cards currently in the deck
	private List<Card> cards;

	public EnemyDeck()
	{
		fieldInfo = new EnemyFieldInformation();
		cards     = new List<Card>();
	}
	
	//Add a Card to the Deck
	public void AddCard(Card card, bool bWithAnim = true)
	{
		cards.Add(card);

		if(bWithAnim)
		{
			SetDeckPosition();
		}
	}

	public int Size()
	{
		return cards.Count;
	}
	
	//Each card object is associated with a GameObject
	public void linkGameObjectToCard(GameObject go, HandleEnemyMouse m, int index)
	{
		cards[index].SetGameObject(go, m);	
	}
	
	//Set the position of each card in the scene.
	public void SetDeckPosition()
	{
		Vector3 position = fieldInfo.GetPosition((int)EnemyFieldPosition.DECK);
		Vector3 delta = new Vector3(0.0f, 0.025f, 0.0f);
		
		for(int i = 0; i < cards.Count; i++)
		{
			/*
			cards[i].GetGameObject().transform.position = position + i * delta;	
			cards[i].GetGameObject().transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
			*/
			cards[i].MoveAndRotate(position + i * delta, new Vector3(0.0f, 180.0f, 0.0f));
			cards[i].TurnDown();
		}
	}
	
	public Card TopCard()
	{
		if(cards.Count > 0)
		{
			return cards[cards.Count - 1];	
		}
		else
		{	
			return null;
		}
	}
	
	public Card DrawCard()
	{
		//Debug.Log ("Number of cards enemy deck: " + cards.Count);
		if(cards.Count > 0)
		{
			Card CardToReturn = cards[cards.Count - 1];
			cards.RemoveAt(cards.Count - 1);
			SetDeckPosition();
			return CardToReturn;
		}
		else
		{
			return null;	
		}
	}
	
	public int GetNumberOfRearUnitsWithGradeLessOrEqual(int grade)
	{
		int num = 0;
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].grade <= grade)
			{
				num++;	
			}
		}
		return num;
	}
	
	public int GetNumberOfCards()
	{
		return cards.Count;	
	}
	
	public void Update()
	{
		for(int i = 0; i < cards.Count; i++)
		{
			cards[i].Update();	
		}
	}
	
	public void ReturnToDeck(Card card)
	{
		Vector3 deck = fieldInfo.GetPosition((int)EnemyFieldPosition.DECK);
		card.GoTo (deck.x, deck.z);
		AddCard(card);
	}
}
