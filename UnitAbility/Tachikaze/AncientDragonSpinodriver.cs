using UnityEngine;
using System.Collections;

public class AncientDragonSpinodriver : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4)
			   && NumUnits(delegate(Card c) { return c.BelongsToClan("Tachikaze"); }) >= 2
			   && GetDeck ().Size() >= 2)
			{
				DisplayConfirmationWindow();
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

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose two of your \"Tachikaze\" rear-guards.", 2, false,
			delegate {
				RetireUnit(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Tachikaze");
			},
			delegate {
				DrawCard(2);
			});
		});

		DrawCardUpdate(delegate {
			IncreasePowerAndCriticalByTurn(GetVanguard(), 10000, 1);
			EndEffect();
		});
	}
}
