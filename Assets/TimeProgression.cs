using UnityEngine;
using System.Collections;

namespace CityEngine.Simulation
{
    public class TimeProgression : MonoBehaviour {
        static float sec, min, hour, day = 0f;

        public static float timeMultiplyer = 1440f;

        // Use this for initialization
        void Start () {
            hour = 12f;
        }
        
        // Update is called once per fram
        void Update () {
            sec += Time.deltaTime * timeMultiplyer;
            if (sec >= 60) {
                min++;
                sec = 0;
            }
            if (min >= 60) {
                hour++;
                min = 0;
            }
            if (hour >= 24) {
                day++;
                hour = 0;
            }
            print($"Current Day {day} Sec {sec} Min {min} Hour {hour}");
        }

        public static float GetCurrentDay() => day;

        public static float GetCurrentHour() => hour;

        public static string GetTimeAsString() => $"Hour: {hour} Day {day}"; // Second: {Mathf.Round(sec)}

        public static float GetSecondsInDayGone() => (hour * 3600) + (min * 60) + sec; // Return seconds of day gone
    }
}