using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour {

	public GameObject prefab;
	public int numberOfObjects = 24;
	public float radius = 10.0f;

	public GameObject[] cubes;
	// Use this for initialization
	void Start () {
	
		for (int i = 0; i < numberOfObjects; i++)
		{
			//float angle = i * Mathf.PI * 2 / numberOfObjects;
			float angle = i;
			Vector3 pos = new Vector3(GameObject.Find("holder (" + i + ")").transform.position.x,GameObject.Find("holder (" + i + ")").transform.position.y,GameObject.Find ("holder (" + i + ")").transform.position.z);
			//Vector3 pos = new Vector3(Mathf.Cos(angle),0,Mathf.Sin(angle)) * radius;
			Instantiate(prefab, pos, Quaternion.identity);
		}
		cubes = GameObject.FindGameObjectsWithTag("cubes");
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = AudioListener.GetSpectrumData(1024, 0,FFTWindow.Hamming);

		for(int i = 0; i < numberOfObjects; i++)
		{
			Vector3 previousScale = cubes[i].transform.localScale;
			//previousScale.y = spectrum[i] * 20;
			previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 40, Time.deltaTime * 30);			
			cubes[i].transform.localScale = previousScale;
		}
	}
}
