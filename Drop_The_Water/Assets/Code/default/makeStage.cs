using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;
using ObjectHierachy;
using System.IO;

public class makeStage : MonoBehaviour {
	public delegate void Clear ();

	public static Clear clearEvent;

	public GameObject tap;
	public GameObject cup;
	public GameObject water;

	public Vector3[] waterPosition; // water drop

	// Use this for initialization
	void Start () {
		loadStage (Resource.stage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void loadStage(int stage) {
		TextAsset data = Resources.Load ("text/stage" + stage, typeof(TextAsset)) as TextAsset;
		StringReader str = new StringReader (data.text);

		string line;

		while((line = str.ReadLine()) != null) {
			if(line.Equals("answer")) {
				int answerOneNum = int.Parse ((line = str.ReadLine ()));
				string[] o = line.Split (new char[]{ ' ' });
				answerOne (int.Parse (o [0]), int.Parse (o [1]), int.Parse (o [2]), int.Parse (o [3]));

				int answerTwoNum = int.Parse ((line = str.ReadLine ()));
				string[] t = line.Split (new char[]{ ' ' });
				answerTwo (int.Parse (t [0]), int.Parse (t [1]), int.Parse (t [2]));
			}
		}
	}
	

	public void createCupOne(int x, int y, int z, int r){
	}
		
	public void createCupTwo(int x, int y, int z){
	}

	public void answerOne(int x, int y, int z, int r){
	}

	public void answerTwo(int x, int y, int z){
	}
	
}