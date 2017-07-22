// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: AEntityAppearanceUpdater.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using UnityEngine;

namespace SGG.RTS.World.Entity
{
   public abstract class AEntityAppearance : MonoBehaviour
   {
      #region Private fields

      private bool m_DoUpdateSelection;

      #endregion

      #region Properties

      public bool IsSelected
      {
         get { return m_DoUpdateSelection; }
         set
         {
            if (!value)
            {
               StopSelection();
            }

            m_DoUpdateSelection = value;
         }
      }

      #endregion

      #region Abstract methods

      protected abstract void StopSelection();

      protected abstract void UpdateSelection();

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Update()
      {
         if (IsSelected)
         {
            UpdateSelection();
         }
      }

      #endregion
   }
}
