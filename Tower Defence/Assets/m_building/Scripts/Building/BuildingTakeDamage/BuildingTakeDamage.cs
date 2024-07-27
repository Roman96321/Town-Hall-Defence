using UnityEngine;

public class BuildingTakeDamage : MonoBehaviour
{
    [SerializeField] private BuildingHealth[] _buildingHealths;

    private void Awake()
    {
        _buildingHealths = new BuildingHealth[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _buildingHealths[i] = transform.GetChild(i).GetComponent<BuildingHealth>();
    }

    public void TakeDamages(string buildingName, float damage)
    {
        int buildingValue;

        try
        {
            buildingValue = int.Parse(buildingName.Substring(0, 2));
        }
        catch (System.Exception)
        {
            buildingValue = (int)(char.GetNumericValue(buildingName[0]));
        }

        _buildingHealths[buildingValue].TakeDamage(damage);
    }
}