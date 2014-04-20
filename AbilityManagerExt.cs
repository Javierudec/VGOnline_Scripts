using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityContainerExt
{
	public Card card;
	public CardState cardState;
	public int idx;
	public Card effectOwner;
	
	public AbilityContainerExt(Card _card, CardState _cardState, int _idx, Card _effectOwner = null)
	{
		card = _card;
		cardState = _cardState;
		idx = _idx;
		effectOwner = _effectOwner;
	}
}

public class AbilityManagerExt {
	private Stack<AbilityContainerExt> S;
	
	public AbilityManagerExt()
	{
		S = new Stack<AbilityContainerExt>();
	}
	
	public int GetStackSize()
	{
		return S.Count;	
	}
	
	public AbilityContainerExt RetrieveNextAbility()
	{
		AbilityContainerExt toReturn = S.Peek();
		S.Pop();
		return toReturn;
	}
	
	public void ExecuteNextAbility()
	{
		AbilityContainerExt nextAbility = RetrieveNextAbility();
		nextAbility.card.unitAbilities.ExternAuto[nextAbility.idx](nextAbility.cardState, nextAbility.effectOwner);
	}
	
	public void AddAbility(CardState cs, Card card, int idx, Card effectOwner)
	{
		S.Push(new AbilityContainerExt(card, cs, idx, effectOwner));	
	}
}
