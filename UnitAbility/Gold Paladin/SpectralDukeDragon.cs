using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (2) & Choose three of your «Gold 
 * Paladin» rear-guards, and retire them] At the beginning of the close 
 * step of the battle that this unit attacked a vanguard, you may pay the 
 * cost. If you do, [Stand] this unit, and this unit loses "Twin Drive!!" until end of turn.
 * 
 * [CONT](VC):If you have a card named "Black Dragon Knight, 
 * Vortimer" in your soul, this unit gets [Power]+1000.
 */

public class SpectralDukeDragon : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(VC() && IsInSoul(CardIdentifier.BLACK_DRAGON_KNIGHT__VORTIMER))
		{
			power += 1000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard())
			{
				SetBool(1);	
			}
			
			ConfirmAttack();	
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				if(VC () && LimitBreak(4) && CB (2) && NumUnits(delegate(Card c) { return c.BelongsToClan("Gold Paladin"); }) >= 3)
				{
					DisplayConfirmationWindow();	
				}
			}
		}
		else if(cs == CardState.EndTurn)
		{
			OwnerCard.bDisableTwinDrive = false;	
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
				SelectUnit("Choose three of your \"Gold Paladin\" rear-guards.", 3, true,
				delegate {
					RetireUnit(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Gold Paladin");
				},
				delegate {
					StandUnit(OwnerCard);
					OwnerCard.bDisableTwinDrive = true;
				});
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer();
	}
}
