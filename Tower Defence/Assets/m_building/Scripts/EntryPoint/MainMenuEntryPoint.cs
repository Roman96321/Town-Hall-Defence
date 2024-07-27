using System.Collections;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _loadingWindow;

    private float _vievLoadingWindow = 1;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_vievLoadingWindow);

        _loadingWindow.SetActive(false);
    }
}