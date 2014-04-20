using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC/RC):When this unit attacks, if the number of cards in your 
 * hand is greater than your opponent's, this unit gets [Power]+3000 until 
 * end of that battle.
 */

public class OnmyojiOfTheMoonlitNight : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetHand().Size() > GetEnemyHand().Size())
			{
				IncreasePowerByBattle(OwnerCard, 3000);	
			}
			ConfirmAttack();
		}
	}
}
