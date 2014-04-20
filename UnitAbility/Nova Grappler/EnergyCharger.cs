using UnityEngine;
using System.Collections;

public class EnergyCharger : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(VanguardIs("Nova Grappler")
			   && CanSoulBlast(2)
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(2);
		});

		SoulBlastUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
