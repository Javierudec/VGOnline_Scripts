﻿using UnityEngine;
using System.Collections;

/*
 * AUTO](VC/RC):[Counter Blast (2)] When this unit attacks, 
 * if you have a «Genesis» vanguard, you may pay the cost. 
 * If you do, this unit gets [Power]+5000 until end of that battle. 
 */

public class StealthDragonMagatsuBreath : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.STEALTH_DRAGON__MAGATSU_WIND))
		{
			AddContPower(1000);
		}
	}

	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.STEALTH_DRAGON__MAGATSU_GALE
			   && IsInSoul(CardIdentifier.STEALTH_DRAGON__MAGATSU_WIND)
			   && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(2, delegate(Game2DCard c) {
				return c._CardInfo.cardID == CardIdentifier.STEALTH_DRAGON__MAGATSU_GALE;
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			for(int i = 0; i < CallFromDeckList.Count; i++)
			{
				CallFromDeckList[i].unitAbilities.AddUnitObject(new StealthDragonMagatsuBreathEXT());
			}

			EndEffect();
			ShuffleDeck();
		});
	}
}

public class StealthDragonMagatsuBreathEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			FromFieldToDeck(OwnerCard, true);
		}
	}
}
