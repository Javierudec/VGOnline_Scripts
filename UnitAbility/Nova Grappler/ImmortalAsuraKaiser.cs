using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):When this unit's drive check reveals a grade 3 «Nova Grappler», 
 * until end of that battle, this unit gets "[AUTO](VC):[Counter Blast (2) & 
 * Choose two «Nova Grappler» from your hand, and discard them] At the end 
 * of the battle that this unit attacked a vanguard, you may pay the cost. If you 
 * do, choose both one of your rear-guards and vanguard, [Stand] them, and 
 * this unit gets [Power]+10000 until end of turn.". This ability cannot be used for 
 * the rest of that turn.
 * 
 * [CONT](VC):If you have a card named "Asura Kaiser" in your soul, this unit 
 * gets [Power]+2000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class ImmortalAsuraKaiser : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC () && IsInSoul(CardIdentifier.ASURA_KAISER))
		{
			power += 2000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DriveCheck)
		{
			if(VC () && LimitBreak(4) && ownerEffect.BelongsToClan("Nova Grappler") && ownerEffect.grade == 3 && GetDefensor().IsVanguard() && !GetBool(2))
			{
				SetBool(1);	
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1) && CB (2) && VC () && HandSize(delegate(Card c) { return c.BelongsToClan("Nova Grappler"); }) >= 2)
			{
				DisplayConfirmationWindow();	
			}
			
			UnsetBool(1);
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(2);	
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
				SelectInHand(2, false, 
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.BelongsToClan("Nova Grappler");
				},
				delegate {
					if(NumUnits(delegate(Card c) { return !c.IsStand(); }) > 0)
					{
						SelectUnit("Choose one of your rear-guards.", 1, true,
						delegate {
							StandUnit(Unit);
						},
						delegate {
							return true;
						},
						delegate {
							StandUnit(GetVanguard());
							IncreasePowerByTurn(GetVanguard(), 10000);
							SetBool(2);
						});
					}
					else
					{
						StandUnit(GetVanguard());
						IncreasePowerByTurn(GetVanguard(), 10000);
						SetBool(2);
						EndEffect();
					}
				}, "Choose two \"Nova Grappler\" from your hand.");
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectInHand_Pointer();
		SelectUnit_Pointer();
	}
}
