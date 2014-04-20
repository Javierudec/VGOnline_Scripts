using UnityEngine;
using System.Collections;

public class IronFanEradicatorRasetsunyo : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB(2)
			   && VanguardIs("Narukami")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				DrawCardWithoutDelay();
			});
		});
	}
}
