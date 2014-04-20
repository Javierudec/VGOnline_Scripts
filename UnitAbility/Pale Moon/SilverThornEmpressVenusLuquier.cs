using UnityEngine;
using System.Collections;

public class SilverThornEmpressVenusLuquier : UnitObject {
	int remainingLevels = 0;
	int remainingUnits = 0;
	bool bCanUseAct1 = true;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			bCanUseAct1 = true;
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(2, delegate(Card c) { return c.name.Contains("Silver Thorn"); })
		   && GetDeck().Size() >= 2
		   && bCanUseAct1)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SoulCharge(2);
			},
			delegate(Card c) {
				return c.name.Contains("Silver Thorn");
			});
		});

		SoulChargeUpdate(delegate {
			bCanUseAct1 = false;
			remainingLevels = 6;
			remainingUnits = 5;
			SetBool(1);
			Game.field.ViewSoul(1, 
			delegate(Card c) {
				return c.grade <= remainingLevels && c.BelongsToClan("Pale Moon");
			});
		});

		ResolveSoulOpening(1,
		delegate {
			Card c = Game.field.GetSoulByID(_AuxIdVector[0]);
			remainingLevels -= c.grade;
			remainingUnits--;
			CallFromSoul(c);
		},
		delegate {
			EndEffect();
		});

		CallFromSoulUpdate(delegate {
			if(remainingUnits > 0 && Game.field.CountSoul(delegate(Card c) { return c.grade <= remainingLevels; }) > 0)
			{
				SetBool(1);
				Game.field.ViewSoul(1, 
				delegate(Card c) {
					return c.grade <= remainingLevels && c.BelongsToClan("Pale Moon");
				});
			}
			else
			{
				EndEffect();
			}
		});
	}

	public override void Cont ()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.SILVER_THORN_DRAGON_TAMER__LUQUIER))
		{
			AddContPower(2000);
		}
	}
}
