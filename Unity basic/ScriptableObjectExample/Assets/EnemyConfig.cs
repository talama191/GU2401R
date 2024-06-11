using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "enemyInfo", menuName = "Infos/Enemy Info")]
public class EnemyConfig : ScriptableObject
{
    [Header("Visual")]
    [SerializeField] private Sprite icon;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private EnemyCharacter characterPrefab;
    [Header("Stats")]
    [SerializeField, Min(5)] private float maxHP;
    [SerializeField, Min(1)] private float movementSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float damage;
    [SerializeField] private AttackType attackType;
    [SerializeField] private bool isMelee;

    public Sprite Icon => icon;
    public float MaxHP => maxHP;
    public float MovementSpeed => movementSpeed;
    public AnimatorController AnimatorController => animatorController;
    public EnemyCharacter CharacterPrefab => characterPrefab;
}

public enum AttackType
{
    Physical,
    Magic
}
