// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Building.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using SGG.RTS.Utils;

using UnityEngine;

namespace SGG.RTS.World.Entity.Building
{
   public sealed class Building : AEntity
   {
      #region Properties

      public Vector2UInt Size { get; set; }

      public override string Name
      {
         get { return "TempName"; }
      }

      public override EntityType Type
      {
         get { return EntityType.BUILDING; }
      }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Algorithms.ForEachElement(Size, a_TileCoord =>
         {
            // Create building tile primitive
            var tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
            tile.name = "Building Tile";
            tile.transform.parent = transform;

            // Set building tile size
            var transf = tile.transform;
            transf.localScale = Vector3.one * 0.1f;

            // Set building tile rotation
            transf.LookAt(Vector3.up);

            // Set building tile position
            var pos2D = a_TileCoord + Vector2.one * 0.5f;
            transf.localPosition = new Vector3(pos2D.x, pos2D.y);

            // Set building color
            tile.GetComponent<Renderer>().material.color = Color.green;
         });
      }

      #endregion
   }
}
