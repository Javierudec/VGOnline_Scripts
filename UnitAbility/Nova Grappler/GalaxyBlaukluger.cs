using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (2) & Choose two «Nova Grappler» from your 
 * hand, and discard them] When an attack by your vanguard or rear-guard with 
 * "Blau" in its card name hits a vanguard, you may pay the cost. If you do, 
 * [Stand] all of your units in the same column as this unit. This ability cannot 
 * be used for the rest of that turn. (This ability cannot be used even if the cost 
 * is not paid.)
 * 
 * [CONT](VC):If you have a card named "Stern Blaukluger" in your soul, this 
 * unit gets [Power]+2000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class GalaxyBlaukluger : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsInSoul(CardIdentifier.STERN_BLAUKLUGER))
		{
			power += 2000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe || cs == CardState.AttackHits)
		{
			if(!GetBool(1) && VC() && LimitBreak(4) && CB (2) && HandSize(delegate(Card c) { return c.BelongsToClan("Nova Grappler"); }) >= 2)
			{
				if(GetDefensor().IsVanguard() && ownerEffect.name.Contains("Blau"))
				{
					SetBool(1);
					DisplayConfirmationWindow();
				}
			}
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);	
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectInHand(2, true,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.BelongsToClan("Nova Grappler");
				},
				delegate {
					StandUnit(OwnerCard);
					Card tmp = GetSameColum(OwnerCard.pos);
					if(tmp != null)
					{
						StandUnit(tmp);	
					}
				}, "Choose two \"Nova Grappler\" from your hand.");
			});
		});
	}
	
	public override void Pointer()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
	}
}
