using UnityEngine;
using System.Collections;

public class BladeWingReijy : UnitObject {
	public override void Cont()
	{
		if(VC () && Game.field.GetNumberOfCardsInSoul() >= 15)
		{
			AddContCritical(2);
		}	
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{
		if(cs == CardState.Ride)
		{
			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Dark Irregulars"); }) > 0)
			{	
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Dark Irregulars rear-guard.", 1, false,
			delegate {  
				SelectAnimField(Unit);
				int n = min (3, Game.playerDeck.Count(delegate(Card c){return c.cardID == Unit.cardID;}));
				if(n > 0)
				{
					SetBool(1);
					Game.playerDeck.ViewDeck(n, delegate(Card c) { return c.cardID == Unit.cardID; });
				}
				else
				{
					EndEffect();
				}			   
			}, delegate { return Unit.clan == "Dark Irregulars"; }, delegate { });
		});
		
		if(GetBool(1))
		{
			if(!Game.playerDeck.IsOpen())
			{
				UnsetBool(1);
				_AuxIdVector = Game.playerDeck.GetLastSelectedList();
				if(_AuxIdVector.Count > 0)
				{
					SoulCharge(_AuxIdVector);
				}
				else
				{
					EndEffect();	
				}
			}
		}
		
		SoulChargeUpdate(delegate {
			EndEffect();	
		});
	}
}
