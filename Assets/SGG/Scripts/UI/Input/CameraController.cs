// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: CameraController.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using SGG.RTS.Utils;
using SGG.RTS.World;

using UnityEngine;

namespace SGG.RTS.UI.Input
{
   public sealed class CameraController : MonoBehaviour
   {
      #region Compile-time constants

      public const float MIN_ZOOM_LVL = 3;
      private const float MAX_ZOOM_LVL = 70;
      private const float INITIAL_ZOOM_LVL = 10;
      private const float CAMERA_MOVE_SPEED = 0.37564f;
      private const float ZOOM_SPEED = 0.5f;

      #endregion

      #region Private fields

      private Vector2UInt m_GameBoardSizeTiles;
      private float m_TargetZoomLvl;

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Camera.main.orthographicSize = INITIAL_ZOOM_LVL;
         m_GameBoardSizeTiles = GameWorld.Instance.BoardSizeInTiles;
         m_TargetZoomLvl = INITIAL_ZOOM_LVL;

         var pos2D = GameWorld.Instance.BoardSizeInTiles * 0.5f;
         Camera.main.transform.position = new Vector3(pos2D.x, pos2D.y, -10);
      }

      [UsedImplicitly]
      private void Update()
      {
         // Update camera position
         var pos = Camera.main.transform.position;
         pos.x += UnityEngine.Input.GetAxis(InputNames.CAMERA_HORIZONTAL_MOVE) * CAMERA_MOVE_SPEED;
         pos.y += UnityEngine.Input.GetAxis(InputNames.CAMERA_VERTICAL_MOVE) * CAMERA_MOVE_SPEED;
         pos.x = Mathf.Clamp(pos.x, 0, m_GameBoardSizeTiles.X);
         pos.y = Mathf.Clamp(pos.y, 0, m_GameBoardSizeTiles.Y);
         Camera.main.transform.position = pos;

         // Update camera zoom
         m_TargetZoomLvl += UnityEngine.Input.GetAxis(InputNames.CAMERA_ZOOM) * ZOOM_SPEED;
         m_TargetZoomLvl = Mathf.Clamp(m_TargetZoomLvl, MIN_ZOOM_LVL, MAX_ZOOM_LVL);
         float zoom = Camera.main.orthographicSize;
         Camera.main.orthographicSize = Mathf.Lerp(zoom, m_TargetZoomLvl, 0.25f);
      }

      #endregion
   }
}
