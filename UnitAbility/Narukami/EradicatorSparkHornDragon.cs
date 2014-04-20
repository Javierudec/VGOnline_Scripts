using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):When this unit attacks a vanguard, this unit gets 
 * [Power]+5000 until end of that battle.
 * 
 * [AUTO](VC):[Counter Blast (1)-card with "Eradicator" in its card name] 
 * When this unit's attack hits a vanguard, you may pay the cost. If you 
 * do, your opponent chooses one of his or her rear-guards, and retires it.
 */

public class EradicatorSparkHornDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 5000);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(VC()
			   && CB (1, delegate(Card c) { return c.name.Contains("Eradicator"); })
			   && GetVanguard().IsVanguard()
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active()
	{
		ShowAndDelay();
	}

	public override void EndEvent ()
	{
		EndEffect();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				OpponentRetireUnit();
			},
			delegate(Card c) {
				return c.name.Contains("Eradicator");
			});
		});
	}
}
