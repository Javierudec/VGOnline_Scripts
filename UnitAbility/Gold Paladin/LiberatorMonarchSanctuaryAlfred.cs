using UnityEngine;
using System.Collections;

public class LiberatorMonarchSanctuaryAlfred : UnitObject {
	bool bCanUseAct1 = true;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDeck_NotMe)
		{
			if(VC ()
			   && LimitBreak(5)
			   && ownerEffect.cardID == CardIdentifier.BLASTER_BLADE_LIBERATOR)
			{
				IncreasePowerAndCriticalByTurn(OwnerCard, 10000, 1);
			}
		}
		else if(cs == CardState.EndTurn)
		{
			bCanUseAct1 = true;
		}
	}

	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB(3)
		   && CanSoulBlast(2)
		   && bCanUseAct1)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				SoulBlast(2);
			});
		});

		SoulBlastUpdate(delegate {
			ForEachUnitOnField(delegate(Card c) {
				if(!c.IsVanguard())
				{
					FromFieldToDeck(c);
				}
			});

			SetBool(1);
			GetDeck().ViewDeck(5, SearchMode.TOP_CARD_WITH_REORDER_BOTTOM, min(5, GetDeck().Size()), delegate(Game2DCard c) {
				return c._CardInfo.name.Contains("Liberator");
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck (_AuxIdVector);
		},
		delegate {
			EndEffect();
		});

		CallFromDeckUpdate(delegate {
			bCanUseAct1 = false;
			EndEffect();
		});
	}

	public override void Cont ()
	{
		if(IsPlayerTurn()
		   && VC())
		{
			AddContPower(1000 * NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }));
		}
	}
}
