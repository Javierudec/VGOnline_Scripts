using UnityEngine;
using System.Collections;

public class EmergencyCelestialDanielle : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DamageZone_CardPutInDamage)
		{
			if(CB(1, delegate(Card c) { return c != OwnerCard && c.name.Contains("Celestial"); })
			   && VanguardIs("Angel Feather")
			   && OwnerCard.IsFaceup())
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
				CallFromDamage(OwnerCard);
			},
			delegate(Card c)
			{
				return c.name.Contains("Angel Feather") && c != OwnerCard;
			});
		});

		CallFromDamageUpdate(delegate {
			FromDeckToDamage(GetDeck().TopCard(), true);
			EndEffect();
		});
	}
}
