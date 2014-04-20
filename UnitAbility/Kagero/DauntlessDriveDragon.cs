using UnityEngine;
using System.Collections;

/*
 * [AUTO] Limit Break 4 (This ability is active if you have four or more 
 * damage):When a «Kagerō» rides this unit, choose your vanguard, 
 * and until end of turn, that unit gets [Power]+10000 and "[AUTO](VC):
 * [Choose three cards from your hand, and discard them] At the end of 
 * the battle that this unit attacked, if this unit has not become [Stand] 
 * during that turn, you may pay the cost. If you do, [Stand] this unit.".
 * 
 * [AUTO](VC):When this unit attacks, if the number of rear-guards you have 
 * is more than your opponent's, this unit gets [Power]+2000 until end of that 
 * battle.
 *
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class DauntlessDriveDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4)
			   && GetVanguard().BelongsToClan("Kagero"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC ()
			   && NumUnits(delegate(Card c) { return true; }) > NumEnemyUnits(delegate(Card c) { return true; }))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			GetVanguard().unitAbilities.AddUnitObject(new DauntlessDriveDragonEXT());
			EndEffect();
		});
	}
}

public class DauntlessDriveDragonEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			SetBool(1);
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1)
			   && VC ()
			   && HandSize() >= 3
			   && !OwnerCard.bBecomeStandThisTurn)
			{
				DisplayConfirmationWindow();
			}

			UnsetBool(1);
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			SelectInHand(3, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				StandUnit(OwnerCard);
			}, "Choose three cards from your hand.");
		});
	}
}
