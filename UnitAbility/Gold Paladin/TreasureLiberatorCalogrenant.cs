using UnityEngine;
using System.Collections;

public class TreasureLiberatorCalogrenant : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC ()
			   && CB(1)
			   && Game.DriveCard.grade == 3
			   && Game.DriveCard.BelongsToClan("Gold Paladin")
			   && GetDeck().Size() > 0
			   && OpenRC())
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SetBool(1);
			GetDeck().ViewDeck(1, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, 1, delegate(Game2DCard c) {
				return c._CardInfo.BelongsToClan("Gold Paladin");
			});
		});

		ResolveDeckOpening(1,
		delegate {
			OnlyOpenRC(true);
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDamageUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();
		});
	}
}
