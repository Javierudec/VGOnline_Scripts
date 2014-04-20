using UnityEngine;
using System.Collections;

public class DriveQuartetRessac : UnitObject {
	public override void Cont()
	{
		if(!OwnerCard.IsVanguard() &&
		   Game.field.GetRearCardByID(CardIdentifier.DRIVE_QUARTET__FLOWS) != null)
		{
			AddContPower(3000);	
		}
	}
}
