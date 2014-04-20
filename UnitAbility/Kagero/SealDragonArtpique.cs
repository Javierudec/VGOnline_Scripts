using UnityEngine;
using System.Collections;

/*
 * [ACT](RC):[Put this unit into your soul] Choose up to one of 
 * your «Kagerō», and that unit gets [Power]+3000 until end of turn.
 */

public class SealDragonArtpique : UnitObject {
	public override int Act ()
	{
		if(RC ())
		{

		}

		return 0;
	}

	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Kagero"); }) > 0)
			{
				SelectUnit("Choose one of your \"Kagero\".", 1, true,
				delegate {
					IncreasePowerByTurn(OwnerCard, 3000);
				},
				delegate {
					return Unit.BelongsToClan("Kagero");
				},
				delegate {
				
				}, true);
			}
			else
			{
				EndEffect();
			}
		});
	}
}
