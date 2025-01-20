using UnityEngine;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private RectTransform bird;        
    [SerializeField] private RectTransform getReadyButton; // 버튼 

    private void Start()
    {
        AnimateBird();
        // AnimateTitle();
        AnimateButton();
    }

    private void AnimateBird()
    {
        // 새가 위아래로 부드럽게 움직이도록 설정
        float startY = bird.anchoredPosition.y;
        bird.DOAnchorPosY(startY + 90f, 0.8f) // RectTransform용 DOAnchorPosY
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    private void AnimateButton()
    {
        // 버튼 크기 변화
        getReadyButton.DOScale(Vector3.one * 1.5f, 1f) // RectTransform 사용
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
