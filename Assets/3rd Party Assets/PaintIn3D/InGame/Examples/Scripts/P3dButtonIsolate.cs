using UnityEngine;
using UnityEngine.EventSystems;

namespace PaintIn3D
{
	/// <summary>This component allows you to turn a UI element into a button that will activate the target GameObject, and deactivate its siblings. If the target GameObject is active, then the button will be faded in.</summary>
	[ExecuteInEditMode]
	[HelpURL(P3dHelper.HelpUrlPrefix + "P3dButtonIsolate")]
	[AddComponentMenu(P3dHelper.ComponentMenuPrefix + "Button Isolate")]
	public class P3dButtonIsolate : MonoBehaviour, IPointerDownHandler
	{
		/// <summary>If this GameObject is active, then the button will be faded in.</summary>
		public Transform Target { set { target = value; } get { return target; } } [SerializeField] private Transform target;

		protected virtual void Update()
		{
			if (target != null)
			{
				var group = GetComponent<CanvasGroup>();

				if (group != null)
				{
					group.alpha = target.gameObject.activeInHierarchy == true ? 1.0f : 0.5f;
				}
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (target != null)
			{
				var parent = target.transform.parent;

				foreach (Transform child in parent)
				{
					child.gameObject.SetActive(false);
				}

				target.gameObject.SetActive(true);
			}
		}
	}
}

#if UNITY_EDITOR
namespace PaintIn3D
{
	using UnityEditor;
	using TARGET = P3dButtonIsolate;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(TARGET))]
	public class P3dButtonIsolate_Editor : P3dEditor
	{
		protected override void OnInspector()
		{
			TARGET tgt; TARGET[] tgts; GetTargets(out tgt, out tgts);

			BeginError(Any(tgts, t => t.Target == null));
				Draw("target", "If this GameObject is active, then the button will be faded in.");
			EndError();
		}
	}
}
#endif