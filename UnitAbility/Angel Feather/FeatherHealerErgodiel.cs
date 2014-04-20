using UnityEngine;
using System.Collections;

public class FeatherHealerErgodiel : UnitObject {
	public override void Cont()
	{
		if(VC () && IsInSoul(CardIdentifier.HEAVENLY_INJECTOR))
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(HandSize(delegate(Card c) { return c.BelongsToClan("Angel Feather"); }) >= 2 
			   && GetVanguard().cardID == CardIdentifier.COSMO_HEALER__ERGODIEL &&
			   IsInSoul(CardIdentifier.HEAVENLY_INJECTOR))
			{
				DisplayConfirmationWindow();	
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
			SelectInHand(2, 
			             false,
			             delegate {
				FromHandToDamage(_SIH_Card);
			},
			delegate {
				return _SIH_Card.clan == "Angel Feather";
			},
			delegate {
				SelectInDamage(2,
				               true,
				               delegate {
					FromDamageToHand(_SID_Card);
				});
			},
			"Choose two Angel Feather from your hand.");
		});
	}
}
