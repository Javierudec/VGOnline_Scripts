using UnityEngine;
using System.Collections;

public class MermaidIdolRiviere : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() && Game.field.GetSoulByID(CardIdentifier.BERMUDA_TRIANGLE_CADET__RIVIERE) != null)
		{
			AddContPower(1000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(Game.field.GetSoulByID(CardIdentifier.BERMUDA_TRIANGLE_CADET__RIVIERE) != null && GetVanguard().cardID == CardIdentifier.SUPER_IDOL__RIVIERE)
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
