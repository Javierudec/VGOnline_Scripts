using UnityEngine;
using System.Collections;

/*
 * [CONT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):During your turn, if you have a face up card named "Solidify 
 * Celestial, Zerachiel" in your damage zone, all of your units with "Celestial" 
 * in its card name get [Power]+3000.
 * 
 * [ACT](VC):[Counter Blast (2)-card with "Celestial" in its card name] This unit gets 
 * [Power]+5000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class SolidifyCelestialZerachiel : UnitObject {
	public override void Cont ()
	{
		if(VC () 
		   && LimitBreak(4)
		   && IsPlayerTurn()
		   && NumUnitsDamage(delegate(Card c) { return c.IsFaceup() && c.cardID == CardIdentifier.SOLIDIFY_CELESTIAL__ZERACHIEL;}) > 0)
		{
			ForEachUnitOnField(delegate(Card c) {
				if(c.name.Contains("Celestial"))
				{
					c.unitAbilities.SetPower(3000);
				}
			});
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && CB(2, delegate(Card c) { return c.name.Contains("Celestial"); }))
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				IncreasePowerByBattle(OwnerCard, 5000);
				EndEffect();
			},
			delegate(Card c) {
				return c.name.Contains("Celestial");
			});
		});
	}
}
