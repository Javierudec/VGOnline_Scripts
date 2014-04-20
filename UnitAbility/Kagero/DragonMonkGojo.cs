using UnityEngine;
using System.Collections;

public class DragonMonkGojo : UnitObject {
	public override int Act ()
	{
		if(HandSize () > 0
		   && OwnerCard.IsStand()
		   && GetDeck().Size() > 0)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			RestUnit (OwnerCard);
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return true;
			},
			delegate {
				DrawCard(1);
			}, "Choose a card from your hand.");
		});

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}
