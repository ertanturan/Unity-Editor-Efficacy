﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EditorEfficacy.UI
{
    public class OnClickID : UnityEvent<int> { }

    public class ItemButton : MonoBehaviour
    {
        #region Variables
        public Button m_Button;
        public Image m_Image;
        public RawImage m_RawImage;
        public Text m_Text;
        public int id = 0;
        public OnClickID onClickID = new OnClickID();
        #endregion


        public void InitButton()
        {
            if (m_Button)
            {
                m_Button.onClick.AddListener(HandleClickIDEvent);
            }
        }

        void HandleClickIDEvent()
        {
            if (onClickID != null)
            {
                onClickID.Invoke(id);
            }
        }
    }
}
