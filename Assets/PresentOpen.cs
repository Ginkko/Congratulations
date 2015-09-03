using UnityEngine;
using System.Collections;

public class PresentOpen : MonoBehaviour {
	
	float smooth = 2.0f;
	float doorOpenAngle = -90.0f;
	float doorCloseAngle = 0.0f;
	bool isOpen = false;
	bool opened = false;
	Transform startingRotation;
	public ParticleSystem confetti;
	public ParticleSystem confetti2;
	public GameObject explosion;
	public GameObject congrats;
	public GameObject balloon;
	public AudioClip birthday;
	AudioSource audio;
	private float timer;
	private float soundTimer;
	
	// Use this for initialization
	void Start ()
	{
		timer = 0;
		soundTimer = 0;
		startingRotation = transform;
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if (Input.GetKeyDown ("space")) {
			isOpen = !isOpen;
			Debug.Log ("isOpen = " + isOpen);

			if (isOpen) {
				confetti.emissionRate = 75f;
				confetti2.emissionRate = 75f;
				congrats.SetActive(true);
				balloon.GetComponent<moveBalloon>().StartMove ();
				if (!opened)
				{
					audio.PlayOneShot(birthday, 1f);
					opened = true;
					Debug.Log("opened = " + opened);
					timer = 0;
					explosion.GetComponent<ExplosionMat>()._alpha = 1;

				}
			}
			else 
			{
				confetti.emissionRate = 0f;
				confetti2.emissionRate = 0f;
				explosion.SetActive (false);
			}




		}

		if (timer > 10) {
			opened = false;
			Debug.Log("Opened = " + opened);
			timer = 0;
			soundTimer = 0;
			explosion.SetActive (false);
			explosion.GetComponent<ExplosionMat>()._alpha = 1;
		}

		if (timer > .5)
		{
//			Debug.Log("timer triggered");
			if (explosion.GetComponent<ExplosionMat>()._alpha >= 0)
			{

			explosion.GetComponent<ExplosionMat>()._alpha -= Time.deltaTime * .7f;
//			Debug.Log (explosion.GetComponent<ExplosionMat>()._alpha);
			}

			else
			{
				explosion.GetComponent<ExplosionMat>()._alpha = 0;
			}

		}

		if(isOpen) { 
			var target = Quaternion.Euler (startingRotation.eulerAngles.x, startingRotation.eulerAngles.y, doorOpenAngle);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			soundTimer += Time.deltaTime;
			if (soundTimer > .6 && opened)
			{
				explosion.SetActive (true);
			}

		}
		else {
			var target1 = Quaternion.Euler (startingRotation.eulerAngles.x, startingRotation.eulerAngles.y, doorCloseAngle);
			transform.rotation = Quaternion.Slerp(transform.rotation, target1, Time.deltaTime * smooth);
		}
	}
}
