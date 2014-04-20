using UnityEngine;
using System.Collections;

public class StealthRogueOfDemonicHairGurenjishi : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB (1)
			   && GetDefensor().IsVanguard()
			   && VanguardIs("Murakumo")
			   && OwnerCard.IsBoostedBy != null
			   && OwnerCard.IsBoostedBy.BelongsToClan("Murakumo")
			   && GetDeck().Size() > 0)
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
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.cardID == CardIdentifier.STEALTH_ROGUE_OF_DEMONIC_HAIR__GURENJISHI;
				});
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck (_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			CallFromDeckList[0].unitAbilities.AddUnitObject(new StealthRogueOfDemonicHairGurenjishiEXT());
			EndEffect();
			ShuffleDeck ();
		});
	}
}

public class StealthRogueOfDemonicHairGurenjishiEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			FromFieldToDeck(OwnerCard, true);
		}
	}
}
