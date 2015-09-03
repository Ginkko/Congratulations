using UnityEngine;
using System.Collections;

public class levetate : MonoBehaviour {
	public float hoverSpeed;
	public float pulseSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 updatePosition = transform.position;
		updatePosition.y += Mathf.Sin (Time.time * hoverSpeed) * Time.deltaTime;
		transform.position = updatePosition;

		Vector3 updateSize = transform.localScale;
		float value = Mathf.Sin (Time.time * pulseSpeed) * Time.deltaTime * .005f;
		updateSize += new Vector3 (value, value, value);
		transform.localScale = updateSize;
	}
}
