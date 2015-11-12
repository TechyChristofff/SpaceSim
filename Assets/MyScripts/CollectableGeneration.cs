using UnityEngine;
using System.Collections;

public class CollectableGeneration : MonoBehaviour {
	
	public int CollectableNumber = 0;
	public float buffer = 0;
	float radiusCol = 100;
	public GameObject Collectable;
	
	// Use this for initialization
	void Start () {
		radiusCol = this.GetComponent<SphereCollider>().radius;
		for(int i = 0; i<CollectableNumber;i++)
		{
			Vector3 targetPosition = NewPosition();
			float checkRadius = Collectable.GetComponent<Renderer>().bounds.extents.magnitude;
			var checkResult = Physics.OverlapSphere( targetPosition, checkRadius );
			if (checkResult.Length == 0) {
				// all clear!
				Instantiate( Collectable, targetPosition, Quaternion.identity );
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetCollectableAmount(int amount)
	{
		CollectableNumber = amount;
	}
	
	Vector3 NewPosition()
	 {
		 Vector3 pos = new Vector3();
		 while((pos.x > - buffer && pos.x < buffer) ||
						(pos.y > - buffer && pos.y < buffer) ||
						(pos.z > - buffer && pos.z < buffer))
				{
					pos = Random.insideUnitSphere * radiusCol;
				}
		 return pos;
	 }
}
