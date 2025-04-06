using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

/// <summary>
/// MVC 패턴일 때 View를 명확히 나누어놓음
/// MVP 패턴일 때는 로직을 모두 Presenter에서 전담함 (Model을 별개로 나누는 것이 중요함)
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
