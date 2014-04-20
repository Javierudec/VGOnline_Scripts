using UnityEngine;
using System.Collections;

public class DeadlySwordmaster : UnitObject {
	public override void Cont()
	{
		if(NumUnits(delegate(Card c) { return !c.BelongsToClan("Granblue"); }, true) > 0)
		{
			AddContPower(-2000);	
		}
	}
	
	public override int EffectOnDrop()
	{
		if(NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.DEADLY_NIGHTMARE; }) > 0
		   && NumUnits(delegate(Card c) { return c.cardID == CardIdentifier.DEADLY_SPIRIT; }) > 0
		   && GetVanguard().grade >= 2
		   && VanguardIs("Granblue"))
		{
			return 1;	
		}
		
		return 0;	
	}
	
	public override void Active()
	{
		StartEffect();
		ShowAndDelay();	
		Game.field.CloseDeck();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose a card named \"Deadly Spirit\" from your field.",
			           1,
			           false,
			           delegate {
				RetireUnit(Unit);
			}, 
			delegate {
				return Unit.cardID == CardIdentifier.DEADLY_SPIRIT;
			},
			delegate {
				SelectUnit("Choose a card named \"Deadly Nightmare\" from your field.",
				           1,
				           false,
				           delegate {
					RetireUnit(Unit);
				}, 
				delegate {
					return Unit.cardID == CardIdentifier.DEADLY_NIGHTMARE;
				},
				delegate {
					RideFromDropZone(OwnerCard);
					EndEffect();
				});
			});
		});
	}
}
