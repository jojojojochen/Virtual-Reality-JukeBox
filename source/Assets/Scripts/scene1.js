#pragma strict

public var amplitude: float = 0.001;
public var speed: float = 30.0;
private var randomAmplitude: float = 1.0;
private var startScale: Vector3;
public var detail: int = 500;
public var minValue: float = 1.0;

function Start()
{
	startScale = transform.localScale;
}

function Update() 
{
	randomAmplitude = Random.Range(0.0001/2, 0.0020);
	var info: float[] = new float[detail];
	AudioListener.GetOutputData(info, 0); 
	var packagedData: float = 0.0;
	for(var i: int = 0; i < info.Length; i++){packagedData += System.Math.Abs(info[i]);}
	transform.Rotate(packagedData*0.01, packagedData*0.01 * Time.deltaTime, packagedData*0.01);
	transform.localScale = new Vector3(startScale.x+packagedData*randomAmplitude,startScale.y+packagedData*randomAmplitude,startScale.z+packagedData*randomAmplitude);
}