using UnityEngine;
using System.Collections;

public class RestrictedCardList {
	DeckInformation deckInformationRef = null;

	public DeckInformation GetDeckInfo()
	{
		return deckInformationRef;
	}

	public int CountByID(CardIdentifier id)
	{
		return deckInformationRef.CardList[(int)id];
	}

	public void SetDeckInformation(DeckInformation deckInfo)
	{
		deckInformationRef = deckInfo;
	}

	public virtual bool IsCardAllowed(Card2D cardToVerify)
	{
		return true;
	}
}
