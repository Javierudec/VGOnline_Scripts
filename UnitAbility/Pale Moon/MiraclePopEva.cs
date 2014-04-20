using UnityEngine;
using System.Collections;

public class MiraclePopEva : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		//Game.GameChat.AddChatMessage("ADMIN", cs + "");
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs ("Pale Moon")
			   && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
		else if(cs == CardState.Attacking)
		{
			if(VC()
			   && GetDefensor().IsVanguard()
			   && GetDeck().Size() > 0)
			{
				StartEffect();
				ShowAndDelay();
				SetBool(1);
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SoulCharge(1);
			}
			else
			{
				IncreasePowerByTurn(GetVanguard(), 10000);
				GetVanguard().unitAbilities.AddUnitObject(new MiraclePopEvaEXT());
				EndEffect();
			}
		});

		SoulChargeUpdate(delegate {
			IncreasePowerByBattle(OwnerCard, 1000);
			EndEffect();
		});
	}
}

public class MiraclePopEvaEXT : UnitObject {
	int n;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && NumUnits (delegate(Card c) { return c.BelongsToClan("Pale Moon"); }) >= 2)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectUnit("Choose two of your \"Pale Moon\" rear-guards.", 2, false,
			delegate {
				MoveToSoul(Unit);
			},
			delegate {
				return Unit.BelongsToClan("Pale Moon");
			},
			delegate {
				SetBool(1);
				Game.field.ViewSoul(2, delegate(Card c) {
					return c.BelongsToClan("Pale Moon");
				});
			});
		});

		ResolveSoulOpening(1,
		delegate {
			n = _AuxIdVector.Count - 1;
			CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
			_AuxIdVector.RemoveAt(0);
		},
		delegate {
			EndEffect();
		});

		CallFromSoulUpdate(delegate {
			if(n > 0)
			{
				CallFromSoul(Game.field.GetSoulByID(_AuxIdVector[0]));
				n--;
			}
			else
			{
				EndEffect();
			}
		});
	}
}
