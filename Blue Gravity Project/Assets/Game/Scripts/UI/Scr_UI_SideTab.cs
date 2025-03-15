using UnityEngine;

public class Scr_UI_SideTab : MonoBehaviour
{
    [SerializeField] private GameObject[] _allPages;


    public void ActivateWindow(GameObject obj)
    {
        DisableAllPages();
        
        obj.SetActive(true);
    }
    
    public void DisableAllPages()
    {
        for (int i = 0; i < _allPages.Length; i++)
        {
            _allPages[i].gameObject.SetActive(false);
        }
    }
}
