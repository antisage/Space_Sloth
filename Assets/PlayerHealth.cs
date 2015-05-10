using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	#region FIELDS
	
	private int currentHealth;
	private int currentpoints;
	public int maxHealth;
	public RectTransform healthTransform;

	public Text healthText;
	public Text PointText;
	public Image visualHealth;

	private float cachedY;
	private float minXValue;
	private float maxXValue;
	private float currentXValue;
	public float cooldown;
	private bool onCD;
	
	#endregion
	
	#region PROPERTIES

	public int Health
	{
		get { return currentHealth; }
		set
		{
			currentHealth = value;
			HandleHealthbar();
		}
	}

	public int Points
	{
		get {return currentpoints; }
		set
		{
			currentpoints = value;
			HandleHealthbar();
		}
	}
	
	#endregion
	
	void OnTriggerEnter(){
		Health -= 5;
	}

	void Update(){
		//Health -= 1;
		Points += 1;
	}
	
	// Use this for initialization
	void Start()
	{   
		Points = 0;
		//Health = 99;
		//Sets all start values
		onCD = false;
		cachedY = healthTransform.position.y; //Caches the healthbar's start pos
		maxXValue = healthTransform.position.x; //The max value of the xPos is the start position
		minXValue = healthTransform.position.x - healthTransform.rect.width; //The minValue of the xPos is startPos - the width of the bar
		currentHealth = maxHealth; //Sets the current health to the maxHealth
	}
	
	/// <summary>
	/// Handles the healthbar by moving it and changing color
	/// </summary>
	private void HandleHealthbar()
	{   
		//Writes the current health in the text field
		healthText.text = "Health: " + currentHealth;

		PointText.text = "Points: " + currentpoints;
		
		//Maps the min and max position to the range between 0 and max health
		currentXValue = Map(currentHealth, 0, maxHealth, minXValue, maxXValue);
		
		//Sets the position of the health to simulate reduction of health
		healthTransform.position = new Vector3(currentXValue, cachedY);
		
		if (currentHealth > maxHealth / 2) //If we have more than 50% health we use the Green colors
		{
			visualHealth.color = new Color32((byte)Map(currentHealth, maxHealth / 2,maxHealth, 255, 0), 255, 0, 255);
		}
		else //If we have less than 50% health we use the red colors
		{
			visualHealth.color = new Color32(255, (byte)Map(currentHealth, 0, maxHealth / 2, 0, 255), 0, 255);
		}
	}
	
	/// <summary>
	/// This method maps a range of number into another range
	/// </summary>
	/// <param name="x">The value to evaluate</param>
	/// <param name="in_min">The minimum value of the evaluated variable</param>
	/// <param name="in_max">The maximum value of the evaluated variable</param>
	/// <param name="out_min">The minum number we want to map to</param>
	/// <param name="out_max">The maximum number we want to map to</param>
	/// <returns></returns>
	public float Map(float x, float in_min, float in_max, float out_min, float out_max)
	{
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
}
