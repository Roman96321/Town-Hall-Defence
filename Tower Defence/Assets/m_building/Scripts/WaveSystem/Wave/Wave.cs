using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaveStateHandler), typeof(EnemyFactory))]
public class Wave : MonoBehaviour
{
    [SerializeField] private WaveProperties[] _waveProperties;

    private List<GameObject> _allSpawnedEnemy = new List<GameObject>();
    private WaveStateHandler _waveState;
    private EnemyFactory _enemyFactory;

    public WaveProperties[] WaveProperties {get {return _waveProperties;}}

    private void Awake()
    {
        _waveState = GetComponent<WaveStateHandler>();
        _enemyFactory = GetComponent<EnemyFactory>();
    }

    private void WaveActive()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaveProperties currentWave = _waveProperties[_waveState.nowWave];

        yield return StartCoroutine(Stages(currentWave.stage));

        _waveState.WaveIsFalse();
    }

    private IEnumerator Stages(WaveProperties.Stage stage)
    {
        for (int i = 0; i < stage.spawnPoints.Length; i++)
        {
            var spawnPoint = stage.spawnPoints[i];

            var archers = _enemyFactory.Create(EnemyValue.Archer, spawnPoint.point, spawnPoint.archerCount);
            _allSpawnedEnemy.AddRange(archers);

            var knights = _enemyFactory.Create(EnemyValue.Knight, spawnPoint.point, spawnPoint.knightCount);
            _allSpawnedEnemy.AddRange(knights);

            var giants = _enemyFactory.Create(EnemyValue.Guiant, spawnPoint.point, spawnPoint.giantCount);
            _allSpawnedEnemy.AddRange(giants);

            var infiltrators = _enemyFactory.Create(EnemyValue.Infiltrator, spawnPoint.point, spawnPoint.infiltratorCount);
            _allSpawnedEnemy.AddRange(infiltrators);

            yield return new WaitForSeconds(spawnPoint.timeToNextSpawn);
        }

        yield return StartCoroutine(CheckDeadEnemy());
    }

    private IEnumerator CheckDeadEnemy()
    {
        yield return new WaitForSeconds(2);

        foreach (var enemy in _allSpawnedEnemy)
        {
            if (enemy != null)
            {
                yield return StartCoroutine(CheckDeadEnemy());
                break;
            }
        }
    }

    private void OnEnable()
    {
        _waveState.onWaveTrue += WaveActive;
    }

    private void OnDisable()
    {
        _waveState.onWaveTrue -= WaveActive;
    }
}