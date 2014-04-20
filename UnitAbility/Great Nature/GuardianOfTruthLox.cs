using UnityEngine;
using System.Collections;

public class GuardianOfTruthLox : UnitObject {
	public override void Cont()
	{
		if(VC () && IsInSoul(CardIdentifier.LAW_OFFICIAL__LOX))
		{
			AddContPower(1000);
		}
	}
	
	public override int Act()
	{
		if(VC () 
		   && CB(2) 
		   && HandSize(delegate(Card c) { return c.cardID == CardIdentifier.GUARDIAN_OF_TRUTH__LOX; }) > 0
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Great Nature"); }) > 0)
		{
			return 1;
		}
		
		return 0;	
	}
	
	public override void Active()
	{
		StartEffect();
		ShowAndDelay();	
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SelectInHand(1, false,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.cardID == CardIdentifier.GUARDIAN_OF_TRUTH__LOX;
			},
			delegate {
				SelectUnit("Choose one of your Great Nature rear-guards.", 1, true,
				           delegate {
					IncreasePowerAndCriticalByTurn(Unit, 4000, 1);	
					Unit.unitAbilities.AddExternAuto(delegate(CardState s, Card effectOwner) {
						if(s == CardState.EndTurn)
						{
							Unit.unitAbilities.RetireUnit(Unit);
						}
					});
				},
				delegate {
					return Unit.clan == "Great Nature";	
				},
				delegate {
					
				});	
			}, "Choose a card named \"Guardian of Truth, Lox\".");
		});
	}
}
