using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour {
	Player player;
	Rigidbody2D rb;

	public GameObject shineParticle1;
	public GameObject shineParticle2;
	public GameObject damageParticle1;
	public GameObject damageParticle2;

	// Use this for initialization
	void Start () {
		player = player = GameObject.Find("Player").GetComponent<Player> ();
		rb = player.GetComponent<Rigidbody2D> ();
	}

	public void BadParticles () {
		Instantiate(damageParticle1, new Vector3(rb.position.x, -7.0f, rb.position.y), rb.transform.rotation);
		Instantiate(damageParticle2, new Vector3(rb.position.x, -7.0f, rb.position.y), rb.transform.rotation);
	}

	public void GoodParticles () {
		Instantiate(damageParticle1, new Vector3(rb.position.x, -7.0f, rb.position.y), rb.transform.rotation);
		Instantiate(damageParticle2, new Vector3(rb.position.x, -7.0f, rb.position.y), rb.transform.rotation);
	}
}
