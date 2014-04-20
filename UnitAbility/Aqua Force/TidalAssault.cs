using UnityEngine;
using System.Collections;

public class TidalAssault : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndBattle)
		{
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && VanguardIs("Aqua Force")
			   && !GetBool(1))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(1);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			StandUnit(OwnerCard);
			IncreasePowerByTurn(OwnerCard, -5000);
			SetBool(1);
			EndEffect();
		});
	}
}
