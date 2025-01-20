using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameBehaviour : MonoBehaviour
{
    [SerializeField]
    private Material _endVfxMat;
    private PlayerHealthFeedbackBehaviour _healthFeedbackBehaviour;
    private Image _endPanel;
    private RectTransform _endRect;
    private TextMeshProUGUI _finalWinnerDisplay;
    private static bool _endGame;

    private void Start()
    {
        _endPanel = PlayerManager.Instance.EndGamePanel;
        _endRect = _endPanel.GetComponent<RectTransform>();
        _endGame = false;

        _healthFeedbackBehaviour = GetComponent<PlayerHealthFeedbackBehaviour>();
        _finalWinnerDisplay = _endPanel.GetComponentInChildren<TextMeshProUGUI>();
        _healthFeedbackBehaviour.OnGameFinished += EndGame;

        _endPanel.gameObject.SetActive(false);
    }

    public void EndGame(int id)
    {

        if (!_endGame)
        {
            _endGame = true;
            _endVfxMat.color = Color.clear;
            Time.timeScale = 1f;
            _endPanel.gameObject.SetActive(true);
            _endPanel.transform.DOBlendableLocalMoveBy(Vector3.zero, 1.25f).SetUpdate(true).onComplete += () =>
            {
                _endRect.DOBlendableScaleBy(Vector3.one, 0.5f).SetEase(Ease.OutBounce).SetUpdate(true);
                switch (id)
                {
                    case 0:
                        _endPanel.color = PlayerManager.Instance.PlayerColors[1];
                        _finalWinnerDisplay.text = "Blue player won !";
                        _endVfxMat.color = Color.blue;
                        break;
                    case 1:
                        _endPanel.color = PlayerManager.Instance.PlayerColors[0];
                        _finalWinnerDisplay.text = "Red player won !";
                        _endVfxMat.color = Color.red;
                        break;
                }

                PlayerManager.Instance.enabled = false;
            };
        }
    }
}
