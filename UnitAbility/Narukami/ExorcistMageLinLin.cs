using UnityEngine;
using System.Collections;

/*
 * [AUTO]:When this unit is placed on (VC) or (RC), choose 
 * a [CONT] of one of your «Narukami» vanguard or rear-
 * guards, and that ability is lost until end of turn.
 */

public class ExorcistMageLinLin : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			ConfirmAttack();	
		}
		else if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(NumUnits(delegate(Card c) { return c.BelongsToClan("Narukami") && c.GetContSkillNumber() > 0; }, true) > 0)
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}
	
	public override void SelectionWindowOnClose(Card unitAffected, string optionSelected)
	{
		RemoveCONTAbility(unitAffected, optionSelected);
		EndEffect();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your Narukami rear-guards", 1, false,
			delegate {
				SelectAnimField(Unit);
				OpenSelectionList(Unit, Unit.GetContSkillsNames(), "Choose one [CONT] ability.");
			},
			delegate {
				return Unit.BelongsToClan("Narukami") && Unit.GetContSkillNumber() > 0;
			},
			delegate {
				
			}, true);
		});
	}
	
	public override void Pointer ()
	{
		SelectUnit_Pointer();
	}
}
