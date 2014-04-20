using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more damage):
 * [Counter Blast (2) & Choose two of your «Shadow Paladin» rear-guards, and retire them]
 * When this unit attacks, you may pay the cost. If you do, draw two cards, and this unit gets [Power] +3000 until end of that battle.
 * [AUTO](VC):When this unit attacks a vanguard, this unit gets [Power] +3000 until end of that battle.
 */ 

public class OriginMageIlldona : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			
			if(LimitBreak(4) && VC () && CB (2) && NumUnits(delegate(Card c) { return c.BelongsToClan("Shadow Paladin"); }) > 0 && GetDeck().Size() >= 2)
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
			SelectUnit("Choose two of your Shadow Paladin rear-guards.", 2, false,
			delegate {
				RetireUnit(Unit);	
			},
			delegate {
				return Unit.BelongsToClan("Shadow Paladin");	
			},
			delegate {
				DrawCard(2);
			});
		});
		
		DrawCardUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 3000);
			EndEffect();
			ConfirmAttack();
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
