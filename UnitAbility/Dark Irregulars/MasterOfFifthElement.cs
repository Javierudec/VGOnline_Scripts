using UnityEngine;
using System.Collections;

public class MasterOfFifthElement : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && IsPlayerTurn()
		   && NumUnitsInSoul(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) >= 10)
		{
			ForEachUnitOnField(delegate(Card c) {
				if(c.BelongsToClan("Dark Irregulars"))
				{
					c.unitAbilities.SetPower(3000);
				}
			});
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(VC ()
			   && GetDefensor().IsVanguard()
			   && CB(1)
			   && GetDeck().Size() >= 3)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SoulCharge(3);
			});
		});

		SoulChargeUpdate(delegate {
			EndEffect();
		});
	}
}
