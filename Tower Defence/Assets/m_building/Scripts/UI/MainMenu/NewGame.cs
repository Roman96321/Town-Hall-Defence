using UnityEngine;

public class NewGame : MonoBehaviour
{
    public void DeleteData()
    {
        JsonSaveServise saveServise = new JsonSaveServise();

        saveServise.DeleteData(Json.BuildingUpgrade);  
        saveServise.DeleteData(Json.BarracksSoldier);
        saveServise.DeleteData(Json.ResourceCount);
        saveServise.DeleteData(Json.Wave);
    }
}
