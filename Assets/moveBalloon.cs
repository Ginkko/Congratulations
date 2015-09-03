using UnityEngine;
using System.Collections;

public class moveBalloon : MonoBehaviour {
	public bool start;
	public float speed;
	private float startTime;
	private float journeyLength;
	public Transform startMarker;
	public Transform endMarker;

	// Use this for initialization
	void Start () {
		journeyLength = Vector3.Distance (startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (start)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);

			if (transform.position == endMarker.position)
			{
				start = false;
			}

		}

	}
	public void StartMove() 
	{
		start = true;
		startTime = Time.time;
	}

}
