using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
	[SerializeField]
	private float maxY = 1;
	[SerializeField]
	private float minY = -10;
	[SerializeField]
	private float speed = 1;

	private float targetY;

	private IEnumerator Start()
	{
		while (true)
		{
			float moveDistance = speed * Time.deltaTime;
			transform.Translate(Vector3.down * moveDistance, Space.World);

			if (transform.localPosition.y <= minY)
			{
				Vector3 position = transform.localPosition;
				position.y = maxY;
				transform.localPosition = position;
				transform.Rotate(new Vector3(0, 0, 180), Space.World);
			}
			yield return null;
		}
	}

	private IEnumerator Move(float targetY)
	{
		while (true)
		{
			float targetDistance = targetY - transform.localPosition.y;
			float moveDistance = speed * Time.deltaTime;

			if (moveDistance >= Mathf.Abs(targetDistance)) yield break;

			Vector3 direction = (Vector3.up * targetDistance).normalized;
			transform.Translate(direction * moveDistance, Space.World);

			yield return null;
		}
	}
}
