using UnityEngine;
using System.Collections;

public class StealthBeastTamahagane : UnitObject {
	Card unitBound = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(VanguardIs("Nubatama")
			   && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			if(unitBound != null && unitBound._Coord == CardCoord.BIND)
			{
				OpponentFromBindToHand(unitBound);
				unitBound = null;
			}

			RemoveFromHelpZone(OwnerCard);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
			delegate {
				BindEnemyUnit(EnemyUnit);
				AddToHelpZone(OwnerCard);
			},
			delegate {
				return true;
			},
			delegate {

			});
		});
	}
}
