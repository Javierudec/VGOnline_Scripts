using UnityEngine;
using System.Collections;

public class SuperIdolRiviere : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() && Game.field.GetSoulByID(CardIdentifier.SUPER_IDOL__RIVIERE) != null)
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.MERMAID_IDOL__RIVIERE)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
