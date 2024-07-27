using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Properties/Wave", fileName = "Wave")]
public class WaveProperties : ScriptableObject
{
    [Serializable]
    public struct SpawnPoint
    {
        public int point;
        public int archerCount;
        public int knightCount;
        public int giantCount;
        public int infiltratorCount;
        public float timeToNextSpawn;
    }

    [Serializable]
    public struct Stage
    {
        public int[] enemyCount;
        public SpawnPoint[] spawnPoints;
    }

    public Stage stage;
}