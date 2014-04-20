using UnityEngine;
using System.Collections;

public class SunlightGoddessYatagarasu : UnitObject {
	Card cardToReturn = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && CanSoulBlast(9)
			   && GetVanguard().IsVanguard()
			   && GetDeck().Size() >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.DropZoneFromGC_NotMe)
		{
			if(VC ()
			   && GetDefensor() == OwnerCard
			   && ownerEffect.BelongsToClan("Genesis")
			   && !GetBool(2))
			{
				cardToReturn = ownerEffect;
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndGuard)
		{
			UnsetBool(2);
		}
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SetBool(2);
				SoulChargeFromDrop(cardToReturn);
				EndEffect();
			}
			else
			{
				SoulBlast(9);
			}
		});

		SoulBlastUpdate(delegate {
			DrawCard(2);
		});

		DrawCardUpdate(delegate {
			int num = min(2, NumUnits (delegate(Card c) { return c.BelongsToClan("Genesis") && !c.IsStand(); }));
			SelectUnit ("Choose two of your \"Genesis\" rear-guards.", num, true,
			delegate {
				StandUnit(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Genesis") && !Unit.IsStand();
			},
			delegate {

			});
		});
	}
}
