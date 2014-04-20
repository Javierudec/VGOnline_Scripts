using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExorcistMageDanDan : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			Forerunner("Narukami");
		}
		else if(cs == CardState.Call_NotMe || cs == CardState.Ride_NotMe)
		{
			if(RC ()
			   && ownerEffect.name.Contains("Dungaree")
			   && GetDeck().Size () > 0
			   && VanguardIs("Narukami"))
			{
				List<Card> tmpList = new List<Card>();
				tmpList.Add(GetDeck().TopCard());
				BindFromDeck(tmpList);
			}
		}
	}

	public override void Active ()
	{
		Forerunner_Active();
	}

	public override void Update ()
	{
		Forerunner_Update();
	}
}
