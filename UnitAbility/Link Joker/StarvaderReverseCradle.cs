using UnityEngine;
using System.Collections;

public class StarvaderReverseCradle : UnitObject {
	bool bCanUseAuto = true;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call_NotMe)
		{
			if(VC()
			   && bCanUseAuto
			   && LimitBreak(4)
			   && ownerEffect.name.Contains("Reverse")
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				ShowAndDelay();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			bCanUseAuto = true;
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				LockEnemyUnit(EnemyUnit);
			},
			delegate {
				return true;
			},
			delegate {
				IncreasePowerByTurn(OwnerCard, 5000);
				bCanUseAuto = false;
			});
		});
	}

	public override void Cont ()
	{
		if(VC ())
		{
			ForEachUnitOnField(delegate(Card c) { 
				if(!c.IsVanguard())
				{
					c.AddExtraClan("Link Joker");
				}
			});
		}
	}
}
