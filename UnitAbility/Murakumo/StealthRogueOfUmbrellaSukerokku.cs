using UnityEngine;
using System.Collections;

public class StealthRogueOfUmbrellaSukerokku : UnitObject {
	public override int Act ()
	{
		if(RC ()
		   && CanSoulBlast(1)
		   && OpenRC ()
		   && VanguardIs("Murakumo"))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			SelectOpenRC(delegate(fieldPositions p) {
				MoveToOpenRC(OwnerCard, p);
				EndEffect();
			});
		});
	}
}
