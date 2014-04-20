using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Choose a card named "Transcendence Dragon, Dragonic Nouvelle 
 * Vague" from your hand, reveal it to your opponent, and put it on top of your 
 * deck] When this card is placed on (VC) or (RC), if you have a «Kagerō» 
 * vanguard, you may pay the cost. If you do, search your deck for up to one 
 * grade 3 or greater «Kagerō», reveal it to your opponent, put it into your 
 * hand, and shuffle your deck.
 */

public class NouvelleromanDragon : UnitObject {
	Card tmp;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(VanguardIs("Kagero") && IsInHand(CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE))
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				FromHandToDeck(tmp, false, false);
				SetBool(2);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Kagero") && c._CardInfo.grade >= 3;	
				});
			}
			else
			{
				SelectInHand(1, false,
				delegate {
					ShowCardInHand(_SIH_Card);
					tmp = _SIH_Card;
					Delay(1);
					SetBool(1);
				},
				delegate {
					return _SIH_Card.cardID == CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE;
				},
				delegate {
				
				}, "Choose a card named \"Transcendence Dragon, Dragonic Nouvelle Vague\" from your hand.");
			}
		});
		
		if(GetBool(2) && !GetDeck().IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);	
			}
			EndEffect();
			ShuffleDeck();
		}
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
	}
}
