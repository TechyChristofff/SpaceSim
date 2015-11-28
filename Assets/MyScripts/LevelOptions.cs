using UnityEngine;
using System.Collections;

public class LevelOptions : MonoBehaviour {
	
	struct LevelInfo
	{
		public int _mLevelId;
		public string _mLevelLabel;
		public float _mLevelTime;
		public int _mAsteroidCount;
		public float _mAsteroidSpeed;
		public int _mCollectableNumber;
		public int _mCollectableNeeded;
		public float _mSphereradius;
		public int _mMoveChance;
		public int _mAttackChance;
	}
	
	LevelInfo Menu,Easy,Med,Hard,CurrentLevel;
	// Use this for initialization
	void Awake(){
		#region Menu
			Menu._mLevelId = 0;
			Menu._mLevelLabel = "Menu";
			Menu._mLevelTime = float.MaxValue;
			Menu._mAsteroidCount = 250;
			Menu._mAsteroidSpeed = 500;
			Menu._mCollectableNeeded = 0;
			Menu._mCollectableNumber = 0;
			Menu._mSphereradius = 4500;
			Menu._mMoveChance = 1;
			Menu._mAttackChance = int.MaxValue;
		#endregion
		#region Easy
		    Easy._mLevelId = 1;
			Easy._mLevelLabel = "Easy";
			Easy._mLevelTime = 120;
			Easy._mAsteroidCount = 500;//600
			Easy._mAsteroidSpeed = 400;
			Easy._mCollectableNeeded = 1;
			Easy._mCollectableNumber = 100;
			Easy._mSphereradius = 4500;
			Easy._mMoveChance = 3;
			Easy._mAttackChance = 4;
		#endregion
		#region Medium
			Med._mLevelId = 2;
			Med._mLevelLabel = "Medium";
			Med._mLevelTime = 90;
			Med._mAsteroidCount = 600;
			Med._mAsteroidSpeed = 500;
			Med._mCollectableNeeded = 5;
			Med._mCollectableNumber = 90;
			Med._mSphereradius = 4500;
			Med._mMoveChance = 2;
			Med._mAttackChance = 3;
		#endregion
		#region Hard
			Hard._mLevelId = 3;
			Hard._mLevelLabel = "Hard";
			Hard._mLevelTime = 60;
			Hard._mAsteroidCount = 700;
			Hard._mAsteroidSpeed = 600;
			Hard._mCollectableNeeded = 10;
			Hard._mCollectableNumber = 80;
			Hard._mSphereradius = 4500;
			Hard._mMoveChance = 2;
			Hard._mAttackChance = 2;
		#endregion
            SetLevel(0, "Initial Level Load");
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetLevel(int levelValue)
    {
        switch (levelValue)
        {
            case 0:
                { //MainMenu
                    CurrentLevel = Menu;
                } break;
            case 1:
                {//Easy
                    CurrentLevel = Easy;
                } break;
            case 2:
                {//Med
                    CurrentLevel = Med;
                } break;
            case 3:
                {//Hard
                    CurrentLevel = Hard;
                } break;
        }
    }

    public void LevelChangeReason(string changeReason)
    {
        Debug.Log(changeReason);
    }

	public void SetLevel(int levelValue, string changeReason)
	{
        Debug.Log(changeReason);
		switch(levelValue)
		{
			case 0: { //MainMenu
				CurrentLevel = Menu;
			}break;
			case 1: {//Easy
				CurrentLevel = Easy;
			}break;
			case 2: {//Med
				CurrentLevel = Med;
			}break;
			case 3: {//Hard
				CurrentLevel = Hard;
			}break;
		}
	}
	
	public int LevelID{get{return CurrentLevel._mLevelId;}}
	public string LevelTag{get{return CurrentLevel._mLevelLabel;}}
	public float LevelTime{get{return CurrentLevel._mLevelTime;}}
	public int AsteroidCount{get{return CurrentLevel._mAsteroidCount;}}
	public float AsteroidSpeed{get{return CurrentLevel._mAsteroidSpeed;}}
	public int CollectableNumber{get{return CurrentLevel._mCollectableNumber;}}
	public int CollecableNeeded{get{return CurrentLevel._mCollectableNeeded;}}
	//public float SphereRadius {get {return CurrentLevel._mSphereradius;}}
	public int MoveChance{get{return CurrentLevel._mMoveChance;}}
	public int AttackChance{get{return CurrentLevel._mAttackChance;}}
}
