using UnityEngine;
using System.Collections;

public enum DynamicTextState
{
	NONE,
	FIRST_STEP,
	IDLE_STEP,
	SECOND_STEP
}

public class DynamicText {
	private string message = "No Text";
	private bool bIsActive = false;
	private float x = 0;
	private float y = 160;
	private float curTime = 0;
	private float idleTime = 1;
	private float maxTime = 0;
	private float minX = 0;
	private float middleX = 340;
	private float maxX = 700;
	private DynamicTextState state;

	public DynamicText()
	{

	}

	public bool GetIsActive()
	{
		return bIsActive;
	}

	public void SetText(string _text, float _time = 0.8f, float _idleTime = 1.2f)
	{
		message = _text;
		maxTime = _time;
		curTime = 0;
		x = minX;
		idleTime = _idleTime;
		state = DynamicTextState.FIRST_STEP;
		bIsActive = true;
	}

	public void Render()
	{
		if(bIsActive)
		{
			curTime += Time.deltaTime;

			if(state == DynamicTextState.FIRST_STEP)
			{
				float a = (maxTime) / (middleX - minX);
				x = (curTime + a * minX) / a;

				if(curTime > maxTime)
				{
					state = DynamicTextState.IDLE_STEP;
				}
			}
			else if(state == DynamicTextState.IDLE_STEP)
			{
				idleTime -= Time.deltaTime;
				if(idleTime <= 0)
				{
					state = DynamicTextState.SECOND_STEP;
					curTime = 0;
				}
			}
			else if(state == DynamicTextState.SECOND_STEP)
			{
				float a = (maxTime) / (maxX - minX);
				x = (curTime + a * middleX) / a;
				
				if(curTime > maxTime)
				{
					state = DynamicTextState.NONE;
					bIsActive = false;
				}
			}


			int lastFontSize = GUI.skin.label.fontSize;
			TextAnchor lastTextAnchor = GUI.skin.label.alignment;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize = 22;
			GUI.skin.label.normal.textColor = Color.black;
			GUI.Label(new Rect(x + 1, y + 1, 560, 300), message);
			GUI.skin.label.normal.textColor = Color.white;
			GUI.Label(new Rect(x, y, 560, 300), message);
			GUI.skin.label.fontSize = lastFontSize;
			GUI.skin.label.alignment = lastTextAnchor;
		}
	}
}
