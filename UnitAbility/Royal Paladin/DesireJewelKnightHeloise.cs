using UnityEngine;
using System.Collections;

public class DesireJewelKnightHeloise : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner(OwnerCard.clan);
		}
		else if(cs == CardState.Boost)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && NumUnits(delegate(Card c) { return c != OwnerCard && c.name.Contains("Jewel Knight"); }) >= 3)
			{
				IncreasePowerByBattle(tmp, 3000);
			}
		}
	}

	public override void Active ()
	{
		Forerunner_Active();
	}

	public override void Update ()
	{
		Forerunner_Update();
	}
}
