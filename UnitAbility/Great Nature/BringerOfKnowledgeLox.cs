using UnityEngine;
using System.Collections;

public class BringerOfKnowledgeLox : UnitObject {
	public override void Cont()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.SCHOOLYARD_PRODIGY__LOX))
		{
			AddContPower(1000);
		}	
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.LAW_OFFICIAL__LOX)
			{
				if(IsInSoul(CardIdentifier.SCHOOLYARD_PRODIGY__LOX) && NumUnits(delegate(Card c) { return c.BelongsToClan("Great Nature"); }) > 0)
				{	
					DisplayConfirmationWindow();
				}
			}
		}
	}
	
	public override void Active()
	{
		ShowAndDelay();	
	}
	
	public override void Update()
	{	
		DelayUpdate(delegate {
			int n = min(2, NumUnits(delegate(Card c) { return c.BelongsToClan("Great Nature"); }));
			SelectUnit("Choose up to two of your Great Nature rear-guars.", n, true,
			delegate {
				SelectAnimField(Unit);
				Unit.unitAbilities.AddExternAuto(delegate(CardState cs, Card effectOwner)
				                                 {
					if(cs == CardState.DropZoneFromRC)
					{
						if(CurrentPhaseIs(GamePhase.ENDTURN))
						{
							DrawCardWithoutDelay();
						}
					}
				});
			},
			delegate {
				return Unit.clan == "Great Nature";
			},
			delegate {
				
			});
		});
	}
}
