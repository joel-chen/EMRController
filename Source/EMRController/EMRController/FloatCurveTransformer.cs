﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EMRController
{
	static class FloatCurveTransformer
	{
		public static FloatCurve GenerateForPercentage(FloatCurve min, FloatCurve max, float percentage)
		{
			EMRUtils.Log("Evaluating Float Curve");
			EMRUtils.Log("Float Curve has ", min.Curve.length, " keys");
			FloatCurve resultantCurve = new FloatCurve();
			for (int i = 0; i < min.Curve.length; i++) {
				Keyframe minKey = min.Curve[i];
				Keyframe maxKey = min.Curve[i];
				EMRUtils.Log("Key: ", minKey.time, " ", minKey.value, " ", minKey.inTangent, " ", minKey.outTangent, " ", minKey.tangentMode);
				AddPointToCurve(resultantCurve, minKey, maxKey, percentage);
			}

			return min;
		}

		private static void AddPointToCurve(FloatCurve resultantCurve, Keyframe minKey, Keyframe maxKey, float percentage)
		{
			resultantCurve.Add(
				GetPointWithinRange(minKey.time, maxKey.time, percentage),
				GetPointWithinRange(minKey.value, maxKey.value, percentage),
				GetPointWithinRange(minKey.inTangent, maxKey.inTangent, percentage),
				GetPointWithinRange(minKey.outTangent, maxKey.outTangent, percentage)
			);
		}

		private static float GetPointWithinRange(float min, float max, float percentage)
		{
			return (percentage * (max - min)) + min;
		}
	}
}
