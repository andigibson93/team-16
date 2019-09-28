using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterMain : MonoBehaviour {

	// Use this for initialization
	[System.Serializable]
	public class LLevel
	{
		public string name;
		public int levelnum = 0;
		public GameObject levelobjs;
	}

	public LLevel[] levels;

	public int clevel;

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
}
