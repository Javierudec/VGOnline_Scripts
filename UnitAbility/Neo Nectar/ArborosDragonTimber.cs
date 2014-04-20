using UnityEngine;
using System.Collections;

public class ArborosDragonTimber : UnitObject {
	public override void Cont()
	{
		if(VC() 
		   && IsInSoul(CardIdentifier.ARBOROS_DRAGON__BRANCH))
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.ARBOROS_DRAGON__SEPHIROT && IsInSoul(CardIdentifier.ARBOROS_DRAGON__BRANCH))
			{
				if(NumUnits(delegate(Card c) { return c.BelongsToClan("Neo Nectar"); }) > 0)
				{
					StartEffect();
					ShowAndDelay();
				}
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Neo Nectar rear-guards.", 1, false, 
			delegate {
				SelectAnimField(Unit);
				SetBool(1);
				Game.playerDeck.ViewDeck(1, delegate(Card c) { return c.cardID == Unit.cardID; });
			},
			delegate {
				return Unit.clan == "Neo Nectar";
			},
			delegate {
				
			});
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
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
