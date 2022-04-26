using UnityEngine;
using Utils.Serialisation;
using CityEngine.Simulation;

public class GameSaveLoad : MonoBehaviour
{
    void FileSaveGame(string file="gamedata.ini")
    {
        // Create an isntance of the ini parser
        IniStorage saveManager = new IniStorage();

        // Set the file
        saveManager.path = file;

        // Write data

        // Building count
        int count = GameObject.FindGameObjectsWithTag("Building").Length;
        saveManager.set("meta_object_count", $"{count}");

        // Resources
        saveManager.set("resource_food", $"{City.inst.curFood}");
        saveManager.set("resource_money", $"{City.inst.money}");
        saveManager.set("resource_jobs", $"{City.inst.curJobs}");
        saveManager.set("resource_population", $"{City.inst.curPopulation}");

        // Current day
        saveManager.set("misc_day", $"{TimeProgression.GetCurrentDay()}");

        // store all the buildings
        var objects = GameObject.FindGameObjectsWithTag("Building");
        var objectCount = objects.Length;
        foreach (var obj in objects) {
            var i = obj;
            // Write x
            saveManager.set($"obj_{i}_x", $"{obj.transform.position.x}");

            // Write y
            saveManager.set($"obj_{i}_x", $"{obj.transform.position.y}");

            // Write Z
            saveManager.set($"obj_{i}_x", $"{obj.transform.position.z}");
            
            // Write prefab name
            saveManager.set($"obj_{i}_x", $"{obj.name}");
        }

        Debug.Log(saveManager.get("test"));
    }
}
