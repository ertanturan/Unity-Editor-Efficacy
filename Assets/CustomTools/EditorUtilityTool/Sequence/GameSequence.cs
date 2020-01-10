using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EditorUtility
{
    public class GameSequence : MonoBehaviour
    {
        #region Variables
        [Header("Sequence Properties")]
        public bool m_StartAtStart = false;
        [HideInInspector]
        public List<UtilityAction> m_Actions = new List<UtilityAction>();

        [Header("Events")]
        public UnityEvent OnSequenceStart = new UnityEvent();
        public UnityEvent OnSequenceComplete = new UnityEvent();

        private UtilityAction currentAction;
        private int currentActionID;

        private bool completed = false;
        #endregion


        #region Main Methods
        // Use this for initialization
        void Start()
        {
            completed = false;
            currentActionID = -1;
            InitializeSequence();

            if (m_StartAtStart)
            {
                StartSequence();
            }
        }

        void OnDisable()
        {
            DeInitializeSequence();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentAction != null)
            {
                currentAction.UpdateAction();
            }
        }
        #endregion



        #region Custom Methods
        void InitializeSequence()
        {
            if (m_Actions.Count > 0)
            {
                for (int i = 0; i < m_Actions.Count; i++)
                {
                    if (m_Actions[i] != null)
                    {
                        m_Actions[i].OnCompleted.AddListener(NextAction);
                    }
                }
            }
        }

        void DeInitializeSequence()
        {
            if (m_Actions.Count > 0)
            {
                for (int i = 0; i < m_Actions.Count; i++)
                {
                    if (m_Actions[i] != null)
                    {
                        m_Actions[i].OnCompleted.RemoveListener(NextAction);
                    }
                }
            }
        }

        public void StartSequence()
        {
            Debug.Log("Started Sequence");
            if (OnSequenceStart != null)
            {
                OnSequenceStart.Invoke();
            }
            NextAction();
        }

        public void CompletedSequence()
        {
            Debug.Log("Completed Sequence");
            completed = true;
            currentAction = null;
            if (OnSequenceComplete != null)
            {
                OnSequenceComplete.Invoke();
            }
        }

        public void NextAction()
        {
            currentActionID++;
            if (currentActionID > m_Actions.Count - 1)
            {
                CompletedSequence();
            }
            else if (currentActionID >= 0 && currentActionID <= m_Actions.Count - 1)
            {
                currentAction = m_Actions[currentActionID];
                if (currentAction != null)
                {
                    currentAction.StartAction();
                }
            }
        }

        public void ResetSequence()
        {
            currentActionID = 0;
            completed = false;
            currentAction = null;
        }
        #endregion
    }
}
