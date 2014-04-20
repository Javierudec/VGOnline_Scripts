using UnityEngine;
using System.Collections;

public class StealthBeastKuroko : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Nubatama");
		}
		else if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && GetDefensor().IsVanguard()
			   && GetAttacker() == tmp
			   && VanguardIs("Nubatama")
			   && Game.enemyField.BindZone.Count > 0
			   && CanSoulBlast(1))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			ShowAndDelay();
		}
		else
		{
			Forerunner_Active();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			int n = Game.enemyField.BindZone.Count;
			if(n > 0)
			{
				SetBool(1);
				Game.enemyField.ViewBindZone(n);
			}
			else
			{
				EndEffect();
			}
		});

		ResolveEnemyBindOpening(1,
		delegate {
			for(int i = 0; i < _AuxIdVector.Count; i++)
			{
				OpponentFromBindToDrop(_AuxIdVector[0]);
			}
			EndEffect();
		},
		delegate {
			EndEffect();
		});
	}
}
