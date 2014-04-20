using UnityEngine;
using System.Collections;

public class BeastDeityNightJackal : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Nova Grappler");
		}
		else if(cs == CardState.Stand)
		{
			if(RC()
			   && CurrentPhaseIs(GamePhase.ATTACK))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
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
