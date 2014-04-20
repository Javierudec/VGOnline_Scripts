using UnityEngine;
using System.Collections;

public class WheelAssault : UnitObject {
	Card firstUnit, secondUnit;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Boost)
		{
			SetBool(1);
		}
		else if(cs == CardState.EndBattle_NotMe)
		{
			if(GetBool(1)
			   && RC ()
			   && VanguardIs("Aqua Force")
			   && CB(1)
			   && NumUnits (delegate(Card c) { return c.BelongsToClan("Aqua Force"); }) >= 2)
			{
				DisplayConfirmationWindow();
			}

			UnsetBool(1);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				firstUnit  = null;
				secondUnit = null;

				SelectUnit ("Choose two of your \"Aqua Force\" rear-guards.", 2, true,
				delegate {
					if(firstUnit == null)
					{
						firstUnit  = Unit;
					}
					else
					{
						secondUnit = Unit;
					}

					SelectAnimField(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Aqua Force");
				},
				delegate {
					ExchangePositions(firstUnit, secondUnit);
					EndEffect();
				});
			});
		});
	}
}
