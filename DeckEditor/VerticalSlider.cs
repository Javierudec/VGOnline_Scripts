using UnityEngine;
using System.Collections;

public class VerticalSlider {
	float width = 0;
	float height = 0;
	float arrowHeight = 28;
	float x = 0;
	float y = 0;
	Texture2D upArrowTexture;
	Texture2D downArrowTexture;
	Texture2D barTexture;
	float currBarHeight;
	float barUpperLimit;
	float barLowerLimit;
	float barDeltaMovement;
	float currBarY;
	public delegate void void0Param();
	void0Param onArrowDown = null;
	void0Param onArrowUp = null;
	bool bClick = false;
	float yFactor = 0.0f;

	public VerticalSlider(float _x, float _y, float _width, float _height, float _barHeight)
	{
		x = _x;
		y = _y;
		width = _width;
		height = _height;
		arrowHeight = _width;
		currBarHeight = _barHeight;
		currBarY = y + arrowHeight;

		barUpperLimit = _y + arrowHeight;
		barLowerLimit = _y + _height - 2 * arrowHeight;
		barDeltaMovement = (float)((_height - _barHeight) / (float)arrowHeight);

		upArrowTexture = Resources.Load ("DeckEditor/UpArrow") as Texture2D;
		downArrowTexture = Resources.Load ("DeckEditor/DownArrow") as Texture2D;
		barTexture = Resources.Load ("DeckEditor/square") as Texture2D;
	}

	public void SetOnArrowUpEvent(void0Param f)
	{
		onArrowUp = f;
	}

	public void SetOnArrowDownEvent(void0Param f)
	{
		onArrowDown = f;
	}

	public void SetBarYMovementFactor(float newFactor)
	{
		yFactor = newFactor;
		//Debug.Log("yFactor: " + yFactor);
	}

	public void SetBarHeight(float newHeight)
	{
		currBarHeight = newHeight;
		barDeltaMovement = (((height - 2 * arrowHeight) - currBarHeight) / yFactor);
	}

	bool MouseCollideWithRect(Rect r)
	{
		float mouseX = (float)Input.mousePosition.x;
		float mouseY = (float)(Screen.height - Input.mousePosition.y);

		if(mouseX >= r.x 
		   && mouseX <= (r.x + r.width)
		   && mouseY >= r.y
		   && mouseY <= (r.y + r.height))
		{
			return true;
		}

		return false;
	}

	public void SetMoves(int n)
	{
		currBarY = y + arrowHeight + (barDeltaMovement * n);
		if(currBarY > barLowerLimit)
		{
			currBarY = barLowerLimit;
		}
	}

	public void Render()
	{
		Rect upArrowRect = new Rect(x, y, width, arrowHeight);
		Rect barRect = new Rect(x, currBarY, width, currBarHeight);
		Rect downArrowRect = new Rect(x, y + height - arrowHeight, width, arrowHeight);

		GUI.DrawTexture(upArrowRect, upArrowTexture);

		GUI.DrawTexture(barRect, barTexture);

		GUI.DrawTexture(downArrowRect, downArrowTexture);

		//User interaction.
		if(Input.GetMouseButtonUp(0))
		{
			bClick = false;
		}

		if(Input.GetMouseButtonDown(0) && !bClick)
		{
			//Debug.Log("CurBarY: " + barDeltaMovement);

			bClick = true;
			if(MouseCollideWithRect(upArrowRect))
			{
				currBarY -= barDeltaMovement;
				if(currBarY < barUpperLimit)
				{
					currBarY = barUpperLimit;
				}
				else
				{
					if(onArrowUp != null)
					{
						onArrowUp();
					}
				}
			}

			if(MouseCollideWithRect(downArrowRect))
			{
				currBarY += barDeltaMovement;
				if(currBarY > barLowerLimit)
				{
					currBarY = barLowerLimit;
				}
				else
				{
					if(onArrowDown != null)
					{
						onArrowDown();
					}
				}
			}
		}
	}
}
