// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: MainGUI.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using UnityEngine;

namespace SGG.RTS.UI
{
   // ReSharper disable once InconsistentNaming
   public sealed class MainGUI : MonoBehaviour
   {
      #region Static fields

      public static MainGUI Instance;

      #endregion

      #region Private fields

      private bool m_PrevContainsCursor;

      #endregion

      #region Public fields

      public bool CursorJustEntered;
      public bool CursorJustExited;

      #endregion

      #region Properties

      /// <summary>
      /// This is set by the event triggers of this object
      /// </summary>
      public bool ContainsCursor { get; set; }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Instance = this;
         m_PrevContainsCursor = ContainsCursor;
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
