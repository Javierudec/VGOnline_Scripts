using UnityEngine;
using System.Collections;

/*
 * [CONT](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):During your turn, if the number of cards in your soul with 
 * "Dimensional Robo" in its card name is three or more, this unit gets 
 * [Power]+2000/[Critical]+1.
 * 
 * [CONT](VC/RC):If you have a non-«Dimension Police» vanguard or rear-guard, 
 * this unit gets [Power]-2000.
 * [CONT](VC):If you have a card named "Super Dimensional Robo, Daiyusha" 
 * in your soul, this unit gets [Power]+2000.
 */

public class UltimateDimensionalRoboGreatDaiyusha : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && IsPlayerTurn()
		   && NumUnitsInSoul(delegate(Card c) { return c.name.Contains("Dimensional Robo"); }) >= 3)
		{
			AddContPower(2000);
			AddContCritical(1);
		}

		if(NumUnits (delegate(Card c) { return !c.BelongsToClan("Dimension Police"); }, true) > 0)
		{
			AddContPower(-2000);
		}

		if(VC ()
		   && IsInSoul(CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIYUSHA))
		{
			AddContPower(2000);
		}
	}
}
