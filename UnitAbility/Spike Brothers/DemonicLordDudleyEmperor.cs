using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (2) & Choose two «Spike Brothers» 
 * from your hand, and put them into your soul] When this unit attacks a 
 * vanguard, you may pay the cost. If you do, search your deck for up to 
 * two «Spike Brothers», call them to separate open (RC), and shuffle your deck.
 * 
 * [AUTO](VC):When this unit is boosted by a «Spike Brothers», this unit 
 * gets [Power]+3000 until end of that battle.
 */

public class DemonicLordDudleyEmperor : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{			
			if(VC () && LimitBreak(4) && CB (2) && HandSize(delegate(Card c) { return c.BelongsToClan("Spike Brothers"); }) > 0 && GetDefensor().IsVanguard() && OpenRC())
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(tmp != null && tmp.BelongsToClan("Spike Brothers"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
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
			CounterBlast(2,
			delegate {
				SelectInHand(1, false, 
				delegate {
					FromHandToSoul(GetHand().GetCurrentCardObject(), GetHand().GetCurrentCard());
				},
				delegate {
					return GetHand().GetCurrentCardObject().BelongsToClan("Spike Brothers");
				},
				delegate {
					
				}, "Choose two \"Spike Brothers\" from your hand.");
			});
		});
		
		FromHandToSoulUpdate(delegate {
			if(GetBool(1))
			{	
				UnsetBool(1);
				int numOpenRC = 5 - NumUnits(delegate(Card c) { return true; });
				SetBool(2);
				GetDeck().ViewDeck(min(numOpenRC, 2), delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Spike Brothers");	
				});
			}
			else
			{
				SelectInHand(1, false,
				delegate {
					FromHandToSoul(GetHand().GetCurrentCardObject(), GetHand().GetCurrentCard());
					SetBool(1);
				},
				delegate {
					return GetHand().GetCurrentCardObject().BelongsToClan("Spike Brothers");
				},
				delegate {
					
				}, "Chose two \"Spike Brothers\" from your hand.");
			}
		});
		
		if(GetBool(2) && !GetDeck().IsOpen())
		{
			UnsetBool(2);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				OnlyOpenRC(true);
				CallFromDeck (_AuxIdVector);	
			}
			else
			{
				EndEffect();
				ShuffleDeck();
			}
		}
		
		CallFromDeckUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();	
			ShuffleDeck();
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
	}
}
