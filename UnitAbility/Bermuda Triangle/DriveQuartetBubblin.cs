using UnityEngine;
using System.Collections;

public class DriveQuartetBubblin : UnitObject {
	public override void Cont()
	{
		if(!OwnerCard.IsVanguard() && 
		   Game.field.GetRearCardByID(CardIdentifier.DRIVE_QUARTET__RESSAC) != null)
		{
			AddContPower(3000);	
		}
	}
}
