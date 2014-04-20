using UnityEngine;
using System.Collections;

/*
 * [ACT](VC) Limit Break 4 (This ability is active if you have four or more damage):
 * [Counter Blast (1)] Bind all of your opponent's rear-guards, and at the beginning of the end phase of that turn,
 * your opponent chooses up to four face up cards that were bound with this effect from his or her bind zone, 
 * calls them to separate (RC), and puts all other cards that were bound with this effect into the drop zone.
 * 
 * [AUTO](VC):When this unit attacks, if the number of rear-guards your opponent has is two or less, 
 * this unit gets [Power]+3000 until end of that battle.
 */

public class DragonicLawkeeper : UnitObject {
	public override int Act ()
	{
		if(VC() && LimitBreak(4) && CB (1))
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
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC () && NumEnemyUnits(delegate(Card c) {
				return true;
			}) <= 2) 
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			if(GetSavedCardsList() != null && GetSavedCardsList().Count > 0)
			{
				StartEffect();
				ShowAndDelay();
				SetBool(1);
			}
		}
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				ForceOpponentToCallFromBind(4, GetSavedCardsList());
				RemoveFromHelpZone(OwnerCard);
			}
			else
			{
				CounterBlast(1,
				delegate {
					CreateSaveCardStore();
					ForEachEnemyUnitOnField(delegate(Card c) {
						if(!c.IsVanguard())
						{
							BindEnemyUnit(c);
							SaveCard(c);
						}
					});
					AddToHelpZone(OwnerCard);
					EndEffect();
				});
			}
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
	}
}
