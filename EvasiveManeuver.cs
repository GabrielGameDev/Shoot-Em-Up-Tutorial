using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

	public float dodge;
	public float speed;
	public Boundary boundary;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	

	private Rigidbody2D rb;
	private float target;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(Evade());

	}

	private void FixedUpdate()
	{
		float newManeuver = Mathf.MoveTowards(rb.velocity.x, target, speed);
		rb.velocity = new Vector2(newManeuver, rb.velocity.y);

		rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));

	}

	IEnumerator Evade()
	{
		yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
		while (true)
		{
			target = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
			yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
			target = 0;
			yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
		}
	}
}
