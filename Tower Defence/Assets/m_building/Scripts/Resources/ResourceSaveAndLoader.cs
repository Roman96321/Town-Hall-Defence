using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ResourceSaveAndLoader : MonoBehaviour
{
    [Inject] private ResourceFeatures _resource;

    private JsonSaveServise _jsonSaveServise = new JsonSaveServise();
    private ResourceCount _resourceCount = new ResourceCount();

    private int startGold = 50;
    private int startTree = 26;
    private int startMeat = 18;

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        List<int> resourceList = new List<int>();

        resourceList.Add(_resource.GetResource(ResourceType.Gold));
        resourceList.Add(_resource.GetResource(ResourceType.Tree));
        resourceList.Add(_resource.GetResource(ResourceType.Meat));

        _resourceCount.count = resourceList;

        _jsonSaveServise.Save(Json.ResourceCount, _resourceCount);
    }

    public void Load()
    {
        ResourceCount resource = JsonUtility.FromJson<ResourceCount>(_jsonSaveServise.Load(Json.ResourceCount));

        if (resource == null)
        {
            _resource.AddResource(ResourceType.Gold, startGold);
            _resource.AddResource(ResourceType.Tree, startTree);
            _resource.AddResource(ResourceType.Meat, startMeat);
            return;
        }

        _resource.AddResource(ResourceType.Gold, resource.count[0]);
        _resource.AddResource(ResourceType.Tree, resource.count[1]);
        _resource.AddResource(ResourceType.Meat, resource.count[2]);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}


[Serializable]
public class ResourceCount
{
    public List<int> count;
}