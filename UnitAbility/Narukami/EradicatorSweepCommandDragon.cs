using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (2) & Soul Blast (2)] When your opponent's
 * rear-guard is put into the drop zone due to an effect from one of your
 * cards, you may pay the cost. If you do, draw a card, choose one of your
 * opponent's rear-guards in the front row, and retire it, and this unit 
 * gets [Power]+5000 until end of turn.
 * 
 * [AUTO]:[Choose one of your rear-guards with "Eradicator" in its card 
 * name, and put it into your soul] When this unit is placed on your (VC),
 * you may pay the cost. If you do, choose one of your opponent's rear-guards 
 * in the front row, and retire it.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class EradicatorSweepCommandDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(VC ()
			   && LimitBreak(4)
			   && CB (2)
			   && CanSoulBlast(2)
			   && GetDeck().Size() > 0
			   && NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Ride)
		{
			if(NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0
			   && NumUnits(delegate(Card c) { return c.name.Contains("Eradicator"); }) > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SelectUnit("Choose one of your rear-guards with \"Eradicator\" in its card name.", 1, false,
				delegate {
					MoveToSoul(Unit);
				},
				delegate {
					return Unit.name.Contains ("Eradicator");
				},
				delegate {
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
			else
			{
				CounterBlast(2,
				delegate {
					SoulBlast(2);
				});
			}
		});

		SoulBlastUpdate(delegate {
			DrawCard(1);
		});

		DrawCardUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guard in the front row.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return IsFrontRow(EnemyUnit);
			},
			delegate {
				IncreasePowerByTurn(OwnerCard, 5000);
			});
		});
	}
}
