using UnityEngine;
using System.Collections;

public class EnigmanWave : UnitObject {
	public override void Cont()
	{
		if(OwnerCard.IsVanguard() &&
		   Game.field.GetSoulByID(CardIdentifier.ENIGMAN_RIPPLE) != null)
		{
			AddContPower(1000);
		}
	}
	
	public override void Auto(CardState cs, Card effectOwner)
	{	
		if(cs == CardState.Attacking)
		{
			if(OwnerCard.GetPower() >= 14000 && OwnerCard.IsVanguard())
			{
				SetBool(1);	
			}
		}
		else if(cs == CardState.AttackHits)
		{
			if(OwnerCard.IsVanguard() && GetBool(1) &&
			   GetDefensor().IsVanguard())
			{
				StartEffect();
				ShowAndDelay();	
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);	
		}
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			DrawCardWithoutDelay();
			EndEffect();
		});
	}
}
