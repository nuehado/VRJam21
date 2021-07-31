using UnityEngine;

namespace PaintIn3D
{
	/// <summary>This struct can be used to reference a <b>Material</b> by instance or hash for de/serialization.
	/// NOTE: To support networking you must modify the <b>P3dSerialization.TryRegister(P3dModel)</b> method to register the model using a hash/id specific to your networking solution.</summary>
	[System.Serializable]
	public struct P3dHashedModel
	{
		[System.NonSerialized]
		private P3dModel instance;

		[SerializeField]
		private int hash;

		public static implicit operator P3dHashedModel(P3dModel newInstance)
		{
			P3dHashedModel hashed;

			hashed.instance = newInstance;

			P3dSerialization.ModelToHash.TryGetValue(newInstance, out hashed.hash);

			return hashed;
		}

		public bool TryGetInstance(out P3dModel model)
		{
			if (instance != null)
			{
				model = instance;

				return true;
			}

			return P3dSerialization.HashToModel.TryGetValue(hash, out model);
		}
	}
}