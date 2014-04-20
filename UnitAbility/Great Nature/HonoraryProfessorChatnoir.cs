using UnityEngine;
using System.Collections;

public class HonoraryProfessorChatnoir : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Great Nature")
			   && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 2000);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			GetVanguard().unitAbilities.AddUnitObject(new HonoraryProfessorChatnoirEXT());
			EndEffect();
		});
	}
}


public class HonoraryProfessorChatnoirEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking_NotMe)
		{
			if(VC ()
			   && GetDefensor().IsVanguard()
			   && !ownerEffect.IsVanguard()
			   && ownerEffect.BelongsToClan("Great Nature"))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose one of your \"Great Nature\" rear-guards.", 1, true,
			delegate {
				IncreasePowerByTurn(Unit, 4000);
				Unit.unitAbilities.AddUnitObject(new HonoraryProfessorChatnoirEXTEXT());
			},
			delegate {
				return Unit.BelongsToClan("Great Nature");
			},
			delegate {

			});
		});
	}
}

public class HonoraryProfessorChatnoirEXTEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			RetireUnit(OwnerCard);
			if(GetDeck().Size() > 0)
			{
				DrawCardWithoutDelay();
			}
		}
	}
}