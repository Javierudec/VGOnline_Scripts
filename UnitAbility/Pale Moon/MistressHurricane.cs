using UnityEngine;
using System.Collections;

public class MistressHurricane : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetUnitsSoulWithClanName("Pale Moon") >= 8)
		{
			AddContPower(1000);	
		}
	}	
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Ride)
		{
			if(CB(2) &&
			   Game.field.GetUnitsSoulWithClanName("Pale Moon") > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}
	
	public override void Active()
	{
		FlipCardInDamageZone(2);
		ShowAndDelay();	
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			Game.field.ViewSoul("Pale Moon");
			SetBool(1);
		});
		
		if(GetBool(1))
		{
			if(!Game.field.ViewingSoul())
			{
				UnsetBool(1);
				CallFromSoul (Game.field.GetSoulByID(Game.field.GetLastSelectedList()[0]));
			}
		}
		
		CallFromSoulUpdate(delegate {
			EndEffect();	
		});
	}
}
