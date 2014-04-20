using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage): [Soul Blast (3)] When this unit attacks a vanguard, you may pay 
 * the cost. If you do, draw two cards, choose a card from your hand, put it 
 * into your soul, and this unit gets [Power]+5000 until end of that battle.
 * 
 * [CONT](VC):If you have a card named "Twilight Hunter, Artemis" in your 
 * soul, this unit gets [Power]+1000.
 */

public class BattleDeityOfTheNightArtemis : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsInSoul(CardIdentifier.TWILIGHT_HUNTER__ARTEMIS))
		{
			power += 1000;	
		}
		SetPower (power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && LimitBreak(4) && CanSoulBlast(3) && GetDefensor().IsVanguard() && GetDeck().Size() >= 2)
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
			SoulBlast(3);	
		});
		
		SoulBlastUpdate(delegate {
			DrawCard(2);	
		});
		
		DrawCardUpdate(delegate  {
			SelectInHand(1, true, 
			delegate {
				FromHandToSoul(_SIH_Card, GetHand().GetCurrentCard());
			},
			delegate {
				return true;
			},
			delegate {
				
			}, "Choose one card from your hand.");
		});
		
		FromHandToSoulUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 5000);
			EndEffect();
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
	}
}
