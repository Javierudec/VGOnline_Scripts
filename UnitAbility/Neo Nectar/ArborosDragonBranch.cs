using UnityEngine;
using System.Collections;

public class ArborosDragonBranch : UnitObject {
	public override void Cont()
	{
		if(VC() 
		   && IsInSoul(CardIdentifier.ARBOROS_DRAGON__RATOON))
		{
			AddContPower(1000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(GetVanguard().cardID == CardIdentifier.ARBOROS_DRAGON__TIMBER 
			   && IsInSoul(CardIdentifier.ARBOROS_DRAGON__RATOON))
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
				Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) { return c._CardInfo.cardID == Unit.cardID; });
				SetBool(1);
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
