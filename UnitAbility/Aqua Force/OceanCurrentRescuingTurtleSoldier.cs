using UnityEngine;
using System.Collections;

public class OceanCurrentRescuingTurtleSoldier : UnitObject {
	Card cardToCall = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				if(cardToCall.BelongsToClan("Aqua Force") && (cardToCall.grade == 1 || cardToCall.grade == 2))
				{
					_AuxIdVector = new System.Collections.Generic.List<CardIdentifier>();
					_AuxIdVector.Add(cardToCall.cardID);
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					ShuffleDeck();
					EndEffect();
				}
			}
			else
			{
				cardToCall = RevealTopCard();
				Delay(0.5f);
				SetBool(1);
			}
		});

		CallFromDeckUpdate(delegate {
			EndEffect();
		});
	}
}
