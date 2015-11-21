#pragma strict

private var soundOn: boolean = false;

function Start()
{
	GetComponent.<AudioSource>().volume = 0.0;
}

function OnGUI()
{
	if(!soundOn)
	{
		if(GUI.Button(Rect(10,10,200,50), "Activate"))
		{
			GetComponent.<AudioSource>().volume = 1.0;
			soundOn = true;
		}
	}
	else
	{
		if(GUI.Button(Rect(10,10,200,50), "Deactivate"))
		{
			GetComponent.<AudioSource>().volume = 0.0;
			soundOn = false;
		}
	}
	
}