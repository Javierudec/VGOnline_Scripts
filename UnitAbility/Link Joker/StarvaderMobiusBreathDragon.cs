using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC): When this unit's attack hits a vanguard, choose one of your 
 * opponent's rear-guards, and lock it.
 * (The locked card is turned face down, and cannot do anything. It turns face 
 * up at the end of the owner's turn)
 */

public class StarvaderMobiusBreathDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(VC () && GetDefensor().IsVanguard() && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				LockEnemyUnit(EnemyUnit);
			},
			delegate {
				return true;
			},
			delegate {
				
			});
		});
	}
	
	public override void Pointer ()
	{
		SelectEnemyUnit_Pointer();
	}
}
