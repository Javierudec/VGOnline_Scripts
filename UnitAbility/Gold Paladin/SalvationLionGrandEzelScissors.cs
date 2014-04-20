using UnityEngine;
using System.Collections;

public class SalvationLionGrandEzelScissors : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(2)
		   && CanSoulBlast(2))
		{
			return 1;
		}

		return 0;
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.HelpZone_EndTurn)
		{
			if(GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
				SetBool(1);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SoulCharge(1);
			}
			else
			{
				CounterBlast(2,
				delegate {
					SoulBlast(2);
				});
			}
		});

		SoulChargeUpdate(delegate {
			if(NumUnitsDamage(delegate(Card c) { return !c.IsFaceup(); }) > 0)
			{
				Flipup(1,
				delegate {
					RemoveFromHelpZone(OwnerCard);
					EndEffect();
				});
			}
			else
			{
				RemoveFromHelpZone(OwnerCard);
				EndEffect();
			}
		});

		SoulBlastUpdate(delegate {
			ForEachUnitOnField(delegate(Card c) {
				if(c.IsLocked())
				{
					UnlockUnit(c);
				}
			});

			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }) == 5)
			{
				IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);
			}

			AddToHelpZone(OwnerCard);
			EndEffect();
		});
	}
}
