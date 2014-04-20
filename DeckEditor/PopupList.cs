using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * GUI element, allows to have multiple options that will be displayed when this GUI is pressed.
 * 
 * Initial State: 
 * "Current Option Selected"
 * 
 * When Pressed:
 * "Current Option Selected"
 * - Option 1
 * - Option 2
 * - ....
 * - Option n
 */

public class PopupList {
	//Coordinates
	int x = 0;
	int y = 0;

	//Dimension
	int width  = 0; //Single button width
	int height = 0; //Single button height
	int verticalSliderWidth = 16;

	//num options availabe at the same time.
	int numOptions = 0;

	bool bShow = false; //Tells if the popuplist is open or not.
	string currentSelectedOption = "";
	List<string> options;
	VerticalSlider verticalSlider;

	int lowerIndex;

	public PopupList(int _x, int _y, int _width, int _height, int _numOptions)
	{
		x = _x;
		y = _y;
		width = _width;
		height = _height;
		numOptions = _numOptions;
		bShow = false;
		options = new List<string>();

		lowerIndex = 0;

		int sliderBarHeight = _numOptions * _height;
		verticalSlider = new VerticalSlider(_x + _width - verticalSliderWidth,
		                                    _y + _height, 
		                                    verticalSliderWidth, 
		                                    _numOptions * _height,
		                                    sliderBarHeight); 

		verticalSlider.SetOnArrowUpEvent(delegate {
			UpList();
		});

		verticalSlider.SetOnArrowDownEvent(delegate {
			DownList();
		});
	}

	void UpList()
	{
		int idx = options.IndexOf(currentSelectedOption);
		lowerIndex--;
		
		if(lowerIndex == idx) 
		{
			lowerIndex--;
		}
		
		if(lowerIndex < 0) 
		{
			lowerIndex = 0;
			if(lowerIndex == idx)
			{
				lowerIndex++;
			}
		}
	}

	void DownList()
	{
		int idx = options.IndexOf(currentSelectedOption);
		lowerIndex++;
		
		if(lowerIndex == idx)
		{
			lowerIndex++;
		}
		
		if(lowerIndex > (options.Count - numOptions))
		{
			lowerIndex = (options.Count - numOptions);
			if(lowerIndex == idx)
			{
				lowerIndex--;
			}
		}
	}

	public void SetValue(string newValue)
	{
		currentSelectedOption = newValue;
	}

	public bool IsOpen()
	{
		return bShow;
	}

	public string GetValue()
	{
		return currentSelectedOption;
	}

	public void Add(string newOption)
	{
		options.Add(newOption);

		if(options.Count == 1 && currentSelectedOption == "")
		{
			currentSelectedOption = options[0];
		}

		SetSliderYFactor((16.8f/24.0f) * options.Count);

		if(options.Count <= numOptions)
		{
			verticalSlider.SetBarHeight(numOptions * height);
		}
		else
		{
			verticalSlider.SetBarHeight((int)(numOptions * height * (numOptions / (float)options.Count)));
		}
	}

	public int GetID()
	{
		return options.IndexOf(currentSelectedOption);
	}

	public void SelectOptionWithValue(string optionName)
	{
		currentSelectedOption = optionName;
	}

	public int GetNumOptions()
	{
		return options.Count;
	}

	public void SetSliderYFactor(float newFactor)
	{
		verticalSlider.SetBarYMovementFactor(newFactor);
	}

	//Draw elements on screen. (MUST be called inside an OnGUI() method)
	public void Render()
	{
		if(GUI.Button(new Rect(x, y, width, height), currentSelectedOption))
		{
			bShow = !bShow;

			lowerIndex = options.IndexOf(currentSelectedOption) + 1;
			if(lowerIndex > (options.Count - numOptions))
			{
				lowerIndex = options.Count - numOptions;
				if(lowerIndex == options.IndexOf(currentSelectedOption))
				{
					lowerIndex--;
				}
			}

			verticalSlider.SetMoves(lowerIndex - 1);
		}

		if(bShow)
		{
			float scrollMovement = Input.GetAxis("Mouse ScrollWheel");
			if(scrollMovement < 0)
			{
				DownList();
			}
			else if(scrollMovement > 0)
			{
				UpList();
			}

			int i = lowerIndex;
			int numCurrentOptions = 0;
			int limit = numOptions;
			while(numCurrentOptions < limit && i < options.Count)
			{
				if(options[i] == currentSelectedOption) 
				{
					i++;
				}
				else
				{
					if(GUI.Button(new Rect(x, y + height * (numCurrentOptions + 1), width - verticalSliderWidth, height), options[i]))
					{
						currentSelectedOption = options[i];
						bShow = false;
					}

					i++;
					numCurrentOptions++;
				}
			}

			verticalSlider.Render();
		}
	}
}
