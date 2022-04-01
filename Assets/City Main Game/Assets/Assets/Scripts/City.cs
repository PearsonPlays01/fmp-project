using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using CityEngine.Simulation;

public class City : MonoBehaviour
{
    public int money;
    public int curPopulation;
    public int curJobs;
    public int curFood;
    public int maxPopulation;
    public int maxJobs;
    public int incomePerJob;

    private BuildingPreset curBuildingPreset;


    private float day;

    public TextMeshProUGUI statsText;

    private List<BuildingPreset> buildings = new List<BuildingPreset>();

    public static City inst;

    void Awake()
    {
        inst = this;
    }


    void Update()
    {
        // Empty string for new text
        string newText = "";

        // Add data
       // newText += $"Time: {TimeProgression.GetTimeAsString()}  "; // Current time
       // newText += $"Sim Speed: {TimeProgression.timeMultiplyer}  "; // Sim speed
        newText += $"Money: {money}  ";
        newText += $"Pop: {curPopulation}/{maxPopulation}  ";
        newText += $"Jobs: {curJobs}/{maxJobs}  ";
        newText += $"Food: {curFood}   ";
        newText += $"Time: {TimeProgression.GetTimeAsString()}  "; // Current time
        newText += GetComponent<BuildingPlacer>().ReturnBuildingCostAsString();

        // Set text to new text
        statsText.text = newText;

        // Update stats
        if (day != TimeProgression.GetCurrentDay()) {
            // Calculate stats
            CalculateMoney();
            CalculatePopulation();
            CalculateJobs();
            CalculateFood();

            // Increase day
            day++;
        }
    }
    public void OnPlaceBuilding(BuildingPreset building)
    {
        maxPopulation += building.population;
        maxJobs += building.jobs;
        buildings.Add(building);
    }

    void CalculateMoney()
    {
        money += curJobs * incomePerJob;

        foreach(BuildingPreset building in buildings)
            money -= building.costPerTurn;
    }

    void CalculatePopulation()
    {
        maxPopulation = 0;

        foreach(BuildingPreset building in buildings)
            maxPopulation += building.population;

        if(curFood >= curPopulation && curPopulation < maxPopulation)
        {
            curFood -= curPopulation / 4;
            curPopulation = Mathf.Min(curPopulation + (curFood / 4), maxPopulation);
        }
        else if(curFood < curPopulation)
        {
            curPopulation = curFood;
        }
    }

    void CalculateJobs()
    {
        curJobs = 0;
        maxJobs = 0;

        foreach(BuildingPreset building in buildings)
            maxJobs += building.jobs;

        curJobs = Mathf.Min(curPopulation, maxJobs);
    }

    void CalculateFood()
    {
        curFood = 0;

        foreach(BuildingPreset building in buildings)
            curFood += building.food;
    }
}