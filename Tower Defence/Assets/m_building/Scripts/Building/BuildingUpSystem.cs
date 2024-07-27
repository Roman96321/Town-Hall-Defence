using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ColliderManipulate))]
public class BuildingUpgradeSystem : MonoBehaviour
{
    public Action onUpgrade;

    [SerializeField] private BuildingUpgradeProperties _upProperties;

    [Inject] private UpgradeWindow _upgradeWindow;
    [Inject] private PlayerStateMove _stateMove;    
    
    private ColliderManipulate _colliderManipulate;
    private GameObject _FirstUpgrade;
    private GameObject _point;

    public string BuildingName {get {return _upProperties.BuildingName;}}
    public int[] GoldForUp {get {return _upProperties.goldForUp;}}
    public int[] TreeForUp {get {return _upProperties.treeForUp;}}
    public int[] EatForUp {get {return _upProperties.eatForUp;}}
    public int MaxUp {get {return _upProperties.maxUp;}}
    public bool ImTownHall {get; private set;}
    public int NowUp {get; set;} 

    private void Awake()
    {
        _colliderManipulate = GetComponent<ColliderManipulate>();
        _FirstUpgrade = transform.GetChild(default).gameObject;
        _point = transform.GetChild(1).gameObject;         
    }

    private void Start()
    {
        if (gameObject.GetComponent<TownHall>())
        {
            ImTownHall = true;
            NowUp = 1;
        }

        if (NowUp != default)
        {
            int upCount = NowUp;
            NowUp = default;

            for (int i = 0; i < upCount; i++)
                UpgradeIsTrue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag.Player))
        {
            if (TownHall.nowUp > NowUp || ImTownHall)
            {
                if (NowUp < MaxUp)
                {
                    _upgradeWindow.building = gameObject.GetComponent<BuildingUpgradeSystem>();
                    _upgradeWindow.gameObject.SetActive(true);
                    _stateMove.FalseMove();
                }
            }
        }
    }

    public void UpgradeIsTrue()
    {
        if (NowUp == 0)
        {
            _FirstUpgrade.SetActive(true);
            _colliderManipulate.ReSize();
            _point.SetActive(false);
            NowUp++;

            onUpgrade?.Invoke();
            return;
        }

        _FirstUpgrade.transform.GetChild(NowUp - 1).gameObject.SetActive(true);
        NowUp++;    

        if (ImTownHall)
            TownHall.nowUp++;

        onUpgrade?.Invoke();
    }    
}