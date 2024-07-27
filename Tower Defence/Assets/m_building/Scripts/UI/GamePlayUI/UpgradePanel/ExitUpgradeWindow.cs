using UnityEngine;
using Zenject;

public class ExitUpgradeWindow : MonoBehaviour
{
    [Inject] private PlayerStateMove _stateMove;
    [Inject] private UpgradeWindow _upgradeWindow;

    public void Exit()
    {
        _upgradeWindow.gameObject.SetActive(false);
        _stateMove.TrueMove();
    }
}
