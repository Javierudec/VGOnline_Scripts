using UnityEngine;
using System.Collections;

public class AngelicWiseman : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(CanSoulBlast(3)
			   && VanguardIs("Genesis"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(3);
		});

		SoulBlastUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 4000);
			EndEffect();
		});
	}
}
