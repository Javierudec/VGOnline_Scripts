using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (2)] When this unit attacks a vanguard, 
 * you may pay the cost. If you do, Soul Charge (1), choose one of your 
 * «Bermuda Triangle» rear-guards, return it to your hand, and this unit 
 * gets [Power]+5000 until end of that battle.
 * 
 * [CONT](VC):If you have a card named "Shiny Star, Coral" in your soul, 
 * this unit gets [Power]+1000.
 */

public class AuroraStarCoral : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsInSoul(CardIdentifier.SHINY_STAR__CORAL))
		{
			power += 1000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(LimitBreak(4) && GetDefensor().IsVanguard() && CB(2) && GetDeck().Size() > 0 && NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }) > 0)
			{
				DisplayConfirmationWindow();
			}
			else
			{
				ConfirmAttack();	
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
				SoulCharge(1);
			});
		});
		
		SoulChargeUpdate(delegate {
			SelectUnit("Choose one of your \"Bermuda Triangle\" rear-guards.", 1, true,
			delegate {
				ReturnToHand(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Bermuda Triangle");
			},
			delegate {
				IncreasePowerByBattle(OwnerCard, 5000);
				ConfirmAttack();
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
		CounterBlast_Pointer();
	}
}
