using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):[Soul Blast (1) & Choose one card from your hand, and discard it] 
 * When this unit attacks a vanguard, you may pay the cost. 
 * If you do, choose another of your «Oracle Think Tank», and that unit gets [Power]+3000 until end of turn.
 */

public class GentleJimm : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && CanSoulBlast(1) && HandSize() > 0 && NumUnits(delegate(Card c) {
				return c != OwnerCard && c.BelongsToClan("Oracle Think Tank");
			}, true) > 0)
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
			SoulBlast(1);	
		});
		
		SoulBlastUpdate(delegate {
			SelectInHand(1, false,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				SelectUnit("Choose another of your \"Oracle Think Tank\" units.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 3000);
				},
				delegate {
					return Unit != OwnerCard && Unit.BelongsToClan("Oracle Think Tank");
				},
				delegate {
					ConfirmAttack();
				});
			}, "Choose a card from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		SelectInHand_Pointer();
		SelectUnit_Pointer();
	}
}
