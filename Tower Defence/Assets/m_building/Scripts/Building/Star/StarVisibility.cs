using System.Collections.Generic;
using UnityEngine;

public class StarVisibility : MonoBehaviour
{
    private List<MeshRenderer> _stars = new List<MeshRenderer>();

    private void Start()
    {
        GetStars();
    }

    private void GetStars()
    {
        GameObject[] building = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            building[i] = transform.GetChild(i).gameObject;       

        for (int i = 0; i < building.Length; i++)
        {
            if (building[i].transform.GetChild(0).transform.childCount >= 3)
            {
                for (int a = 0; a < building[a].transform.GetChild(default).transform.childCount; a++)
                    _stars.Add(building[i].transform.GetChild(default).transform.GetChild(a).gameObject.GetComponent<MeshRenderer>());
            }
        }
    }

    public void ActiveStar()
    {
        for (int i = 0; i < _stars.Count; i++)
            _stars[i].enabled = !_stars[i].enabled;
    }
}