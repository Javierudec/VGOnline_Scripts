using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When an «Aqua Force» rides this unit, choose your vanguard, 
 * and until end of turn, that unit gets [Power]+10000 and "[AUTO](VC):
 * When this unit attacks a vanguard, your opponent may choose a card 
 * from his or her hand, and discard it. If your he or she does not, 
 * until end of that battle, this unit gets [Critical]+1, and your opponent 
 * cannot call units to (GC) from hand.".
 * 
 * [AUTO](VC):When this unit attacks a vanguard, this unit gets [Power]+2000 
 * until end of that battle.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class BlueFlightDragonTranscoreDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak (4)
			   && VanguardIs("Aqua Force"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC()
			   && GetDefensor ().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			GetVanguard ().unitAbilities.AddUnitObject(new BlueFlightDragonTranscoreDragonEXT());
			EndEffect();
		});
	}
}

public class BlueFlightDragonTranscoreDragonEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void DecisionWindowAccept ()
	{
		EnemyHasToDiscardOneCard();
	}

	public override void DecisionWindowDenied ()
	{
		IncreaseCriticalByBattle(OwnerCard, 1);
		BlockEnemyGuard(0);
		EndEffect();
	}

	public override void EndEvent ()
	{
		EndEffect();
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			if(GetEnemyHand().Size() > 0)
			{
				OpponentOpenDecisionWindow("You may choose a card from your hand and discard.");
			}
			else
			{
				IncreaseCriticalByBattle(OwnerCard, 1);
				BlockEnemyGuard(0);
				EndEffect();
			}
		});
	}
}
