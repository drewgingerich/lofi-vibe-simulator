using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer titleScreen;
	[SerializeField]
	private float waitTime = 2f;
	[SerializeField]
	private float fadeSpeed = 1f;
	// [SerializeField]
	// private ScreenFade fader;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(SwitchScene());
	}

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			StartCoroutine(SwitchScene());
		}
	}

	private IEnumerator SwitchScene()
	{
		while (true)
		{
			Color color = titleScreen.color;
			color.a -= Time.deltaTime * fadeSpeed;
			titleScreen.color = color;
			yield return null;
		}
	}
}
