using UnityEngine;
using System.Collections;

/*
 * [AUTO]:[Counter Blast(1) & Choose a card named "Transcendence Dragon, 
 * Dragonic Nouvelle Vague" from your hand, and reveal it] When this unit is 
 * placed on (VC) or (RC), if you have a «Kagero» vanguard, you may pay the 
 * cost. If you do, choose one of your opponent's rear-guards, and retire it.
 */

public class NouvellecriticDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Ride || cs == CardState.Call)
		{
			if(VanguardIs("Kagero") && CB (1) && IsInHand(CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE) && NumEnemyUnits(delegate(Card c) { return true; }) > 0)
			{
				DisplayConfirmationWindow();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectInHand(1, false,
				delegate {
					ShowCardInHand(_SIH_Card);
				},
				delegate {
					return _SIH_Card.cardID == CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE;
				},
				delegate {
					SelectEnemyUnit("Choose one of your opponent's rear-guards", 1, true,
					delegate {
						RetireEnemyUnit(EnemyUnit);
					},
					delegate {
						return true;
					},
					delegate {
						
					});
				}, "Choose a card named \"Transcendence Dragon, Dragonic Nouvelle Vague\" from your hand.");
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
		SelectEnemyUnit_Pointer();
	}
}
