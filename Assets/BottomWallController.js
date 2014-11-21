#pragma strict

function Start () {

}

function Update () {

}

function OnCollisionEnter(collision: Collision) {
	 //Destroy(collision.gameObject);
	 collision.gameObject.SendMessage("HitBottomWall", 0);
}
