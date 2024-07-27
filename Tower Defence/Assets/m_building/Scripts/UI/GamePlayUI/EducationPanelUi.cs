using UnityEngine;

public class EducationPanelUi : MonoBehaviour
{
    private void Awake()
    {
        JsonSaveServise json = new JsonSaveServise();

        if (json.Load(Json.BuildingUpgrade) == null)
            transform.GetChild(default).gameObject.SetActive(true);
    }
}
