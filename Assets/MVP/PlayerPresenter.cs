using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class PlayerPresenter : MonoBehaviour
{
    [Header("UI")]
    private StringBuilder _sb = new StringBuilder();

    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] Slider _hpSlider;

    [Header("Model")]
    [SerializeField] PlayerModel _model;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _model.HP += 10;
        }
    }

    //�� region�� View Class�� �и��� �Ǹ� MVC�̸� Presenter�� ������ MVP�� (MVP�� View�� Controller�� �Ѱ��� �� ����)
    #region 
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
        _hpSlider.maxValue = _model.MaxHP;
    }

    private void UpdateHP(int hp)
    {
        _sb.Clear();
        _sb.Append(hp);
        _hpText.SetText(_sb);
        _hpSlider.value = hp;
    }
}
#endregion