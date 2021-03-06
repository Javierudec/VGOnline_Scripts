using UnityEngine;
using System.Collections;

/*
 * [ACT](Hand):[Reveal this card to your opponent, and put 
 * it on the bottom of your deck] If you have a «Spike 
 * Brothers» vanguard, search your deck for up to one 
 * grade 2 or less «Spike Brothers» with "Dudley" in its 
 * name, reveal it to your opponent, put it into your hand, and 
 * shuffle your deck.
 */ 

public class JellyBeans : UnitObject {
	public override bool EffectOnHand ()
	{
		return true;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
		ShowCardInHand(OwnerCard);
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			ReturnCardFromHandToDeck(true, false);
			if(VanguardIs("Spike Brothers"))
			{
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Spike Brothers") && c._CardInfo.grade <= 2 && c._CardInfo.name.Contains("Dudley");	
				});
			}
			else
			{
				EndEffect();	
			}
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);	
			}
			EndEffect();
			ShuffleDeck();
		}
	}
}
