using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffectCanvas : MonoBehaviour
{
    public static FadeEffectCanvas instance;
    public Image bgImage;
    public float fadeDuration = 1.0f;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // 시작할 때 검은 상태로 시작
        bgImage.color = new Color(0, 0, 0, 1);

        // 자동으로 Fade In 실행
        StartCoroutine(FadeTo(0.0f, fadeDuration));
    }

    public void StartEffect(System.Action completeFadeOutCallback)
    {
        StartCoroutine(CoEffect(completeFadeOutCallback));
    }

    IEnumerator CoEffect(System.Action completeFadeOutCallback)
    {
        // Fade Out (어두워짐)
        yield return StartCoroutine(FadeTo(1.0f, fadeDuration));

        completeFadeOutCallback?.Invoke();

        // Fade In (밝아짐)
        yield return StartCoroutine(FadeTo(0.0f, fadeDuration));
    }

    IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = bgImage.color.a;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);

            bgImage.color = new Color(0, 0, 0, newAlpha); // 🔥 검은색으로 수정

            yield return null;
        }

        bgImage.color = new Color(0, 0, 0, targetAlpha);
    }
}