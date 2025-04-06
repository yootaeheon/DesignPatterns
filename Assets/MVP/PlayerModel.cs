using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] int _hp;
    public int HP { get { return _hp; } set { _hp = value; OnHPChanged?.Invoke(_hp); } }
    public UnityAction<int> OnHPChanged { get; set; }

    [SerializeField] int _maxHP;
    public int MaxHP { get { return _maxHP; } }
}
