using UnityEngine;
using System.Collections;

public class BarrierTroopRevengerDorint : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe || cs == CardState.Call_NotMe)
		{
			if(ownerEffect.cardID == CardIdentifier.BLASTER_DARK_REVENGER
			   && GetVanguard().name.Contains("Revenger")
			   && NumUnitsDamage(delegate(Card c) { return !c.IsFaceup(); }) > 0
			   && GetSameColum(ownerEffect.pos) == OwnerCard)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			Flipup(1,
			delegate {
				EndEffect();
			});
		});
	}
}
