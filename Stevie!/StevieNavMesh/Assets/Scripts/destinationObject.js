#pragma strict

var Finish : GameObject;
var agent : UnityEngine.AI.NavMeshAgent;

function Start () 
{
//agent.destination = dude.transform.position;
agent.destination = Finish.transform.TransformPoint(Vector3.zero);

}

function Update () 
{
var positionQuery;

//CheckLocation();
//}

//function CheckLocation()
//{
	//agent.destination = dude.transform.position;
	agent.destination = Finish.transform.TransformPoint(Vector3.zero);
		//agent.destination = dude.transform.position;
}