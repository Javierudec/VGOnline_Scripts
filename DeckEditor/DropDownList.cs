using UnityEngine;
using System.Collections;
using System;

public class DropDownList : MonoBehaviour {
	//global variables for settings
	private bool showList   = false;
	private int listEntrySelected;
	private int listEntry = 2;
	private int defaultEntryNumber = 0;
	private GUIStyle generalListStyle = new GUIStyle();
	private float _x;
	private float _y;
	private int CurSize = 0;
	public float width = 100.0f;
	int offset = 0;
	bool bPress = false;
	int lastEntry = -1;
	int selected = 0;
	bool bOpen = false;
	
	private int dropdownListHash = "DropdownList".GetHashCode();
	
	//dropdown menu content
	private GUIContent[] listColours;
	
	public DropDownList(float x, float y, int size, int _width = 100)
	{
		width = _width;
		_x = x;
		_y = y;
		listColours = new GUIContent[size];
		generalListStyle.padding.left = generalListStyle.padding.right = generalListStyle.padding.top = generalListStyle.padding.bottom = 4;
		generalListStyle.normal.textColor = Color.white;
		generalListStyle.normal.background = Resources.Load ("BlackQuad") as Texture2D;
	}
	
	public void AddElement(string name)
	{
		listColours[CurSize++]  = new GUIContent(name);	
	}
	
	public int GetID()
	{
		return defaultEntryNumber + offset;	
	}
	
	public void SelectOptionWithValue(string str)
	{
		for(int i = 0; i < listColours.Length; i++)
		{
			if(listColours[i].text == str)
			{
				if(i <= 5)
				{
					defaultEntryNumber = i;
					offset = 0;
				}
				else
				{
					defaultEntryNumber = 5;
					offset = i - 5;
				}
				
				selected = defaultEntryNumber + offset;
				
				return;
			}	
		}
		defaultEntryNumber = 0;
		offset = 0;
		selected = 0;
	}
	
	public void Resize(int newSize)
	{
		listColours = new GUIContent[newSize];
	}
	
	//    List(Rect(0,0,100,100),     false,        0,        GUIContent("Select Colour"),  listColours       "button",       "box",      generalListStyle)
	private void List(Rect position, bool expandList, int listEntry, GUIContent defaultListEntry, GUIContent[] listToUse, GUIStyle buttonStyle, GUIStyle boxStyle, GUIStyle listStyle)
	{
	  
	  int controlID = GUIUtility.GetControlID(dropdownListHash, FocusType.Passive);
	  
	  if(Event.current.GetTypeForControl(controlID) == EventType.mouseDown && (!GlobalVarAdvSearch.dropDownListOpen || bOpen))
	  {
	  		if (position.Contains(Event.current.mousePosition))
	    	{
	    	    GUIUtility.hotControl = controlID;
	    	    showList = !showList;
				if(showList == true)
				{
					GlobalVarAdvSearch.dropDownListOpen = true;
					bOpen = true;
				}
				else
				{
					GlobalVarAdvSearch.dropDownListOpen = false;
					bOpen = false;
				}
	    	}
	  }
	    
	  if(Event.current.GetTypeForControl(controlID) == EventType.mouseDown && !position.Contains(Event.current.mousePosition))
	  {
	  	GUIUtility.hotControl = controlID;
	  }              
	  
	  GUI.Label(position, defaultListEntry, buttonStyle);
	  
	  if(expandList)
	  {
	  	//list rectangle
	  	Rect listRect = new Rect(position.x, position.y+20, position.width, listStyle.CalcHeight(listToUse[0], 1.0f) * 7);
	  	GUI.Box(listRect, "", boxStyle);
	  
		GUIContent[] tempArray = new GUIContent[7];
		tempArray[0] = new GUIContent("\t\tGo up");
		tempArray[6] = new GUIContent("\t\tGo down");
		for(int i = 1; i <= 5; i++)
		{
			tempArray[i] = listToUse[offset + i - 1];		
		}
			
	  	listEntrySelected = GUI.SelectionGrid(listRect, listEntrySelected, tempArray, 1, listStyle);
		if(listEntrySelected != 0 && listEntrySelected != 6 && defaultEntryNumber != (listEntrySelected - 1))
		{
			GUIUtility.hotControl = controlID;
			defaultEntryNumber = listEntrySelected - 1;
			selected = defaultEntryNumber + offset;
			showList = !showList;
			if(showList == true)
			{
				GlobalVarAdvSearch.dropDownListOpen = true;
				bOpen = true;
			}
			else
			{
				GlobalVarAdvSearch.dropDownListOpen = false;
				bOpen = false;
			}
		}
			
		if(listEntrySelected == 0 && lastEntry != listEntrySelected)
		{
			if(offset > 0)
			{
				offset--;
			}
				
			lastEntry = listEntrySelected;
		}
			
		if(listEntrySelected == 6 && lastEntry != listEntrySelected)
		{
			if(offset < (listToUse.Length - 5))
			{
				offset++;		
			}
			lastEntry = listEntrySelected;
		}
			
		if(Input.GetMouseButtonDown(0))
		{
			bPress = true;
		}
			
		if(Input.GetMouseButtonUp(0))
		{
			if(bPress)
			{
				lastEntry = -1;
				bPress = false;
			}
		}
	  }
	}
	
	public bool IsOpen()
	{
		return showList;	
	}
	
	public void Draw()
	{
	  List(new Rect(_x , _y , width , 20), showList, listEntry, new GUIContent(listColours[selected].text), listColours, "button", "box", generalListStyle);
	}
	
	public string GetValue()
	{
		return listColours[defaultEntryNumber + offset].text;	
	}
}
