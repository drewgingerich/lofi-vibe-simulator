using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
	[SerializeField]
	private List<SpriteRenderer> ambientShadows;
	private SpriteRenderer lampShadow;

	private bool on = false;

	public void Toggle()
	{
		on = !on;
		foreach (SpriteRenderer renderer in ambientShadows)
		{
			renderer.enabled = !on;
		}
		lampShadow.enabled = on;
	}
}
