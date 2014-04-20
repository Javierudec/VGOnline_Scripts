using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Narukami» rides this unit, choose your vanguard, and 
 * until end of turn, that unit gets [Power]+10000 and "[AUTO](VC):When your 
 * opponent's rear-guard is put into the drop zone due to an effect from one of 
 * your cards, choose one of your opponent's rear-guards in the back row of 
 * the same column as that retired unit, and retire it.".
 * 
 * [AUTO](VC):When this unit attacks, if the number of cards in your 
 * opponent's damage zone is three or more, this unit gets [Power]+2000 until 
 * end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class EradicatorElectricShaperDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && Game.enemyField.GetDamage() >= 3)
			{
				IncreasePowerByBattle(OwnerCard, 2000);	
			}
			ConfirmAttack();	
		}
		else if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Narukami") && LimitBreak(4))
			{
				IncreasePowerByTurn(GetVanguard(), 10000);	
				GetVanguard().unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
					if(cs == CardState.EnemyCardSendToDropZone)
					{
						Card tmp = GetEnemyBackRow(effectOwner);
						if(tmp != null)
						{
							RetireEnemyUnit(tmp);	
						}
					}
				});
			}
		}
	}
}
