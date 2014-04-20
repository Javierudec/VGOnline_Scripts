using UnityEngine;
using System.Collections;

public class HeavenlyInjector : UnitObject {
	public override void Cont()
	{
		if(VC() && IsInSoul(CardIdentifier.MIRACLE_FEATHER_NURSE))
		{
			AddContPower(1000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.FATE_HEALER__ERGODIEL)
			{
				if(IsInSoul(CardIdentifier.MIRACLE_FEATHER_NURSE))
				{
					if(HandSize(delegate(Card c) { return c.BelongsToClan("Angel Feather"); }) > 0)
					{
						DisplayConfirmationWindow();	
					}
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
			SelectInHand(1, false, 
			delegate {
				FromHandToDamage(_SIH_Card);
			},
			delegate {
				return _SIH_Card.clan == "Angel Feather";
			},
			delegate {
				SelectInDamage(1, true,
				delegate {
					FromDamageToHand(_SID_Card);
				});
			}, "Choose an Angel Feather from your hand.");
		});
	}
}
