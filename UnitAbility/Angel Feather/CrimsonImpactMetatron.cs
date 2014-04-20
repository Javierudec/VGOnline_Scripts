using UnityEngine;
using System.Collections;

public class CrimsonImpactMetatron : UnitObject {
	public override int Act()
	{
		if(VC ()
		   && LimitBreak(4)
		   && CB (1)
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Angel Feather"); }) >= 2
		   && !GetBool(1))
		{
			return 1;
		}

		return 0;
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && GetDefensor().IsVanguard())
			{
				IncreasePowerByBattle(OwnerCard, 3000);
			}
		}
		else if(cs == CardState.EndBattle)
		{
			UnsetBool(1);
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectUnit ("Choose two of your \"Angel Feather\" rear-guards.", 2, false,
				delegate {
					FromFieldToDamage(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Angel Feather");
				},
				delegate {
					SelectInDamage(1, false,
					delegate {
						CallFromDamage(_SID_Card);
					},
					delegate(Card c) {
						return c.BelongsToClan("Angel Feather");
					});
				});
			});
		});

		CallFromDamageUpdate(delegate {
			if(GetBool(2))
			{
				UnsetBool(2);
				SetBool(1);
				EndEffect();
			}
			else
			{
				SelectInDamage(1, false,
				delegate {
					SetBool(2);
					CallFromDamage(_SID_Card);
				},
				delegate(Card c) {
					return c.BelongsToClan("Angel Feather");
				});
			}
		});
	}
}
