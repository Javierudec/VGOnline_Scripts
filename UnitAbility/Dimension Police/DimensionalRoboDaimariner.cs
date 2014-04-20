using UnityEngine;
using System.Collections;

/*
 * [ACT](Soul):[Put this card into your drop zone] Choose one of your 
 * «Dimension Police» vanguards, and that unit gets [Power]+3000 until 
 * end of turn.
 */

public class DimensionalRoboDaimariner : UnitObject {
	public override int EffectOnSoul ()
	{
		if(VanguardIs("Dimension Police"))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
		Game.field.CloseDeck();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			_AuxIdVector = new System.Collections.Generic.List<CardIdentifier>();
			_AuxIdVector.Add(CardIdentifier.DIMENSIONAL_ROBO__DAIMARINER);
			SoulBlast(_AuxIdVector);
		});
		
		SoulBlastUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 3000);
			EndEffect();
		});
	}
}
