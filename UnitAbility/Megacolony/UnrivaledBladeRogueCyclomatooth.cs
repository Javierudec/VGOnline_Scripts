using UnityEngine;
using System.Collections;

public class UnrivaledBladeRogueCyclomatooth : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Megacolony")
			   && LimitBreak(4))
			{
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			ForEachEnemyUnitOnField(delegate(Card c) {
				RestEnemyUnit(c);
				CantStandUntilNextTurn(c);
			});
			EndEffect();
		});
	}

	public override void Cont ()
	{
		if(VC()
		   && IsPlayerTurn())
		{
			if(NumEnemyUnits(delegate(Card c) { return !c.IsStand(); }, true) == NumEnemyUnits(delegate(Card c) { return true; }, true))
			{
				AddContPower(2000);
			}
		}
	}
}
