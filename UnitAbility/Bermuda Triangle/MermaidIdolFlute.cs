using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC):During your turn, if the number of 
 * «Bermuda Triangle» rear-guards you have is four 
 * or more, this unit gets [Power]+3000.
 */

public class MermaidIdolFlute : UnitObject {
	public override void Cont ()
	{
		if(IsPlayerTurn()
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }) >= 4)
		{
			AddContPower(3000);
		}
	}	
}
