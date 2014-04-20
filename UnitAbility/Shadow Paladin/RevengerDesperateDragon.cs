using UnityEngine;
using System.Collections;

public class RevengerDesperateDragon : UnitObject 
{
	bool bUseAuto1 = false;
	bool bUseAuto2 = false;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && NumUnits(delegate(Card c) { return true; }) > NumEnemyUnits(delegate(Card c) { return true; })
			   && LimitBreak(4)
			   && CB(1, delegate(Card c) { return c.name.Contains("Revenger"); })
			   && VC())
			{
				bUseAuto1 = true;
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC ()
			   && NumUnits (delegate(Card c) { return c.BelongsToClan("Shadow Paladin"); }) > 0
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				bUseAuto2 = true;
				DisplayConfirmationWindow();
			}
		}
	}	

	public override bool Cancel ()
	{
		bUseAuto1 = false;
		bUseAuto2 = false;
		return true;
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			if(bUseAuto1)
			{
				bUseAuto1 = false;
				CounterBlast(1,
				delegate {
					IncreasePowerByBattle(OwnerCard, 5000);
					IncreaseCriticalByBattle(OwnerCard, 1);
				},
				delegate(Card c) {
					return c.name.Contains("Revenger");
				});
			}
			else if(bUseAuto2)
			{
				bUseAuto2 = false;
				SelectUnit ("Choose one of your \"Shadow Paladin\" rear-guards.", 1, false,
				delegate {
					RetireUnit (Unit);
				},
				delegate {
					return Unit.BelongsToClan("Shadow Paladin");
				},
				delegate {
					OpponentRetireUnit();
				});
			}
		});
	}

	public override void EndEvent ()
	{
		EndEffect();
	}
}
