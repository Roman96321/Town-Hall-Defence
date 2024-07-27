using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SearchObject))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointArrow;
    [SerializeField] private GameObject _bow;

    [Inject] private PlayerProperties _playerProperties;
    [Inject] private WaveStateHandler _waveState;
    
    private SearchObject _searchObject;
    private bool _isWait = true;

    private void Start()
    {
        _searchObject = GetComponent<SearchObject>();
    }

    public void Attack()
    {
        if (_waveState.waveActive == false)
            return;

        if (_isWait)
        {
            _isWait = false;

            GameObject arrow = Instantiate(_playerProperties.arrowPrefab, _spawnPointArrow.position, Quaternion.identity);
            SoldierArrow projectileScript = arrow.GetComponent<SoldierArrow>();

            projectileScript.Target = _searchObject.GetObject(_playerProperties.attackRange, Tag.Enemy);
            projectileScript.Damage = _playerProperties.damage;

            StartCoroutine(WaitAttack());
        }    
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(_playerProperties.attackSpeed);
        _isWait = true;
    }

    private void BowActive()
    {
        _bow.SetActive(_waveState.waveActive);
    }

    private void OnEnable()
    {
        _waveState.onWaveTrue += BowActive;
        _waveState.onWaveFalse += BowActive;
    }

    private void OnDisable()
    {
        _waveState.onWaveTrue -= BowActive;
        _waveState.onWaveFalse -= BowActive;
    }
}