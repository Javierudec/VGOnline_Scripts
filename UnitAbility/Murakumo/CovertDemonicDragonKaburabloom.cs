using UnityEngine;
using System.Collections;

public class CovertDemonicDragonKaburabloom : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(LimitBreak(4)
			   && VanguardIs("Murakumo")
			   && CB(1))
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.IsBoosted)
		{
			Card tmp = OwnerCard.IsBoostedBy;
			if(VC()
			   && tmp.BelongsToClan("Murakumo"))
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				IncreasePowerByTurn(GetVanguard(), 10000);
				if(GetDeck().Size() > 0)
				{
					SetBool(1);
					GetDeck().ViewDeck(2, delegate(Game2DCard c) {
						return c._CardInfo.cardID == GetVanguard().cardID;
					});
				}
				else
				{
					EndEffect();
				}
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
				CallFromDeckList[i].unitAbilities.AddUnitObject(new CovertDemonicDragonKaburabloomEXT());
			}

			EndEffect();
			ShuffleDeck();
		});
	}
}

public class CovertDemonicDragonKaburabloomEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			ReturnToHand(OwnerCard);
		}
	}
}
