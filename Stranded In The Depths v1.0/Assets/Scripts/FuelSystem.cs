using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour {

	public float startFuel; //start fuel
	public float maxFuel = 100f; //max fuel
	public float fuelConsumptionRate; //fuel drop rate
	public Slider fuelIndicatorSld; //slider to indicate the fuel level
	public Text fuelIndicatorTxt; //text to indicate the fuel level

	// this is for the Fill gauge
	public float speedGauge;
	public Image visualFuelGauge;

	// Use this for initialization
	void Start () 
	{
		///cap the fuel
		if(startFuel > maxFuel)
		{
			startFuel = maxFuel;
		}
		//update ui elements
		fuelIndicatorSld.maxValue = maxFuel;
		UpdateUI();
	}

	void Update()
	{
		//New after Ernesto. Just line below.
		if (CollisionHandler.instance.isTransitioning == false)
		{
			if (Movement.instance.isMoving)
			{
				startFuel -= Time.deltaTime * fuelConsumptionRate;
				UpdateUI();
			}

			if (startFuel <= 0.0f)
			{       // Show Ad
				Movement.instance.canMove = false;
				Movement.instance.gameObject.GetComponent<Rigidbody>().mass = 10;
				Movement.instance.gameObject.GetComponent<Rigidbody>().drag = 0;
			}
		}
	}

	//PICK UP JerryCan 
	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.tag == "Friendly")
		{
			startFuel = maxFuel;
			Movement.instance.canMove = true;
			Movement.instance.gameObject.GetComponent<Rigidbody>().mass = 1;
			Movement.instance.gameObject.GetComponent<Rigidbody>().drag = 5;
			///cap the fuel
			if (startFuel > maxFuel)
			{
				startFuel = maxFuel;
			}
			UpdateUI();
		}
	}
    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Fuel")
		{
			Destroy(other.gameObject);
			startFuel += 30;
			Movement.instance.canMove = true;
			Movement.instance.gameObject.GetComponent<Rigidbody>().mass = 1;
			Movement.instance.gameObject.GetComponent<Rigidbody>().drag = 5;
			///cap the fuel
			if (startFuel > maxFuel)
			{
				startFuel = maxFuel;
			}
			UpdateUI();
		}
	}

    void UpdateUI()
	{
			fuelIndicatorSld.value = startFuel;
			fuelIndicatorTxt.text = "Fuel left: " + startFuel.ToString("0") + "%";
			visualFuelGauge.fillAmount = Mathf.Lerp(visualFuelGauge.fillAmount, startFuel, Time.deltaTime * speedGauge);

			//if there is no fuel inform the user
			if (startFuel <= 0)
			{
				startFuel = 0;
				fuelIndicatorTxt.text = "Out of fuel!";
			}
	}
}
