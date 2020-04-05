using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void MouseOverFirstSlot()
    {
        DataManager.instance.slotNum = 0;
        this.gameObject.transform.Find("Click").gameObject.SetActive(true);

    }
    public void MouseOverSecondSlot()
    {
        DataManager.instance.slotNum = 1;
        this.gameObject.transform.Find("Click").gameObject.SetActive(true);

    }
    public void MouseOverThirdSlot()
    {
        DataManager.instance.slotNum = 2;
        this.gameObject.transform.Find("Click").gameObject.SetActive(true);

    }
    public void UnMouseOver()
    {
        this.gameObject.transform.Find("Click").gameObject.SetActive(false);

    }
}
