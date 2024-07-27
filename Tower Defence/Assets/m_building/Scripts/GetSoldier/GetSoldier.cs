using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSoldier : MonoBehaviour
{
    [SerializeField] private StateButton _stateButton;

    private List<Soldier> _soldiers = new List<Soldier>();
    private bool _buttonState = false;
    private float _maxSoldier = 10;
    private float _radius = 2.5f;

    public void TouchButton()
    {
        _buttonState = !_buttonState;

        if (_buttonState)
            StartCoroutine(GetSoldierObject());
        else
            StartCoroutine(MoveToMe());
    }

    private IEnumerator GetSoldierObject()
    {
        yield return new WaitForSeconds(0.2f);

        Collider[] allObjects = Physics.OverlapSphere(transform.position, 3);

        if (_soldiers.Count > _maxSoldier)
            yield break;

        foreach (var objects in allObjects)
        {
            if (objects.CompareTag(Tag.Soldier))
            {
                for (int i = 0; i < _soldiers.Count; i++)
                {
                    if (_soldiers[i] == objects.GetComponent<Soldier>())
                        _soldiers.Remove(_soldiers[i]);
                }

                if (_soldiers.Count == _maxSoldier)
                    yield break;

                _soldiers.Add(objects.GetComponent<Soldier>());
                LabelActive(objects.transform, true);
                _stateButton.ChangeSoldierCount(_soldiers.Count);
            }
        }

        if (_buttonState == true)
            StartCoroutine(GetSoldierObject());
    }

    private IEnumerator MoveToMe()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < _soldiers.Count; i++)
        {
            LabelActive(_soldiers[i].transform, false);

            Vector3 origin = transform.position;

            float randomX = Random.Range(-_radius, _radius);
            float randomZ = Random.Range(-_radius, _radius);

            _soldiers[i].SetPosition(new Vector3(origin.x + randomX, origin.y, origin.z + randomZ));
        }        
        _soldiers.Clear();
    }

    private void LabelActive(Transform soldier, bool labelState)
    {
        soldier.GetChild(1).gameObject.SetActive(labelState);
    }
}