using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ClickableIteractor : MonoBehaviour
{
	private new Camera camera;

	private Clickable currentClickable;

	void Start()
	{
		camera = GetComponent<Camera>();
	}

	void Update()
	{
		Vector2 pos = camera.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

		if (hit.collider == null && currentClickable != null)
		{
			currentClickable.DeHover();
			currentClickable = null;
		}

		if (hit.collider == null) return;

		Clickable clickable = hit.collider.GetComponent<Clickable>();


		if (clickable != currentClickable)
		{
			clickable.Hover();
			currentClickable = clickable;
		}

		if (Input.GetMouseButtonDown(0))
		{
			clickable.Click();
		}
	}
}
