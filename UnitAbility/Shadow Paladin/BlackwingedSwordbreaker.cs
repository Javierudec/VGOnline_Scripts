using UnityEngine;
using System.Collections;

public class BlackwingedSwordbreaker : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDeck)
		{
			if(CanSoulBlast(1)
			   && VanguardIs(OwnerCard.clan)
			   && GetDeck ().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			DrawCard(1);
		});

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}
