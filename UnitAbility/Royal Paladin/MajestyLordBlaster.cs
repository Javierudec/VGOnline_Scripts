using UnityEngine;
using System.Collections;

public class MajestyLordBlaster : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.BLASTER_BLADE)
		   && IsInSoul(CardIdentifier.BLASTER_DARK))
		{
			AddContPower(2000);
			AddContCritical(1);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC()
			   && NumUnits (delegate(Card c) { return c.cardID == CardIdentifier.BLASTER_BLADE; }) > 0
			   && NumUnits (delegate(Card c) { return c.cardID == CardIdentifier.BLASTER_DARK; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose a unit named \"Blaster Blade\".", 1, false,
			delegate {
				MoveToSoul(Unit);
			},
			delegate {
				return Unit.cardID == CardIdentifier.BLASTER_BLADE;
			},
			delegate {
				SelectUnit ("Choose a unit named \"Blaster Dark\".", 1, true,
				delegate {
					MoveToSoul(Unit);
				},
				delegate {
					return Unit.cardID == CardIdentifier.BLASTER_DARK;
				},
				delegate {
					IncreasePowerByBattle(OwnerCard, 10000);
				});
			});
		});
	}
}
