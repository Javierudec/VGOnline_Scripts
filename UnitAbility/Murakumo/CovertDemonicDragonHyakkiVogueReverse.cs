using UnityEngine;
using System.Collections;

public class CovertDemonicDragonHyakkiVogueReverse : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Murakumo"); }) >= 2)
		{
			return 1;
		}

		return 0;
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride)
		{
			if(CB(2)
			   && GetDeck().Size() > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				CounterBlast(2,
				delegate {
					SetBool(2);
					GetDeck().ViewDeck(1, delegate(Game2DCard c) {
						return c._CardInfo.cardID == CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____;
					});
				});
			}
			else
			{
				SelectUnit ("Choose two of your \"Murakumo\" rear-guards.", 2, false,
				delegate {
					LockUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Murakumo");
				},
				delegate {
					int n = NumUnits (delegate(Card c) { return c.cardID == CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____; }, true);
					SelectUnit("Choose " + n + " of your units named \"Covert Demonic Dragon, Hyakki Vogue \"Reverse\"\".", n, true,
					delegate {
						IncreasePowerByTurn(Unit, 10000);
					},
					delegate {
						return Unit.cardID == CardIdentifier.COVERT_DEMONIC_DRAGON__HYAKKI_VOGUE______REVERSE_____;
					},
					delegate {

					}, true);
				});
			}
		});

		ResolveDeckOpening(2, 
		delegate {
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			CallFromDeckList[0].unitAbilities.AddUnitObject(new CovertDemonicDragonHyakkiVogueReverseEXT());
			EndEffect();
			ShuffleDeck();
		});
	}
}

public class CovertDemonicDragonHyakkiVogueReverseEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			ReturnToHand(OwnerCard);
		}
	}
}
