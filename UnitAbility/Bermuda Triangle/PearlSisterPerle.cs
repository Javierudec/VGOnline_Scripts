using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (RC), if you have a «Bermuda Triangle» 
 * vanguard, choose one of your units named "Pearl Sisters, Perla", and 
 * that unit gets "[AUTO](VC/RC):When this unit's attack hits a vanguard, 
 * Soul Charge (1), and draw a card." until end of turn.
 */

public class PearlSisterPerle : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(VanguardIs("Bermuda Triangle")
			   && NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.PEARL_SISTERS__PERLA; }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your units named \"Pearl Sisters, Perla\".", 1, true,
			delegate {
				SelectAnimField(Unit);
				Unit.unitAbilities.AddUnitObject(new PearlSisterPerleEXT());
			},
			delegate {
				return Unit.cardID == CardIdentifier.PEARL_SISTERS__PERLA;
			},
			delegate {

			}, true);
		});
	}
}

public class PearlSisterPerleEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard()
			   && GetDeck().Size () >= 2)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update()
	{
		DelayUpdate (delegate {
			SoulCharge(1);		
		});

		SoulChargeUpdate(delegate {
			DrawCard(1);
		});

		DrawCardUpdate(delegate {
			EndEffect();
		});
	}
}