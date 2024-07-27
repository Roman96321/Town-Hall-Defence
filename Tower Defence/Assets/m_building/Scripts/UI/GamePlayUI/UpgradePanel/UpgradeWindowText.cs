using TMPro;
using UnityEngine;

public class UpgradeWindowText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _treeText;
    [SerializeField] private TextMeshProUGUI _meatText;

    [SerializeField] private TextMeshProUGUI _buildingNameText;

    public void ShowUpgradeWindowText(int goldforUp, int treeforUp, float breadforUp, string buildingName)
    {
        _goldText.text = goldforUp.ToString();
        _treeText.text = treeforUp.ToString();
        _meatText.text = breadforUp.ToString();

        _buildingNameText.text = buildingName;
    }

    public int GetUpgradeResourceValue(ResourceType type)
    {
        switch (type)
        {
            case (ResourceType.Gold):
                return int.Parse(_goldText.text);

            case (ResourceType.Tree):
                return int.Parse(_treeText.text);

            case (ResourceType.Meat):
                return int.Parse(_meatText.text);

            default:
                return default;
        }
    }
}