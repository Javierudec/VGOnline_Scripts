using UnityEngine;
using System.Collections;

public class SpiritualSphereEradicatorNata : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Narukami"))
			{
				SetBool(1);
				Forerunner("Narukami");
			}
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && GetVanguard().name.Contains("Eradicator"))
		{
			return 1;
		}

		return 0;
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

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectAnimField(GetVanguard());
			GetVanguard().unitAbilities.AddUnitObject(new SpiritualSphereEradicatorNataEXT());
			EndEffect();
		});
	}
}

public class SpiritualSphereEradicatorNataEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyCardSendToDropZone)
		{
			if(VC ())
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
