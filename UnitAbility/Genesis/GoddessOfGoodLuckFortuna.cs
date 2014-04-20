using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Soul Blast (3)] When this unit's drive check reveals a grade 1 
 * or greater «Genesis», you may pay the cost. If you do, put the card revealed 
 * with that drive check into your drop zone, and perform an additional drive check.
 * 
 * [ACT](VC):[Soul Blast (3)] This unit gets [Power]+5000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)
 */

public class GoddessOfGoodLuckFortuna : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC()
			   && CanSoulBlast(3)
			   && Game.DriveCard.BelongsToClan("Genesis")
			   && Game.DriveCard.grade >= 1)
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

	public override int Act ()
	{
		if(VC ()
		   && CanSoulBlast(3))
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		if(!GetBool (1))
		{
			StartEffect();
		}

		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(3);
		});

		SoulBlastUpdate(delegate {
			if(!GetBool(1))
			{
				IncreasePowerByTurn(OwnerCard, 5000);
			}
			else
			{
				UnsetBool(1);
				FromDriveToDrop(Game.DriveCard);
				PerformAdditionalDriveCheck();
			}
			EndEffect();
		});
	}
}
