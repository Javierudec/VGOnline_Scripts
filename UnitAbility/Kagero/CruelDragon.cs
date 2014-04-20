using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or more 
 * damage):[Counter Blast (1) & Soul Blast (1)] When this unit attacks a 
 * vanguard, you may pay the cost. If you do, choose one of your opponent's 
 * grade 2 or less rear-guards, and retire it.
 * 
 * [ACT](Hand):[Reveal this card & Choose your grade 2 or greater «Kagerō» 
 * vanguard, and [Rest] it] If you put an opponent's rear-guard into the drop 
 * zone during the main phase of that turn, ride this unit as [Stand], and choose 
 * your vanguard, and that unit gets [Power]-3000 until end of turn.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, 
 * this unit cannot attack)
 */

public class CruelDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC() && LimitBreak(4) && CB (1) && CanSoulBlast(1) && NumUnits(delegate(Card c) { return c.grade <= 2; }) > 0)
			{
				SetBool(1);
				DisplayConfirmationWindow();	
			}
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(2);	
		}
	}
	
	public override void AutoHand(CardState cs)
	{
		if(cs == CardState.Hand_EnemyToDropFromRG)
		{
			if(GetBool(2) && CurrentPhaseIs(GamePhase.MAIN_PHASE))
			{
				StartEffect();
				ShowAndDelay();
				SetBool(3);
			}
		}		
	}
	
	public override void Active ()
	{
		if(GetBool(1))
		{
			ShowAndDelay();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}
	
	public override bool EffectOnHand ()
	{	
		return GetVanguard().grade >= 2 && VanguardIs("Kagero") && GetVanguard().IsStand();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				CounterBlast(1,
				delegate {
					SoulBlast(1);	
				});
			}
			else if(GetBool(3))
			{
				UnsetBool(3);
				RideFromHand(OwnerCard);
				IncreasePowerByTurn(GetVanguard(), -3000);
				EndEffect();
			}
			else
			{
				ShowCardInHand(OwnerCard, GetHand().GetIndexOf(OwnerCard));
				RestUnit(GetVanguard());
				EndEffect();
				SetBool(2);
			}
		});
		
		SoulBlastUpdate(delegate {
			UnsetBool(1);
			SelectEnemyUnit("Choose one of your opponent's grade 2 or less rear-guards.", 1, true,
			delegate {
				RetireEnemyUnit(EnemyUnit);
			},
			delegate {
				return EnemyUnit.grade <= 2;
			},
			delegate {
			
			});
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectEnemyUnit_Pointer();
	}
}
