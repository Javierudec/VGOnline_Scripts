using UnityEngine;
using System.Collections;

public class CombinedMonsterBugleed : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && VanguardIs("Dimension Police")
			   && GetDefensor().GetPower() <= 8000)
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(GetDeck().Size() > 0
			   && GetBool(1))
			{
				DrawCardWithoutDelay();
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);
		}
	}
}
