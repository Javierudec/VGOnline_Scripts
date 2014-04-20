using UnityEngine;
using System.Collections;

/*
 * [CONT](VC/RC):If you do not have another «Kagero» vanguard or rear-guard, 
 * this unit gets [Power]-2000.
 * 
 * [ACT](VC/RC):[Counter Blast (3)] Until end of turn, this unit gets [Power]+5000, 
 * gets "[AUTO](VC/RC):When this unit's attack hits an opponent's rear-guard, 
 * [Stand] this unit.", and loses "Twin Drive!!".
 */

public class DragonicOverlord : UnitObject {
	public override void Cont ()
	{
		if(NumUnits(delegate(Card c) { return c.BelongsToClan("Kagero") && c != OwnerCard; }, true) == 0)
		{
			SetPower(-2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			UnsetBool(1);
			OwnerCard.bDisableTwinDrive = false;
		}
		else if(cs == CardState.AttackHits)
		{
			if(!GetDefensor ().IsVanguard()
			   && GetBool(1))
			{
				StandUnit(OwnerCard);
			}
		}
	}

	public override int Act ()
	{
		if(CB (3))
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

	public override void Update()
	{
		DelayUpdate (delegate {
			CounterBlast(3,
			delegate {
				IncreasePowerByTurn(OwnerCard, 5000);
				OwnerCard.bDisableTwinDrive = true;
				SetBool(1);
				EndEffect();
			});
		});
	}
}
