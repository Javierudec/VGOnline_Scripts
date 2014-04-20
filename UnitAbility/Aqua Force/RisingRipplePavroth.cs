using UnityEngine;
using System.Collections;

/*
 * [CONT](VC): If you have a card named "Silent Ripple, Sotirio" 
 * in your soul, this unit gets [Power]+1000.
 * 
 * [AUTO](VC): When this unit's attack hits a vanguard, if you 
 * have a card named "Silent Ripple, Sotirio" in your soul, 
 * choose one of your «Aqua Force» rear-guards, [Stand] it, 
 * and that unit gets [Power]+3000 until end of the turn.
 */

public class RisingRipplePavroth : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.SILENT_RIPPLE__SOTIRIO))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(VC()
			   && GetDefensor().IsVanguard()
			   && IsInSoul(CardIdentifier.SILENT_RIPPLE__SOTIRIO)
			   && NumUnits (delegate(Card c) { return c.BelongsToClan("Aqua Force") && !c.IsStand(); }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Aqua Force\" rear-guards.", 1, true,
			delegate {
				StandUnit(Unit);
				IncreasePowerByTurn(Unit, 3000);
			},
			delegate {
				return Unit.BelongsToClan("Aqua Force") && !Unit.IsStand();
			},
			delegate {

			});
		});
	}
}
