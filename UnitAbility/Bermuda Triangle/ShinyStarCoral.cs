using UnityEngine;
using System.Collections;

/*
 * [CONT](VC): If you have a card named "Fresh Star, Coral" in your 
 * soul, this unit gets [Power]+1000.
 * 
 * [AUTO](VC): When this unit's attack hits a vanguard, choose up to one 
 * of your «Bermuda Triangle» rear-guards in the front row, return it to 
 * your hand, and if you have a card named "Fresh Star, Coral" in your 
 * soul, choose up to one of your «Bermuda Triangle» rear-guards in the 
 * back row, and return it to your hand.
 */

public class ShinyStarCoral : UnitObject {
	int numFront, numBack;
	
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsInSoul(CardIdentifier.FRESH_STAR__CORAL))
		{
			power += 1000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			numFront = NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle") && IsInFrontRow(c); });
			numBack = NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle") && IsInBackRow(c); });
			
			if(numFront > 0 && (numBack == 0 || !IsInSoul(CardIdentifier.FRESH_STAR__CORAL)))
			{
				SelectUnit("Choose one of your \"Bermuda Triangle\" in the front row.", 1, true,
				delegate {
					ReturnToHand(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Bermuda Triangle") && IsInFrontRow(Unit);
				},
				delegate {
					
				});
			}
			
			if(numFront == 0 && numBack > 0 && IsInSoul(CardIdentifier.FRESH_STAR__CORAL))
			{
				SelectUnit("Choose one of your \"Bermuda Triangle\" in the back row.", 1, true,
				delegate {
					ReturnToHand(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Bermuda Triangle") && IsInBackRow(Unit);
				},
				delegate {
					
				});				
			}
			
			if(numFront == 0 && numBack == 0)
			{
				EndEffect();	
			}
			
			if(numFront > 0 && numBack > 0)
			{
				SelectUnit("Choose one of your \"Bermuda Triangle\" in the front row.", 1, false,
				delegate {
					ReturnToHand(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Bermuda Triangle") && IsInFrontRow(Unit);
				},
				delegate {
					SelectUnit("Choose one of your \"Bermuda Triangle\" in the back row.", 1, true,
					delegate {
						ReturnToHand(Unit);
					},
					delegate {
						return Unit.BelongsToClan("Bermuda Triangle") && IsInBackRow(Unit);
					},
					delegate {
						
					});						
				});				
			}
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer(true);
	}
}
