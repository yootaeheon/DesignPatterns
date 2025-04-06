using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

/// <summary>
/// MVC ������ �� View�� ��Ȯ�� ���������
/// MVP ������ ���� ������ ��� Presenter���� ������ (Model�� ������ ������ ���� �߿���)
/// </summary>
public class PlayerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] PlayerModel _model;

    private StringBuilder _sb = new StringBuilder();

    private void OnEnable()
    {
        _model.OnHPChanged += UpdateHP;
    }

    private void OnDisable()
    {
        _model.OnHPChanged -= UpdateHP;
    }

    private void Start()
    {
        UpdateHP(_model.HP);
    }

    private void UpdateHP(int hp)
    {
        _sb.Clear();
        _sb.Append(hp);
        _hpText.SetText(_sb);
    }
}
