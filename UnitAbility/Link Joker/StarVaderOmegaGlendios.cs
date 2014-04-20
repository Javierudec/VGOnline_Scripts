using UnityEngine;
using System.Collections;

public class StarVaderOmegaGlendios : UnitObject {
	bool bLockEnemyUnit = false;
	bool bCanUseAUTO2 = true;
	bool bUseAUTO1 = false;

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(1)
		   && HandSize(delegate(Card c) { return c.name.Contains("Reverse"); }) > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Cont ()
	{
		if(IsPlayerTurn())
		{
			ForEachUnitOnField(delegate(Card c) {
				if(c.name.Contains("Reverse"))
				{
					c.unitAbilities._UnitObject.AddContPower(4000);
					c.AddExtraClan("Link Joker");
				}
			});
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(bLockEnemyUnit)
			{
				bLockEnemyUnit = false;
				SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
				delegate {
					LockEnemyUnit(EnemyUnit);
				},
				delegate {
					return true;
				},
				delegate {
					bCanUseAUTO2 = false;
				});
			}
			else if(bUseAUTO1)
			{
				bUseAUTO1 = false;
				WinGame();
			}
			else
			{
				CounterBlast(1,
				delegate {
					SelectInHand(1, true,
					delegate {
						DiscardSelectedCard();
					},
					delegate {
						return _SIH_Card.name.Contains("Reverse");
					},
					delegate {
						ForEachEnemyUnitOnField(delegate(Card c) {
							OmegaLock(c);
						});
					}, "Choose one card with \"Reverse\" in its card name.");
				});
			}
		});
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call_NotMe)
		{
			if(ownerEffect.name.Contains("Reverse")
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0
			   && bCanUseAUTO2)
			{
				bLockEnemyUnit = true;
				ShowAndDelay();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			bCanUseAUTO2 = true;
		}
		else if(cs == CardState.BeginMain)
		{
			if(VC ()
			   && LimitBreak(5)
			   && NumEnemyUnits(delegate(Card c) { return c.IsLocked(); }, true, true) >= 5)
			{
				bUseAUTO1 = true;
				ShowAndDelay();
			}
		}
	}
}
