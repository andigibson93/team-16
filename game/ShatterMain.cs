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

	public string[] questions;
	public string[] answer1;
	public string[] answer2;
	public string[] answer3;
	public string[] answer4;

	public GameObject[] answers;
	public int[] cans;
	public int canswer;
	
	public GameObject qtext;
	public LLevel[] levels;

	public int clevel;

	public int score;

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
	}
	
	// Update is called once per frame
	public void UpdateLevel (int nlevel) {
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
	}

	public void GenQ ()
	{
		int r = 0;
		r = Random.Range(0, questions.Length-1);
		qtext.GetComponent<Text>().text = questions[r];
		answers[0].GetComponent<Text>().text = answer1[r];
		answers[1].GetComponent<Text>().text = answer2[r];
		answers[2].GetComponent<Text>().text = answer3[r];
		answers[3].GetComponent<Text>().text = answer4[r];
		canswer = cans[r];
	}

	public void check(int inpu)
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
}
