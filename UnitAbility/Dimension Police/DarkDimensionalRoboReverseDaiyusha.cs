using UnityEngine;
using System.Collections;

public class DarkDimensionalRoboReverseDaiyusha : UnitObject {
	public override int Act ()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB (1)
		   && NumUnits (delegate(Card c) { return c.name.Contains("Dimensional Robo"); }) >= 2
		   && !GetBool(1))
		{
			return 1;
		}

		return 0;
	}

	public override void Cont ()
	{
		if(VC()
		   && IsInSoul (CardIdentifier.SUPER_DIMENSIONAL_ROBO__DAIYUSHA))
		{
			AddContPower(2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndBattle)
		{
			UnsetBool(1);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit ("Choose two of your rear-guards with \"Dimensional Robo\" in its card name.", 2, true,
				delegate {
					LockUnit (Unit);
				},
				delegate {
					return Unit.name.Contains("Dimensional Robo");
				},
				delegate {
					IncreaseEnemyPowerByTurn(GetEnemyVanguard(), -10000);
					SetBool(1);
				});
			});
		});
	}
}
