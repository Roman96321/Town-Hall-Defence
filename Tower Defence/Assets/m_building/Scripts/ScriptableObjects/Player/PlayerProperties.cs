using UnityEngine;

[CreateAssetMenu(menuName = "Properties/Player", fileName = "Player")]
public class PlayerProperties : ScriptableObject
{
    public int health;
    public int moveSpeed;
    public int rotateSpeed;
    public int recoveryHealth;
    public float attackSpeed;
    public int damage;
    public int attackRange;
    public GameObject arrowPrefab;
}