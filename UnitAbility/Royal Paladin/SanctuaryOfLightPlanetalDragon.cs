using UnityEngine;
using System.Collections;

public class SanctuaryOfLightPlanetalDragon : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.SANCTUARY_OF_LIGHT__DETERMINATOR))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard())
			{
				ForEachUnitOnField(delegate(Card c) {
					if(c.name.Contains("Sanctuary of Light"))
					{
						IncreasePowerByTurn(c, 3000);
					}
				});
			}
		}
		else if(cs == CardState.Ride)
		{
			if(CB (2)
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SetBool(1);
				GetDeck().ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.name.Contains("Sanctuary of Light");
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
			EndEffect();
			ShuffleDeck();
		});
	}
}
