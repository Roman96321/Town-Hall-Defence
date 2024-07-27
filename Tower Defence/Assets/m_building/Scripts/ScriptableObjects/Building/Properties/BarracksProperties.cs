using UnityEngine;

[CreateAssetMenu(menuName = "Properties/Building/StandartProperties/BarracksProperties", fileName = "BarracksProperties")]
public class BarracksProperties : BuildingProperties
{
    public int[] soldierCount;

    public GameObject archer;
    public GameObject knight;   
}
