using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (3) & Soul Blast (3) & Choose a card named 
 * "Transcendence Dragon, Dragonic Nouvelle Vague" from your hand, and 
 * discard it] Retire all of your opponent's rear-guards.
 * 
 * [CONT](VC):During your turn, the effects of your opponent's triggers are 
 * negated.
 * 
 * [CONT](VC):During a battle that this unit attacks a vanguard, your opponent 
 * cannot normal call grade 0 units to (GC) from his or her hand.
 * 
 * [CONT](RC):This unit gets [Power]-1000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class TranscendenceDragonDragonicNouvelleVague : UnitObject {
	bool bTriggerBlock = false;
	
	public override void Cont ()
	{
		bTriggerBlock = (IsPlayerTurn() && VC ());
		
		int power = 0;		
		if(RC())
		{
			power -= 1000;
		}
		SetPower(power);
		
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking_NotMe)
		{
			if(bTriggerBlock)
			{
				BlockEnemyTriggerEffects();	
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(bTriggerBlock)
			{
				BlockEnemyTriggerEffects();	
			}
			
			if(VC() && GetDefensor().IsVanguard())
			{
				BlockEnemyGuard(0);
			}
		}
	}
	
	public override int Act ()
	{
		if(VC () && LimitBreak(4) && CB (1) && CanSoulBlast(3) && IsInHand(CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE))
		{
			return 1;	
		}
		
		return 0;
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				SoulBlast(3);
			});
		});
		
		SoulBlastUpdate(delegate {
			SelectInHand(1, true,
			delegate {
				DiscardSelectedCard();
			},
			delegate {
				return _SIH_Card.cardID == CardIdentifier.TRANSCENDENCE_DRAGON__DRAGONIC_NOUVELLE_VAGUE;
			},
			delegate {
				ForEachEnemyUnitOnField(delegate(Card c) {
					if(!c.IsVanguard())
					{
						RetireEnemyUnit(c);
					}
				});
			}, "Choose a card named \"Transcendence Dragon, Dragonic Nouvelle Vague\" from your hand.");
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
	}
}
