using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Stealth Dragon, Magatsu Breath" in your soul, this unit gets [Power]+1000.
 * 
 * [AUTO]:When a card named "Covert Demonic Dragon, Magatsu Storm" rides this unit, if you have a card named 
 * "Stealth Dragon, Magatsu Breath" in your soul, search your deck for up to two cards named "Covert Demonic 
 * Dragon, Magatsu Storm", call them to separate (RC), shuffle your deck, and at the end of that turn, put the
 * units called with this effect on the bottom of your deck in any order.
 */

public class StealthDragonMagatsuGale : UnitObject {
	public override void Cont()
	{
		if(VC()
		   && IsInSoul(CardIdentifier.STEALTH_DRAGON__MAGATSU_BREATH))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM
			   && IsInSoul(CardIdentifier.STEALTH_DRAGON__MAGATSU_BREATH)
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
				return c._CardInfo.cardID == CardIdentifier.COVERT_DEMONIC_DRAGON__MAGATSU_STORM;
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
				CallFromDeckList[i].unitAbilities.AddUnitObject(new StealthDragonMagatsuGaleEXT());
			}

			EndEffect();
			ShuffleDeck();
		});
	}
}

public class StealthDragonMagatsuGaleEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			FromFieldToDeck(OwnerCard, true);
		}
	}
}
