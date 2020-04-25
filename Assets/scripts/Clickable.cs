using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer highlightTarget;
	[SerializeField]
	private Color highlightColor;
	[SerializeField]
	private UnityEvent onClick;

	private Color originalColor;

	private void Start()
	{
		originalColor = highlightTarget.color;
	}

	public void Hover()
	{
		highlightTarget.color = highlightColor;
	}

	public void DeHover()
	{
		highlightTarget.color = originalColor;
	}

	public void Click()
	{
		onClick.Invoke();
	}
}