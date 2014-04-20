using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):At the end of the battle that this unit attacked a vanguard, if you 
 * have an «Aqua Force» vanguard, [Stand] this unit, and this unit gets 
 * [Power]-5000 until end of turn. This ability cannot be used for the rest of that 
 * turn.
 */

public class WaterGeneralOfWavelikeSpiralsBenedict : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC() && GetDefensor().IsVanguard() && !GetBool(2))
			{
				SetBool(1);	
			}
			
			ConfirmAttack();
		}
		else if(cs == CardState.EndBattle)
		{
			if(VanguardIs("Aqua Force") && GetBool(1))
			{
				IncreasePowerByTurn(OwnerCard, -5000);
				StandUnit(OwnerCard);
				SetBool(2);
			}
			
			UnsetBool(1);
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(2);	
		}
	}
}
