using UnityEngine;
using System.Collections;

public class EradicatorIgnitionDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4)
			   && VanguardIs("Narukami")
			   && CB(1))
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

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(GetVanguard(), 10000);
				if(NumEnemyUnits(delegate(Card c) { return true; }) > 0)
				{
					OpponentRetireUnit();
				}
				else
				{
					EndEffect();
				}
			});
		});
	}

	public override void EndEvent ()
	{
		if(!GetBool(1) && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
		{
			SetBool(1);
			OpponentRetireUnit();
		}
		else
		{
			UnsetBool(1);
			EndEffect();
		}
	}
}
