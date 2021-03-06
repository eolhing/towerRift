﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public Transform source;
	public Transform destination;
	public float duration;

	private float clock = 0f;

	void Start ()
	{
	}
	
	/// <summary>
	/// Called each frame, move to the destination
	/// </summary>
	void Update()
	{
		clock += Time.deltaTime;

		if(clock >= duration)
		{
			if(destination != null)
			{
				if(destination.GetComponent<Crystal>())
				{
					Destroy(gameObject);
					destination.GetComponent<Crystal>().hit(10f);
				}
				if(destination.GetComponent<Enemy>())
				{	
					Destroy(gameObject);
					destination.GetComponent<Enemy>().hit();
				}
			}

			Destroy(gameObject);
		}
		else
		{
			if(destination != null)
				transform.position = Vector3.Lerp(source.position, destination.position, clock / duration);
			else
				Destroy(gameObject);
		}
	}
}
