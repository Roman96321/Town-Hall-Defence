using Zenject;

public class ResourceFeaturesInstaller : MonoInstaller
{
    private ResourceFeatures _resoucesFeatures;

    public override void InstallBindings()
    {
        var goldResource = new Resource(ResourceType.Gold);
        var treeResource = new Resource(ResourceType.Tree);
        var breadResource = new Resource(ResourceType.Meat);

        var resources = new[] { goldResource, treeResource, breadResource };
        _resoucesFeatures = new ResourceFeatures(resources);

        Container.Bind<ResourceFeatures>().FromInstance(_resoucesFeatures).AsSingle().NonLazy();
    }
}