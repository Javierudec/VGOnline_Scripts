using UnityEngine;
using System.Collections;

public class BrightlanceDragoon : UnitObject {
	public override void Cont()
	{
		if(GetSameColum(OwnerCard.pos).clan != "Narukami")
		{
			AddContPower(-2000);	
		}
	}
	
	public override int Act()
	{
		if(CB(1))
		{
			return 1;
		}
		
		return 0;
	}
	
	public override void Active()
	{
		StartEffect();
		ShowAndDelay();
	}
	
	public override void Update()
	{
		DelayUpdate(delegate {
			CounterBlast(1, delegate {
				IncreasePowerByTurn(OwnerCard, 1000);
				EndEffect();
			});
		});
	}
}
