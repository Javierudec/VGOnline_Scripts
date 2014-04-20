using UnityEngine;
using System.Collections;

public class RevengerBloodmaster : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(CB(1) 
			   && VanguardIs("Shadow Paladin")
			   && GetDeck().Size() >= 3)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				FromDeckToDamage(GetDeck().TopCard());
				DrawCard(2);
			});
		});

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}
