// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Unit.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using UnityEngine;

namespace SGG.RTS
{
   public sealed class Unit : MonoBehaviour
   {
      #region Public fields

      public Vector2 Destination;

      public Team Team;

      #endregion

      #region Properties

      public Color Color
      {
         get { return GetComponent<Renderer>().material.color; }
         set { GetComponent<Renderer>().material.color = value; }
      }

      public Color GlowColor
      {
         get { return transform.GetChild(0).GetComponentInChildren<Renderer>().material.color; }
         set { transform.GetChild(0).GetComponentInChildren<Renderer>().material.color = value; }
      }

      public Vector2 Position
      {
         get
         {
            var pos3D = transform.position;
            return new Vector2(pos3D.x, pos3D.y);
         }

         set { transform.position = value; }
      }

      #endregion
   }
}
