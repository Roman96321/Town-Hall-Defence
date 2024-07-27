using UnityEngine;
using Zenject;

public class PlayerStateMove : MonoBehaviour
{
    [Inject] private PlayerProperties _playerProperties;

    private int _playerSpeed;
    private int _playerRotateSpeed;

    private void Start()
    {
        _playerSpeed = _playerProperties.moveSpeed;
        _playerRotateSpeed = _playerProperties.rotateSpeed;
    }

    public void FalseMove()
    {
        _playerProperties.moveSpeed = default;
        _playerProperties.rotateSpeed = default; 
    }

    public void TrueMove()
    {
        _playerProperties.moveSpeed = _playerSpeed;
        _playerProperties.rotateSpeed = _playerRotateSpeed; 
    }

    private void OnApplicationQuit()
    {
        TrueMove();
    }
}