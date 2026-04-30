using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float fadeDuration = 1.5f;

    private bool isTransitioning;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        fadeCanvasGroup.alpha = 0f;
        fadeCanvasGroup.blocksRaycasts = false;
    }

    public void LoadSceneWithFade(string sceneName)
    {
        if (!isTransitioning)
        {
            StartCoroutine(FadeAndLoad(sceneName));
        }
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        isTransitioning = true;

        fadeCanvasGroup.blocksRaycasts = true;

        // Fade Out: È­¸é ¾îµÎ¿öÁü
        yield return Fade(0f, 1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }

        // Fade In: È­¸é ´Ù½Ã ¹à¾ÆÁü
        yield return Fade(1f, 0f);

        fadeCanvasGroup.blocksRaycasts = false;
        isTransitioning = false;
    }

    private IEnumerator Fade(float from, float to)
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

            fadeCanvasGroup.alpha = Mathf.Lerp(from, to, t);

            yield return null;
        }

        fadeCanvasGroup.alpha = to;
    }
}