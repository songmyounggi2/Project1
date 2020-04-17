using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotClick : MonoBehaviour
{
    public int slotNum = 0;

    public void MouseOverFirstSlot()
    {
        if (this.gameObject.name == "One")
        {
            slotNum = 0;
            this.gameObject.transform.Find("Click").gameObject.SetActive(true);
            Debug.Log(slotNum);
        }
        else if (this.gameObject.name == "Two")
        {
            slotNum = 1;
            this.gameObject.transform.Find("Click").gameObject.SetActive(true);
            Debug.Log(slotNum);
        }
        else 
        {
            slotNum = 2;
            this.gameObject.transform.Find("Click").gameObject.SetActive(true);
            Debug.Log(slotNum);
        }
        GameObject.Find("GameObject").GetComponent<DataManager>().slotNum = this.slotNum;

    }
  
    public void UnMouseOver()
    {
        this.gameObject.transform.Find("Click").gameObject.SetActive(false);
    }
}
    // Start is called before the first frame update
  
