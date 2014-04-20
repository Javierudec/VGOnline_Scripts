using UnityEngine;
using System.Collections;

public class EradicatorLorentzForceDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && ownerEffect.name.Contains("Eradicator")
			   && ownerEffect.grade == 3
			   && CB(1)
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
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
				OpponentRetireUnit();
			});
		});
	}

	public override void EndEvent ()
	{
		EndEffect();
	}
}
