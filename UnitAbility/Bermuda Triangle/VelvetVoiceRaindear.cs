using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC):[Choose one of your «Bermuda Triangle» rear-guards, and 
 * return it to your hand] When this unit's drive check reveals a grade
 * 3 «Bermuda Triangle», you may pay the cost. If you do, choose up to
 * one «Bermuda Triangle» from your hand, and call it to an open (RC).
 */

public class VelvetVoiceRaindear : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(Game.DriveCard.BelongsToClan("Bermuda Triangle")
			   && Game.DriveCard.grade == 3
			   && NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Active ()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Bermuda Triangle\" rear-guards.", 1, false,
			delegate {
				ReturnToHand(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Bermuda Triangle");
			},
			delegate {
				SelectInHand(1, false,
				delegate {
					OnlyOpenRC(true);
					CallFromHand(_SIH_Card);
				},
				delegate {
					return _SIH_Card.BelongsToClan("Bermuda Triangle");
				},
				delegate {

				}, "Choose a \"Bermuda Triangle\" from your hand.");
			});
		});

		CallFromHandUpdate(delegate {
			OnlyOpenRC(false);
			EndEffect();
		});
	}

	public override void Pointer()
	{
		SelectUnit_Pointer();
		SelectInHand_Pointer(true,
		delegate {
			EndEffect();
		});
	}
}
