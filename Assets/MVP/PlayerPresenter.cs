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

    //이 region이 View Class로 분리가 되면 MVC이며 Presenter에 있으면 MVP임 (MVP는 View와 Controller가 한개일 수 있음)
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