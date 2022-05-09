using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public enum Season {NONE, SPRING, SUMMER, AUTUMN, WINTER };
    public enum Weather {NONE, SUNNY, HOTSUN, RAIN, SNOW };
    public Season currentSeason;
    public Weather currentWeather;

    [Header ("Time Settings")]
    public float seasonTime;
    public float springTime;
    public float summerTime;
    public float autumnTime;
    public float winterTime;

    [Header("Light Settings")]
    public Light sunLight;
    private float defaultLightIntensity;
    public float summerLightIntensity;
    public float autumnLightIntensity;
    public float winterLightIntensity;

    private Color defaultLightColor;
    public Color summerColor;
    public Color autumnColor;
    public Color winterColor;
    public int currentYear;
    private void Start()
    {
        currentSeason = Season.SPRING;
        currentWeather = Weather.SUNNY;
        this.currentYear = 1;

        this.seasonTime = this.springTime;

        this.defaultLightColor = this.sunLight.color;
        this.defaultLightIntensity = this.sunLight.intensity;
    }
    public void ChangeSeason (Season seasonType)
    {
        if (seasonType != this.currentSeason)
        {
            switch (seasonType)
            {
            case Season.SPRING:
                currentSeason = Season.SPRING;
                break;
            case Season.SUMMER:
                currentSeason = Season.SUMMER;
                break;
            case Season.AUTUMN:
                currentSeason = Season.AUTUMN;
                break;
            case Season.WINTER:
                currentSeason = Season.WINTER;
                break;
            }
        }
    }
    public void ChangeWeather (Weather weatherType)
    {
        if (weatherType != this.currentWeather)
        {
            switch (weatherType)
            {
            case Weather.SUNNY:
                currentWeather = Weather.SUNNY;
                break;
            case Weather.HOTSUN:
                currentWeather = Weather.HOTSUN;
                break;
            case Weather.RAIN:
                currentWeather = Weather.RAIN;
                break;
            case Weather.SNOW:
                currentWeather = Weather.SNOW;
                break;
            }
        }
    }

    private void Update()
    {
        this.seasonTime -= Time.deltaTime;

        if (this.currentSeason == Season.SPRING)
        {
            ChangeWeather (Weather.SUNNY);  
              
            LerpSunIntensity (this.sunLight, defaultLightIntensity);

            if (this.seasonTime <= 0f)
            {
                ChangeSeason (Season.SUMMER);
                this.seasonTime = this.summerTime;
            }        
        }
    }

    private void LerpLightColor (Light light, Color c)
    {  
        light.color = Color.Lerp (light.color, c, 0.2f * Time.deltaTime);
    }

    private void LerpSunIntensity (Light light, float intensity)
    {
        light.intensity = Mathf.Lerp (light.intensity, intensity, 0.2f * Time.deltaTime);
    }
}
