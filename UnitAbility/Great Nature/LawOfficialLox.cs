using UnityEngine;
using System.Collections;

public class LawOfficialLox : UnitObject {
	public override void Cont()
	{
		if(VC () && IsInSoul(CardIdentifier.BRINGER_OF_KNOWLEDGE__LOX))
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.GUARDIAN_OF_TRUTH__LOX &&
			   IsInSoul(CardIdentifier.BRINGER_OF_KNOWLEDGE__LOX) &&
			   NumUnits(delegate(Card c) { return c.BelongsToClan("Great Nature"); }) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose up to two Great Nature rear-guards.", min (2, NumUnits(delegate(Card c) { return c.BelongsToClan("Great Nature"); })), true,
			delegate { 
				SelectAnimField(Unit);
				Unit.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
					if(s == CardState.DropZoneFromRC)
					{
						if(CurrentPhaseIs(GamePhase.ENDTURN))
						{
							DrawCardWithoutDelay();	
						}
					}
				});
			}, delegate { return Unit.clan == "Great Nature"; }, delegate { });
			
		});
	}
}
