using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityContainer
{
	public Card card;
	public CardState cardState;
	public int id;
	public Card effectOwner;
	
	public AbilityContainer(Card _card, CardState _cardState, int _id, Card _effectOwner = null)
	{
		card = _card;
		cardState = _cardState;
		id = _id;
		effectOwner = _effectOwner;
	}
}

public class AbilityManager {
	private Stack<AbilityContainer> S;
	private Gameplay _Game;
	
	public AbilityManager(Gameplay myGame)
	{
		S = new Stack<AbilityContainer>();
		_Game = myGame;
	}
	
	public int GetStackSize()
	{
		return S.Count;	
	}
	
	public AbilityContainer RetrieveNextAbility()
	{
		AbilityContainer toReturn = S.Peek();
		S.Pop();
		return toReturn;
	}
	
	public void ExecuteNextAbility()
	{
		AbilityContainer nextAbility = RetrieveNextAbility();
		
		if(Util.IsEnemyPosition(nextAbility.card.pos))
		{
			_Game.bEffectOnGoing = true;
			_Game.SendPacket(GameAction.CHECK_CARD_ABILITY, (int)nextAbility.cardState);
		}
		else
		{
			if(nextAbility.id == -1)
			{
				nextAbility.card.CheckAbilities(nextAbility.cardState, nextAbility.effectOwner);
			}
			else
			{
				nextAbility.card.CheckExternAbilities(nextAbility.id, nextAbility.cardState);	
			}
		}
	}
	
	public void AddAbility(CardState cs, Card card, int id = -1, Card effectOwner = null)
	{
		S.Push(new AbilityContainer(card, cs, id, effectOwner));	
	}

	public delegate void OnListDel(Card c);

	public void ViewCardsOnStack(OnListDel f)
	{
		/*
		AbilityContainer[] tmp = S.ToArray();
		for(int i = 0; i < S.Count; i++)
		{
			f(tmp[i].effectOwner);
		}
		*/
		Stack<AbilityContainer> tmpStack = new Stack<AbilityContainer>();
		while(S.Count > 0)
		{
			AbilityContainer c = S.Peek();
			S.Pop();

			if(c.card != null)
			{
				f(c.card);
			}

			tmpStack.Push(c);
		}

		while(tmpStack.Count > 0)
		{
			AbilityContainer c = tmpStack.Peek();
			tmpStack.Pop();
			S.Push(c);
		}
	}

	public void ExecuteAbilityWithIndex(int index)
	{
		Stack<AbilityContainer> tmpStack = new Stack<AbilityContainer>();

		int counter = 0;

		while(S.Count > 0)
		{
			AbilityContainer c = S.Peek();
			S.Pop();

			if(counter == index)
			{
				while(tmpStack.Count > 0)
				{
					S.Push(tmpStack.Peek());
					tmpStack.Pop();
				}

				c.card.CheckAbilities(c.cardState, c.effectOwner);
			}

			tmpStack.Push(c);
			counter++;
		}
	}

	List<string> LastAbilityList = null;

	public bool ManagerListNeedsToBeOpen()
	{
		List<Card> markedList = new List<Card>();
		LastAbilityList = new List<string>();

		Stack<AbilityContainer> tmpStack = new Stack<AbilityContainer>();
		while(S.Count > 0)
		{
			AbilityContainer c = S.Peek();
			S.Pop();

			if(c.card != null && !markedList.Contains(c.card) && AutoCanBeTriggered(c))
			{
				markedList.Add(c.card);
				LastAbilityList.Add(c.card.name);
			}
			
			tmpStack.Push(c);
		}
		
		while(tmpStack.Count > 0)
		{
			AbilityContainer c = tmpStack.Peek();
			tmpStack.Pop();
			S.Push(c);
		}

		return false;
	}

	public List<string> GetList()
	{
		return LastAbilityList;
	}

	bool AutoCanBeTriggered(AbilityContainer c)
	{
		_Game.bCheckAutoMode =  true;
		_Game.bAutoCanBeTriggered = false;
		c.card.CheckAbilities(c.cardState, c.effectOwner);
		_Game.bCheckAutoMode = false;
		return _Game.bAutoCanBeTriggered;
	}

	/*
	public void AddOnTop(CardState cs, Card card)
	{
		Stack<AbilityContainer> tmp = new Stack<AbilityContainer>();
		while(S.Count > 0)
		{
			tmp.Push(S.Pop());	
		}
		S.Push(new AbilityContainer(card, cs));
		while(tmp.Count > 0)
		{
			S.Push(tmp.Pop());	
		}
	}
	*/
}
