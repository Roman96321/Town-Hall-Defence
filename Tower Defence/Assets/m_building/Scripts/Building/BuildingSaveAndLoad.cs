using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSaveAndLoad : MonoBehaviour
{
    [SerializeField] private BarracksSoldierController[] _barracks;

    private List<BuildingUpgradeSystem> buildings = new List<BuildingUpgradeSystem>();
    private BarracksSoldierType soldierType = new BarracksSoldierType();
    private JsonSaveServise saveServise = new JsonSaveServise();   
    private BuildingsList buildingList = new BuildingsList();
    
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            buildings.Add(transform.GetChild(i).GetComponent<BuildingUpgradeSystem>());

        Load();
    }

    public void Save()
    {
        List<int> buildingNowUpgrade = new List<int>();
        List<string> soldierTypeList = new List<string>();
        List<int> soldierCountList = new List<int>();

        for (int i = 0; i < buildings.Count; i++)
            buildingNowUpgrade.Add(buildings[i].NowUp);

        buildingList.list = buildingNowUpgrade;   
        saveServise.Save(Json.BuildingUpgrade, buildingList);

        for (int i = 0; i < _barracks.Length; i++)
        {
            soldierTypeList.Add(_barracks[i].SoldierType);
            soldierCountList.Add(_barracks[i].SoldierCount);
        }

        soldierType.type = soldierTypeList;
        soldierType.count = soldierCountList;
        saveServise.Save(Json.BarracksSoldier, soldierType);
    }

    public void Load()
    {
        BarracksSoldierType soldierType = JsonUtility.FromJson<BarracksSoldierType>(saveServise.Load(Json.BarracksSoldier));
        BuildingsList buildingUplist = JsonUtility.FromJson<BuildingsList>(saveServise.Load(Json.BuildingUpgrade));      

        if (buildingUplist == null)
            return;

        for (int i = 0; i < buildings.Count; i++)
            buildings[i].NowUp = buildingUplist.list[i];

        for (int i = 0; i < soldierType.type.Count; i++)
        {
            _barracks[i].SoldierType = soldierType.type[i];
            _barracks[i].SoldierCount = soldierType.count[i];
        }           
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}

[Serializable]
public class BarracksSoldierType
{
    public List<string> type;
    public List<int> count;
}

[Serializable]
public class BuildingsList
{
    public List<int> list;
}