using UnityEngine;
using System.Collections;

public class GoddessOfTheSunAmaterasu : UnitObject {
	public override void Cont()
	{
		if(VC () 
		   && IsInSoul(CardIdentifier.CEO_AMATERASU))
		{
			AddContPower(2000);	
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.AttackHits)
		{
			if(GetDefensor ().IsVanguard()
			   && LimitBreak(4) 
			   && CB (2) 
			   && VC ())
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
			CounterBlast(2,
			             delegate {
				SetBool(1);
				Game.playerDeck.ViewDeck(1, delegate(Game2DCard c) {
					return c._CardInfo.clan == "Oracle Think Tank";	
				});
			});
		});
		
		if(GetBool (1) && !Game.playerDeck.IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = Game.playerDeck.GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);
				ShuffleDeck();
			}
			
			EndEffect();
		}
	}
}
