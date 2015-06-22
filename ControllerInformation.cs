using System;
using UnityEngine;

namespace User.Control
{
	public class ControllerInformation
	{
		private bool isJump;
		private bool isAtack;
		private bool isCroach;
		private Vector3 moveDirection;

		public ControllerInformation ()
		{
		}

		public bool IsJump {
			get {
				return isJump;
			}
			set {
				isJump = value;
			}
		}

		public bool IsAtack {
			get {
				return isAtack;
			}
			set {
				isAtack = value;
			}
		}

		public bool IsCroach {
			get {
				return isCroach;
			}
			set {
				isCroach = value;
			}
		}

		public Vector3 MoveDirection {
			get {
				return moveDirection;
			}
			set {
				moveDirection = value;
			}
		}
	}
}

