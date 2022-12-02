using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> UIPanelList = new List<GameObject>();

        public void OpenPanel(UIPanelStates panelStates)
        {
            UIPanelList[(int)panelStates].SetActive(true);
        }

        public void ClosePanel(UIPanelStates panelStates)
        {
            UIPanelList[(int)panelStates].SetActive(false);
        }
    }
}