using UnityEngine;
using System.Collections;

public class DauntlessDominateDragonReverse : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.DAUNTLESS_DRIVE_DRAGON))
		{
			AddContPower(2000);
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(1)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Kagero"); }) > 0
		   && !GetBool(1))
		{
			return 1;
		}

		return 0;
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && Game.DriveCard.grade >= 1
			   && Game.DriveCard.BelongsToClan("Kagero")
			   && NumEnemyUnits(delegate(Card c) { return c.grade <= 1; }) > 0)
			{
				SetBool(3);
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(3);
		return true;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(3))
			{
				UnsetBool(3);
				SelectEnemyUnit("Choose one of your opponent's grade 1 or less rear-guards.", 1, true,
				delegate {
					RetireEnemyUnit(EnemyUnit);
				},
				delegate {
					return EnemyUnit.grade <= 1;
				},
				delegate {
					IncreasePowerByTurn(OwnerCard, 3000);
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					SelectUnit ("Choose one of your \"Kagero\" rear-guards.", 1, true,
					delegate {
						SelectAnimField(OwnerCard);
						SetBool(1);
					},
					delegate {
						return Unit.BelongsToClan("Kagero");
					},
					delegate {

					});
				});
			}
		});
	}
}
