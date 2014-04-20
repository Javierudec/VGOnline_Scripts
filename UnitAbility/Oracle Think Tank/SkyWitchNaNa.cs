using UnityEngine;
using System.Collections;

public class SkyWitchNaNa : UnitObject {
	public override void Cont()
	{
		if(IsPlayerTurn())
		{
			if(VC ())
			{
				if(Game.field.GetNumberOfCardsInSoul() <= 0)
				{
					AddContPower(3000);	
				}
			}
			else
			{
				if(Game.field.GetNumberOfCardsInSoul() <= 0)
				{
					AddContPower(1000);	
				}				
			}	
		}
	}
}
