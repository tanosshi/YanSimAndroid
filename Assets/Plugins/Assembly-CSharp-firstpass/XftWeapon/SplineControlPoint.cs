using UnityEngine;

namespace XftWeapon
{
	public class SplineControlPoint
	{
		public Vector3 Position;

		public Vector3 Normal;

		public int ControlPointIndex = -1;

		public int SegmentIndex = -1;

		public float Dist;

		protected Spline mSpline;

		public SplineControlPoint NextControlPoint
		{
			get
			{
				return mSpline.NextControlPoint(this);
			}
		}

		public SplineControlPoint PreviousControlPoint
		{
			get
			{
				return mSpline.PreviousControlPoint(this);
			}
		}

		public Vector3 NextPosition
		{
			get
			{
				return mSpline.NextPosition(this);
			}
		}

		public Vector3 PreviousPosition
		{
			get
			{
				return mSpline.PreviousPosition(this);
			}
		}

		public Vector3 NextNormal
		{
			get
			{
				return mSpline.NextNormal(this);
			}
		}

		public Vector3 PreviousNormal
		{
			get
			{
				return mSpline.PreviousNormal(this);
			}
		}

		public bool IsValid
		{
			get
			{
				return NextControlPoint != null;
			}
		}

		private Vector3 GetNext2Position()
		{
			SplineControlPoint nextControlPoint = NextControlPoint;
			if (nextControlPoint != null)
			{
				return nextControlPoint.NextPosition;
			}
			return NextPosition;
		}

		private Vector3 GetNext2Normal()
		{
			SplineControlPoint nextControlPoint = NextControlPoint;
			if (nextControlPoint != null)
			{
				return nextControlPoint.NextNormal;
			}
			return Normal;
		}

		public Vector3 Interpolate(float localF)
		{
			localF = Mathf.Clamp01(localF);
			return Spline.CatmulRom(PreviousPosition, Position, NextPosition, GetNext2Position(), localF);
		}

		public Vector3 InterpolateNormal(float localF)
		{
			localF = Mathf.Clamp01(localF);
			return Spline.CatmulRom(PreviousNormal, Normal, NextNormal, GetNext2Normal(), localF);
		}

		public void Init(Spline owner)
		{
			mSpline = owner;
			SegmentIndex = -1;
		}
	}
}
