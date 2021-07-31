using UnityEngine;
using System.Collections.Generic;

namespace PaintIn3D
{
	/// <summary>This class handles the low level de/serialization of different paint in 3D objects to allow for things like networking.</summary>
	public static class P3dSerialization
	{
		/// <summary>This stores an association between a <b>Material</b> hash code and the <b>Material</b> instance, so it can be de/serialized.</summary>
		public static Dictionary<int, Material> HashToMaterial = new Dictionary<int, Material>();

		/// <summary>This stores an association between a <b>Material</b> instance and the <b>Material</b> hash code, so it can be de/serialized.</summary>
		public static Dictionary<Material, int> MaterialToHash = new Dictionary<Material, int>();

		/// <summary>This stores an association between a <b>P3dModel</b> hash code and the <b>P3dModel</b> instance, so it can be de/serialized.</summary>
		public static Dictionary<int, P3dModel> HashToModel = new Dictionary<int, P3dModel>();

		/// <summary>This stores an association between a <b>P3dModel</b> instance and the <b>P3dModel</b> hash code, so it can be de/serialized.</summary>
		public static Dictionary<P3dModel, int> ModelToHash = new Dictionary<P3dModel, int>();

		/// <summary>This stores an association between a <b>Texture</b> hash code and the <b>Texture</b> instance, so it can be de/serialized.</summary>
		public static Dictionary<int, Texture> HashToTexture = new Dictionary<int, Texture>();

		/// <summary>This stores an association between a <b>Texture</b> instance and the <b>Texture</b> hash code, so it can be de/serialized.</summary>
		public static Dictionary<Texture, int> TextureToHash = new Dictionary<Texture, int>();

		/// <summary>This stores an association between a <b>P3dModel</b> hash code and the <b>P3dModel</b> instance, so it can be de/serialized.</summary>
		public static Dictionary<int, P3dPaintableTexture> HashToPaintableTexture = new Dictionary<int, P3dPaintableTexture>();

		/// <summary>This stores an association between a <b>P3dModel</b> instance and the <b>P3dModel</b> hash code, so it can be de/serialized.</summary>
		public static Dictionary<P3dPaintableTexture, int> PaintableTextureToHash = new Dictionary<P3dPaintableTexture, int>();

		public static void TryRegister(P3dPaintableTexture paintableTexture)
		{
			// If you want to be able to network a P3dPaintableTexture instance, replace this line with something from your networking library that can return the same value for all clients
			var hash = paintableTexture.GetInstanceID();

			//if (cannotCalculateHash == true) return;

			if (HashToPaintableTexture.ContainsKey(hash) == true)
			{
				throw new System.Exception("You're trying to register the " + paintableTexture + " P3dPaintableTexture, but you've already registered the " + HashToPaintableTexture[hash] + " P3dPaintableTexture with the same hash.");
			}

			PaintableTextureToHash.Add(paintableTexture, hash);
			HashToPaintableTexture.Add(hash, paintableTexture);
		}

		public static int TryRegister(P3dModel model)
		{
			// If you want to be able to network a P3dModel instance, replace this line with something from your networking library that can return the same value for all clients
			var hash = model.GetInstanceID();

			//if (cannotCalculateHash == true) return 0;

			if (HashToModel.ContainsKey(hash) == true)
			{
				throw new System.Exception("You're trying to register the " + model + " P3dModel, but you've already registered the " + HashToModel[hash] + " P3dModel with the same hash.");
			}

			ModelToHash.Add(model, hash);
			HashToModel.Add(hash, model);

			return hash;
		}

		public static int TryRegister(Texture texture)
		{
			// If you want to be able to network a Texture instance, replace this line with something from your networking library that can return the same value for all clients
			var hash = texture.GetInstanceID();

			//if (cannotCalculateHash == true) return 0;

			if (HashToTexture.ContainsKey(hash) == true)
			{
				throw new System.Exception("You're trying to register the " + texture + " Texture, but you've already registered the " + HashToTexture[hash] + " Texture with the same hash.");
			}

			TextureToHash.Add(texture, hash);
			HashToTexture.Add(hash, texture);

			return hash;
		}

		public static void TryUnregister(P3dPaintableTexture paintableTexture)
		{
			int hash;

			if (PaintableTextureToHash.TryGetValue(paintableTexture, out hash) == true)
			{
				PaintableTextureToHash.Remove(paintableTexture);
				HashToPaintableTexture.Remove(hash);
			}
		}

		public static void TryUnregister(P3dModel model)
		{
			int hash;

			if (ModelToHash.TryGetValue(model, out hash) == true)
			{
				ModelToHash.Remove(model);
				HashToModel.Remove(hash);
			}
		}

		public static void TryUnregister(Texture texture)
		{
			int hash;

			if (TextureToHash.TryGetValue(texture, out hash) == true)
			{
				TextureToHash.Remove(texture);
				HashToTexture.Remove(hash);
			}
		}

		public static int TryRegister(Material material)
		{
			var hash = GetStableStringHash(material.name);

			if (HashToMaterial.ContainsKey(hash) == true)
			{
				throw new System.Exception("You're trying to register the " + material + " Material, but you've already registered the " + HashToMaterial[hash] + " Material with the same hash.");
			}

			MaterialToHash.Add(material, hash);
			HashToMaterial.Add(hash, material);

			return hash;
		}

		private static int GetStableStringHash(string s)
		{
			var hash = 23;

			foreach (var c in s)
			{
				hash = hash * 31 + c;
			}

			return hash;
		}
	}
}