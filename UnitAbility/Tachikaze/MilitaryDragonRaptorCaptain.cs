using UnityEngine;
using System.Collections;

public class MilitaryDragonRaptorCaptain : UnitObject {
	public override void Cont()
	{	
		if(VC() 
		   && IsInSoul(CardIdentifier.MILITARY_DRAGON__RAPTOR_SERGEANT))
		{
			AddContPower(1000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.MILITARY_DRAGON__RAPTOR_COLONEL && IsInSoul(CardIdentifier.MILITARY_DRAGON__RAPTOR_SERGEANT))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SetBool(1);
			Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) { return c._CardInfo.cardID == CardIdentifier.MILITARY_DRAGON__RAPTOR_CAPTAIN; });
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					CallFromDeck(_AuxIdVector);
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();	
		});
	}
}
