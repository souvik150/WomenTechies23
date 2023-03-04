using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

// This script makes the score popup and animate when you score points
// Uses Dotween
public class ScorePopup : MonoBehaviour
{
    [Header("Fade Time")]
    // Time to finish the start and end animations
    public float fadeInTime;
    public float fadeOutTime;

    [Header("Movement")]
    // move the rect on the Y axis
    public float displacementY;


    private TMP_Text scoreText;
    private RectTransform rectTransform;
    private Vector2 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
        scoreText.alpha = 0f;
        rectTransform = gameObject.GetComponent<RectTransform>();

        startPosition = rectTransform.transform.localPosition;
    }

    // Pops up the text
    public void PopUpText()
    {
        //scoreText.enabled = true;
        scoreText.alpha = 1f;
        rectTransform.transform.localScale = new Vector3(0, 0, 1);
        rectTransform.transform.localPosition = startPosition;
        Vector2 displacementVector = new Vector2(rectTransform.transform.localPosition.x, rectTransform.transform.localPosition.y + displacementY);
        rectTransform.DOAnchorPos(displacementVector, fadeInTime, false).SetEase(Ease.InElastic);
        rectTransform.DOScale(new Vector2(1, 1), fadeInTime);

        StartCoroutine("FadeOutText");
    }
    public void FadeOutText()
    {
        scoreText.alpha = 1f;
        scoreText.DOFade(0, fadeOutTime);

        //scoreText.enabled = false;

    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(fadeInTime + 1);
        FadeOutText();
    }
}
