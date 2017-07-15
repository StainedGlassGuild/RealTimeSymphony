// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: MainPanel.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using SGG.FXG.UI;

using UnityEngine;
using UnityEngine.UI;

namespace SGG.RTS.UI
{
   public sealed class MainPanel : MonoBehaviour
   {
      #region Private fields

      [SerializeField, UsedImplicitly]
      private float m_MainPanelOpacity;

      [SerializeField, UsedImplicitly]
      private float m_MainPanelDarkness;

      private bool m_PrevContainsCursor;

      #endregion

      #region Public fields

      public InfoPanel InfoPanel;
      public SelectionPanel SelectionPanel;

      #endregion

      #region Properties

      public bool CursorJustEntered { get; private set; }
      public bool CursorJustExited { get; private set; }

      /// <summary>
      /// This is set by the event triggers of this object
      /// </summary>
      public bool ContainsCursor { get; set; }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         m_PrevContainsCursor = ContainsCursor;
      }

      public void Initialize()
      {
         var panelColor = GameDriver.Instance.PlayerTeam.Color;
         panelColor *= m_MainPanelDarkness;
         panelColor += new Color(1, 1, 1, 0) * m_MainPanelDarkness;
         panelColor.a = m_MainPanelOpacity;
         GetComponent<Image>().color = panelColor;
      }

      [UsedImplicitly]
      private void Update()
      {
         if (ContainsCursor != m_PrevContainsCursor)
         {
            if (ContainsCursor)
            {
               CursorJustEntered = true;
            }
            else
            {
               CursorJustExited = true;
            }
         }
         else
         {
            CursorJustEntered = false;
            CursorJustExited = false;
         }

         m_PrevContainsCursor = ContainsCursor;
      }

      #endregion
   }
}
