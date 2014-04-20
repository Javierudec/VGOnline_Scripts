using UnityEngine;
using System.Collections;

public class SolarMaidenUzume : UnitObject {
	public override int Act ()
	{
		if(RC () && CB (1) && NumUnits(delegate(Card c) {
			return c.BelongsToClan("Oracle Think Tank");
		}) >= 2)
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit("Choose two of your \"Oracle Think Tank\" rear-guards.", 2, false,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Oracle Think Tank");
				},
				delegate {
					SetBool(1);
					GetDeck().ViewDeck(1, delegate(Card c) {
						return c.cardID == CardIdentifier.GODDESS_OF_THE_SUN__AMATERASU;	
					});
				});
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				FromDeckToHand(_AuxIdVector[0]);	
			}
			EndEffect();
		}
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
}
