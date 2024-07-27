using TMPro;
using UnityEngine;
using Zenject;

public class ResourcesText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _treeText;
    [SerializeField] private TextMeshProUGUI _meatText;

    [Inject] private ResourceFeatures resourceFeatures; 

    private void Start()
    {
        resourceFeatures.SpendResource(ResourceType.Gold, default);
        resourceFeatures.SpendResource(ResourceType.Tree, default);
        resourceFeatures.SpendResource(ResourceType.Meat, default);
    }

    private void ChangedText(ResourceType type, int value)
    {
        switch (type)
        {
            case ResourceType.Gold:
                _goldText.text = value.ToString();
                break;

            case ResourceType.Tree:
                _treeText.text = value.ToString();
                break;

            case ResourceType.Meat:
                _meatText.text = value.ToString();
                break;

            default:
                break;
        }
    }

    private void OnEnable()
    {
        resourceFeatures.onChanged += ChangedText;
    }

    private void OnDisable()
    {
        resourceFeatures.onChanged -= ChangedText;
    }
}