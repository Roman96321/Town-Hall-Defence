using UnityEngine;

[CreateAssetMenu(menuName = "Properties/Building/UpgradeProperties", fileName = "UpgradeProperties")]
public class BuildingUpgradeProperties : ScriptableObject
{
    public string[] buildingName;
    public int[] goldForUp;
    public int[] treeForUp;
    public int[] eatForUp;
    public int maxUp;

    public string BuildingName {get {return buildingName[PlayerPrefs.GetInt(Prefs.Language)];}}
}