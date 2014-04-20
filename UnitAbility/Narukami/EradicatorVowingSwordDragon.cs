using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Narukami» rides this unit, choose one of your opponent's 
 * rear-guards in the front row, retire it, and choose your vanguard, and that 
 * unit gets [Power]+10000 until end of turn.
 * 
 * [AUTO](VC):When this unit attacks, if the number of cards in your 
 * opponent's damage zone is three or more, this unit gets [Power]+2000 until 
 * end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class EradicatorVowingSwordDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Narukami") && LimitBreak(4))
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				if(NumEnemyUnits(delegate(Card c) { return c.pos == fieldPositions.ENEMY_FRONT_LEFT || c.pos == fieldPositions.ENEMY_FRONT_RIGHT; }) > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC () && Game.enemyField.GetDamage() >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards in the front row.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return IsFrontRow(EnemyUnit);
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
