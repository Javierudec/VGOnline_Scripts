using UnityEngine;
using System.Collections;

/*
 * [CONT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):During your turn, this unit gets [Power]+3000 for each of your
 * grade 1 or less «Royal Paladin» rear-guards.
 * 
 * [AUTO]:[Choose a «Royal Paladin» from your hand, and discard it] When 
 * this unit placed on (VC), you may pay the cost. If you do, search your deck 
 * for up to one grade 1 or less «Royal Paladin», call it to (RC), and shuffle 
 * your deck.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class SanctuaryGuardDragon : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC() && LimitBreak(4) && IsPlayerTurn())
		{
			power += NumUnits(delegate(Card c) { return c.grade <= 1 && c.BelongsToClan("Royal Paladin"); }) * 3000;
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride)
		{
			if(HandSize(delegate(Card c) { return c.BelongsToClan("Royal Paladin"); }) > 0 && GetDeck().Size() > 0)
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
			SelectInHand(1, true, 
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.BelongsToClan("Royal Paladin");
			},
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.grade <= 1 && c._CardInfo.BelongsToClan("Royal Paladin");	
				});
			}, "Choose one \"Royal Paladin\" from your hand.");
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck (_AuxIdVector);
			}
			else
			{
				EndEffect();	
				ShuffleDeck();
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}


