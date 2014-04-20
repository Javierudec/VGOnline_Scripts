using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemonConqueringDragonDungareeUnlimited : UnitObject {
	public override void Cont ()
	{
		if(VC()
		   && IsInSoul (CardIdentifier.SEALED_DEMON_DRAGON__DUNGAREE))
		{
			AddContPower(2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard()
			   && CB(2)
			   && GetDeck ().Size() > 0)
			{
				DisplayConfirmationWindow();
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
			CounterBlast(2,
			delegate {
				List<Card> _tmpCardList = new List<Card>();
				_tmpCardList.Add(GetDeck().TopCard());
				BindFromDeck(_tmpCardList);
			});
		});

		BindFromDeckUpdate(delegate {
			if(NumEnemyUnits(delegate(Card c) { return IsFrontRow(c); }) > 0)
			{
				SelectEnemyUnit("Choose one of your opponent's rear-guard in the front row.", 1, true,
				delegate {
					RetireEnemyUnit(EnemyUnit);
				},
				delegate {
					return IsFrontRow(EnemyUnit);
				},
				delegate {
					IncreasePowerByTurn(OwnerCard, 2000 * NumUnitsInBind(delegate(Card c) { return c.BelongsToClan("Narukami"); }));
				});
			}
			else
			{
				IncreasePowerByTurn(OwnerCard, 2000 * NumUnitsInBind(delegate(Card c) { return c.BelongsToClan("Narukami"); }));
			}
		});
	}
}
