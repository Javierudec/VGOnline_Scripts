using UnityEngine;
using System.Collections;

public class OmniscienceRegaliaMinerva : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.REGALIA_OF_WISDOM__ANGELICA))
		{
			AddContPower(2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndBattle)
		{
			if(VC ()
			   && LimitBreak(4)
			   && CB(1)
			   && CanSoulBlast(3)
			   && HandSize(delegate(Card c) { return c.BelongsToClan("Genesis"); }) >= 3
			   && !GetBool(1))
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SoulBlast(3);
			});
		});

		SoulBlastUpdate(delegate {
			SelectInHand(3, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.BelongsToClan("Genesis");
			},
			delegate {
				StandUnit(OwnerCard);
				IncreasePowerByTurn(OwnerCard, 5000);
				SetBool(1);
			}, "Choose three \"Genesis\" from your hand.");
		});
	}
}
