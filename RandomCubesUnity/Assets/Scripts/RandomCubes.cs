/***
 * Created by: Ethan Landrum
 * Date Created: January 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited Date: January 26, 2022
 * 
 * Description: Spawns multiple cube prefabs onto scene.
 ***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    // Variables
    public GameObject cubePrefab; //new gameObject
    public float scalingFactor = 0.95f;
    public int numberOfCubes = 0;
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all the cubes

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates the list
    }//end start

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++;
        GameObject gObj = Instantiate<GameObject>(cubePrefab); //instantiate the cube

        gObj.name = "Cube" + numberOfCubes; //name property of the object

        gObj.transform.position = Random.insideUnitSphere; //random point in a sphere radius of 1 from the CubeSpawner.

        Color randomColor = new Color(Random.value, Random.value, Random.value);

        gObj.GetComponent<Renderer>().material.color = randomColor; //assign a random color to the cube

        gameObjectList.Add(gObj); //add the new cube to the list of cubes.

        List<GameObject> removeList = new List<GameObject>();//list of cubes to remove

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //records the starting scale
            scale *= scalingFactor; //muliply scale by scaling factor.
            goTemp.transform.localScale = Vector3.one * scale; //transforms the scale.

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);//add to remove list.
            }//end if
        }//end foreach

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp);//remove from gameobject list
            Destroy(goTemp);//destroy the object from scene
        }//end foreach
    }
}
