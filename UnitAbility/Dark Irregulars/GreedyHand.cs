using UnityEngine;
using System.Collections;

/*
 * [AUTO]: When another «Dark Irregulars» rides this unit,
 * you may call this card to (RC).
 * 
 * [ACT](RC): [Counter Blast (1) & Put this unit into your 
 * soul] Search your deck for up to one grade 2 or less 
 * «Dark Irregulars», put it into your soul, and shuffle your deck.
 */

public class GreedyHand : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Dark Irregulars"))
			{
				SetBool(1);
				Forerunner("Dark Irregulars");
			}
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && CB (1)
		   && GetDeck ().Size() > 0)
		{
			return 1;
		}

		return 0;
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				MoveToSoul(OwnerCard);
				SetBool(2);
				GetDeck().ViewDeck(1,
				delegate(Game2DCard c) {
					return c._CardInfo.BelongsToClan("Dark Irregulars") && c._CardInfo.grade <= 2;
				});
			});
		});

		ResolveDeckOpening(2,
		delegate {
			SoulCharge(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		SoulChargeUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
