using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShatterMain : MonoBehaviour {

	// Use this for initialization
	[System.Serializable]
	public class LLevel
	{
		public string name;
		public int levelnum = 0;
		public GameObject levelobjs;
	}

	public GameObject player;

	public Transform origloc;

	public float walkingspeed = 0;

	public string[] questions;
	public string[] answer1;
	public string[] answer2;
	public string[] answer3;
	public string[] answer4;

	public GameObject[] answers;
	public int[] cans;
	public int canswer;
	
	public GameObject qtext;

	public GameObject scorego;
	public LLevel[] levels;

	public int clevel;

	public int score;

	public int scoremax;

	public bool youwin = false;

	public bool youwin1 = false;

	public GameObject badge2;
	public GameObject badge;

	public Transform maincamtrans;

	void Start () {
		clevel = 0;
		foreach(LLevel level in levels)
		{
			if(level.levelnum != 0)
			{
				level.levelobjs.SetActive(false);
			}
			else
			{
				level.levelobjs.SetActive(true);
			}
		}
		int r = 0;
		r = Random.Range(0, questions.Length);
		qtext.GetComponent<Text>().text = questions[r];
		answers[0].GetComponent<Text>().text = answer1[r];
		answers[1].GetComponent<Text>().text = answer2[r];
		answers[2].GetComponent<Text>().text = answer3[r];
		answers[3].GetComponent<Text>().text = answer4[r];
		scorego.GetComponent<Text>().text = ("Score: " + score);
		
		canswer = cans[r];
	}

	public void Update()
	{
	//	walkingspeed = (Mathf.Sqrt(Mathf.Lerp(walkingspeed, Input.GetAxis("Vertical")**2+ Input.GetAxis("Horizontal")**2)));
		//player.GetComponent<
		if(clevel == 5)
		{
			Vector3 newvec;
			float xpos = player.transform.position.x;
			float ypos = player.transform.position.y;
			newvec = new Vector3 (xpos, ypos, -10);
			Camera.main.transform.position = newvec;
			if(youwin1 == true)
			{
				badge2.SetActive(true);
			}
		}
		else
		{
			Camera.main.transform.position = maincamtrans.position;
			if(youwin1 == true)
			{
				badge2.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	public void UpdateLevel (int nlevel) {
		player.transform.position = origloc.position;
		badge2.SetActive(false);
		youwin1 = false;
		foreach(LLevel level in levels)
		{
			
			if(nlevel != level.levelnum)
			{
				level.levelobjs.SetActive(false);
			}
			else
			{
				level.levelobjs.SetActive(true);
			}
		}
		clevel = nlevel;
		youwin = false;
	}

	public void GenQ ()
	{
		player.transform.position = origloc.position;
		badge2.SetActive(false);
		youwin1 = false;
		if(youwin == false)
		{
			int r = 0;
			r = Random.Range(0, questions.Length);
			qtext.GetComponent<Text>().text = questions[r];
			answers[0].GetComponent<Text>().text = answer1[r];
			answers[1].GetComponent<Text>().text = answer2[r];
			answers[2].GetComponent<Text>().text = answer3[r];
			answers[3].GetComponent<Text>().text = answer4[r];
			scorego.GetComponent<Text>().text = ("Score: " + score);
			canswer = cans[r];
			badge.SetActive(false);
			player.transform.position = origloc.position;
			
		}
		if(Mathf.Abs(score) > scoremax)
		{
			if(score < 0)
			{
				scorego.GetComponent<Text>().text = ("Try again next time");
				youwin = true;
				score = 0;
				badge.SetActive(false);
				qtext.GetComponent<Text>().text = "Sorry!";
				answers[0].GetComponent<Text>().text = "Try";
				answers[1].GetComponent<Text>().text = "again";
				answers[2].GetComponent<Text>().text = "time";
				answers[3].GetComponent<Text>().text = "next";
			}
			else
			{
				scorego.GetComponent<Text>().text = ("Good job! You win!");
				youwin = true;
				score = 0;
				badge.SetActive(true);
				qtext.GetComponent<Text>().text = "Congratulations";
				answers[0].GetComponent<Text>().text = "You";
				answers[1].GetComponent<Text>().text = "are";
				answers[2].GetComponent<Text>().text = "winner";
				answers[3].GetComponent<Text>().text = "the";
			}
		}
	}

	public void check(int inpu)
	{
		if(youwin == false)
		{
			if(inpu == canswer)
			{
				score++;
			}
			else
			{
				score--;
			}
		}
		else
		{

		}
	}
}
