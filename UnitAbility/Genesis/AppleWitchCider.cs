using UnityEngine;
using System.Collections;

/*
 * [AUTO]: When this unit is placed on (GC) from your hand, choose your 
 * vanguard with "Regalia" in its card name, and until end of that battle, that unit 
 * gets "[AUTO](VC):When one of your «Genesis» guardian is put into the 
 * drop zone, put that card into your soul.".
 */

public class AppleWitchCider : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.UsedToGuard)
		{
			if(GetVanguard().name.Contains("Regalia"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			//SelectAnimField(GetVanguard());
			GetVanguard().unitAbilities.AddUnitObject(new AppleWithCiderExternEffect(), true);
			EndEffect();
		});
	}
}

public class AppleWithCiderExternEffect : UnitObject {
	Card tmp = null;
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropZoneFromGC_NotMe)
		{
			if(VC() && ownerEffect.BelongsToClan("Genesis"))
			{
				tmp = ownerEffect;
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(tmp != null) Game.GameChat.AddChatMessage("ADMIN", tmp.name);
			else Game.GameChat.AddChatMessage("ADMIN", "null");
			
			SoulChargeFromDrop(tmp);
			EndEffect();
		});
	}
}
