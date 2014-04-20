using UnityEngine;
using System.Collections;

public class TelescopeRabbit : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Great Nature"))
			{
				SetBool(1);
				Forerunner("Great Nature");
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && CB (1)
		   && OwnerCard.IsStand())
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				RestUnit(OwnerCard);
				SelectUnit ("Choose one of your \"Great Nature\" rear-guards.", 1, true,
				delegate {
					IncreasePowerByTurn(Unit, 4000);
					Unit.unitAbilities.AddUnitObject(new TelescopeRabbitEXT());
				},
				delegate {
					return Unit.BelongsToClan("Great Nature");
				},
				delegate {

				});
			});
		});
	}
}

public class TelescopeRabbitEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			RetireUnit(OwnerCard);
		}
	}
}