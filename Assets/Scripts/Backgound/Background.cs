﻿using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (GameObject obj in levels)
        {
            loadChildObject(obj);
        }

        void loadChildObject(GameObject obj)
        {
            float objectWith = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
            int childsNeeded = (int) Mathf.Ceil(screenBounds.x * 2 / objectWith);
            GameObject clone = Instantiate(obj) as GameObject;
            for (int i = 0; i <= childsNeeded; i++)
            {
                GameObject c = Instantiate(clone) as GameObject;
                c.transform.SetParent(obj.transform);
                c.transform.position = new Vector3(objectWith * i, obj.transform.position.y, obj.transform.position.z);
                c.name = obj.name + i;
            }
            Destroy(clone);
            Destroy(obj.GetComponent<SpriteRenderer>());
        }
    }

    void repositionChildObjects(GameObject obj)
    {
        
        Transform[] childeren = obj.GetComponentsInChildren<Transform>();
        if (childeren.Length > 1)
        {
            GameObject firstChild = childeren[1].gameObject;
            GameObject lastChild = childeren[childeren.Length - 1].gameObject;
            float halfObjectWith = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x-choke;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWith)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWith * 2, lastChild.transform.position.y, lastChild.transform.position.z);
                
            }else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWith)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position= new Vector3(firstChild.transform.position.x-halfObjectWith*2, firstChild.transform.position.y, firstChild.transform.position.z);
                
            }
        }
    }
    
    
    private void LateUpdate()
    {
        foreach (GameObject obj in levels) {
                repositionChildObjects(obj);
            }
        
    }
}
