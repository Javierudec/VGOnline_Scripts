using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC):At the beginning of your main phase, Soul Charge (1), 
 * and this unit gets [Power]+2000 until end of turn.
 * 
 * [ACT](VC):[Soul Blast (8) & Counter Blast (5)] Until end of the 
 * game, this unit gets [Critical]+1, and gets "[CONT](VC): This unit
 * gets [Power]+1000 for each of your «Gold Paladin» rear-guards.".
 */

public class KnightOfFuryAgravain : UnitObject {
	public override void Cont ()
	{
		if(GetBool(2))
		{
			AddContCritical(1);
			if(VC())
			{
				AddContPower(1000 * NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }));
			}
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.BeginMain)
		{
			if(VC()
			   && GetDeck().Size() > 0)
			{
				SetBool(1);
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && CanSoulBlast(8)
		   && CB(5))
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		StartEffect();
		ShowAndDelay ();
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
				SoulBlast(8);
			}
		});

		SoulBlastUpdate(delegate {
			CounterBlast(5,
			delegate {
				SetBool(2);
				EndEffect();
			});
		});

		SoulChargeUpdate(delegate {
			IncreasePowerByTurn(OwnerCard, 2000);
			EndEffect();
		});
	}
}
