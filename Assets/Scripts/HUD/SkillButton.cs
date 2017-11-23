﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
	private const float SELECTED_SCALE = 100f;
	private const float BASE_SCALE = 70f;
	private const float SELECTED_COLOR = 1.5f;
	private const float UNLOCK_COLOR = 2f;
	private RectTransform recT;
	[SerializeField]
	private List<SkillLink> links;
	private bool unlocked = false;
	private bool unlockable = false;
	private bool selected = false;
	public string descriptionText;
	public string title;
	public string type;
	public int cost;


	void Awake()
	{
		recT = GetComponent<RectTransform>();
	}

	//temp
	void Update()
	{
	}


	//Do this when the cursor enters the rect area of this selectable UI object.
	public void SelectSkill()
	{
		if (!selected)
		{
			recT.sizeDelta = new Vector2(SELECTED_SCALE, SELECTED_SCALE);
			Color buttonColor = GetComponent<Image>().color;
			buttonColor.r *= SELECTED_COLOR;
			buttonColor.g *= SELECTED_COLOR;
			buttonColor.b *= SELECTED_COLOR;
			GetComponent<Image>().color = buttonColor;
			selected = true;
		}
	}

	public void DeselectSkill()
	{
		if (selected)
		{
			recT.sizeDelta = new Vector2(BASE_SCALE, BASE_SCALE);
			Color buttonColor = GetComponent<Image>().color;
			buttonColor.r /= SELECTED_COLOR;
			buttonColor.g /= SELECTED_COLOR;
			buttonColor.b /= SELECTED_COLOR;
			GetComponent<Image>().color = buttonColor;

			selected = false;
		}
	}

	public void Unlock()
	{
		if (unlockable && !unlocked)
		{
			Color buttonColor = GetComponent<Image>().color;
			buttonColor.r *= SELECTED_COLOR;
			buttonColor.g *= SELECTED_COLOR;
			buttonColor.b *= SELECTED_COLOR;
			GetComponent<Image>().color = buttonColor;
			foreach (SkillLink link in links)
			{
				link.MakeAvailable();
			}
		}
	}


	//Cette fonction ne sert pas. Vous pouvez la supprimer
	/*public void Lock()
	{
		Color buttonColor = GetComponent<Image>().color;
		buttonColor.r /= SELECTED_COLOR;
		buttonColor.g /= SELECTED_COLOR;
		buttonColor.b /= SELECTED_COLOR;
		GetComponent<Image>().color = buttonColor;
	}*/


	public bool IsUnlocked()
	{
		return unlocked;
	}
	public bool IsUnlockable()
	{
		return unlockable;
	}
	public void MakeAvailable()
	{
		unlockable = true;
	}

}
