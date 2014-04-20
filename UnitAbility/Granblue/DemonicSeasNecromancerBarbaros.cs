using UnityEngine;
using System.Collections;

public class DemonicSeasNecromancerBarbaros : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC()
			   && NumUnits(delegate(Card c) { return c.grade >= 3 && c.BelongsToClan("Granblue"); }) > 0
			   && Game.DriveCard.grade == 3 
			   && Game.DriveCard.BelongsToClan("Granblue"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your grade 3 or greater \"Granblue\" rear-guards.", 1, false,
			delegate {
				RetireUnit(Unit);
			},
			delegate {
				return Unit.grade >= 3 && Unit.BelongsToClan("Granblue");
			},
			delegate {
				SetBool(1);
				Game.field.ViewDropZone(1, delegate(Card c) {
					return c.BelongsToClan("Granblue");
				});
			});
		});

		ResolveDropOpening(1,
		delegate {
			OnlyOpenRC(true);
			CallFromDrop(Game.field.GetDropByID(_AuxIdVector[0]));
		},
		delegate {
			EndEffect();
		});

		CallFromDropUpdate(delegate {
			EndEffect();
		});
	}

	public override void Cont ()
	{
		if(IsPlayerTurn()
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Granblue"); }) >= 4)
		{
			AddContPower(3000);
		}
	}
}
