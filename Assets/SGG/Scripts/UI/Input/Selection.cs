// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Selection.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System.Collections.Generic;

using JetBrains.Annotations;

using SGG.RTS.World.Entity;

using UnityEngine;

namespace SGG.RTS.UI.Input
{
   public sealed class Selection : MonoBehaviour
   {
      #region Properties

      public float SelectionCreationTime { get; private set; }

      public List<AEntity> Entities { get; private set; }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Entities = new List<AEntity>();
      }

      public void Add(AEntity a_Entity)
      {
         Debug.Assert(!Contains(a_Entity));

         if (Entities.Count == 0)
         {
            SelectionCreationTime = Time.time;
         }

         a_Entity.Appreance.IsSelected = true;
         Entities.Add(a_Entity);
      }

      public bool Contains(AEntity a_Entity)
      {
         return Entities.Contains(a_Entity);
      }

      public void Remove(AEntity a_Entity)
      {
         Debug.Assert(Contains(a_Entity));
         a_Entity.Appreance.IsSelected = false;
         Entities.Remove(a_Entity);
      }

      public void Clear()
      {
         foreach (var entity in Entities)
         {
            entity.Appreance.IsSelected = false;
         }
         Entities.Clear();
      }

      #endregion
   }
}
