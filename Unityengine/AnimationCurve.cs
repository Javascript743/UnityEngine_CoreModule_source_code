using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine
{
	// Token: 0x020000CF RID: 207
	[RequiredByNativeCode]
	[NativeHeader("Runtime/Math/AnimationCurve.bindings.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class AnimationCurve : IEquatable<AnimationCurve>
	{
		// Token: 0x06000332 RID: 818
		[FreeFunction("AnimationCurveBindings::Internal_Destroy", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Destroy(IntPtr ptr);

		// Token: 0x06000333 RID: 819
		[FreeFunction("AnimationCurveBindings::Internal_Create", IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_Create(Keyframe[] keys);

		// Token: 0x06000334 RID: 820
		[FreeFunction("AnimationCurveBindings::Internal_Equals", HasExplicitThis = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool Internal_Equals(IntPtr other);

		// Token: 0x06000335 RID: 821 RVA: 0x00005AC4 File Offset: 0x00003CC4
		~AnimationCurve()
		{
			AnimationCurve.Internal_Destroy(this.m_Ptr);
		}

		// Token: 0x06000336 RID: 822
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern float Evaluate(float time);

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00005AFC File Offset: 0x00003CFC
		// (set) Token: 0x06000338 RID: 824 RVA: 0x00005B14 File Offset: 0x00003D14
		public Keyframe[] keys
		{
			get
			{
				return this.GetKeys();
			}
			set
			{
				this.SetKeys(value);
			}
		}

		// Token: 0x06000339 RID: 825
		[FreeFunction("AnimationCurveBindings::AddKeySmoothTangents", HasExplicitThis = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int AddKey(float time, float value);

		// Token: 0x0600033A RID: 826 RVA: 0x00005B20 File Offset: 0x00003D20
		public int AddKey(Keyframe key)
		{
			return this.AddKey_Internal(key);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00005B39 File Offset: 0x00003D39
		[NativeMethod("AddKey", IsThreadSafe = true)]
		private int AddKey_Internal(Keyframe key)
		{
			return this.AddKey_Internal_Injected(ref key);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00005B43 File Offset: 0x00003D43
		[FreeFunction("AnimationCurveBindings::MoveKey", HasExplicitThis = true, IsThreadSafe = true)]
		[NativeThrows]
		public int MoveKey(int index, Keyframe key)
		{
			return this.MoveKey_Injected(index, ref key);
		}

		// Token: 0x0600033D RID: 829
		[FreeFunction("AnimationCurveBindings::RemoveKey", HasExplicitThis = true, IsThreadSafe = true)]
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void RemoveKey(int index);

		// Token: 0x17000099 RID: 153
		public Keyframe this[int index]
		{
			get
			{
				return this.GetKey(index);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600033F RID: 831
		public extern int length { [NativeMethod("GetKeyCount", IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000340 RID: 832
		[FreeFunction("AnimationCurveBindings::SetKeys", HasExplicitThis = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetKeys(Keyframe[] keys);

		// Token: 0x06000341 RID: 833 RVA: 0x00005B6C File Offset: 0x00003D6C
		[FreeFunction("AnimationCurveBindings::GetKey", HasExplicitThis = true, IsThreadSafe = true)]
		[NativeThrows]
		private Keyframe GetKey(int index)
		{
			Keyframe result;
			this.GetKey_Injected(index, out result);
			return result;
		}

		// Token: 0x06000342 RID: 834
		[FreeFunction("AnimationCurveBindings::GetKeys", HasExplicitThis = true, IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern Keyframe[] GetKeys();

		// Token: 0x06000343 RID: 835
		[FreeFunction("AnimationCurveBindings::SmoothTangents", HasExplicitThis = true, IsThreadSafe = true)]
		[NativeThrows]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void SmoothTangents(int index, float weight);

		// Token: 0x06000344 RID: 836 RVA: 0x00005B84 File Offset: 0x00003D84
		public static AnimationCurve Constant(float timeStart, float timeEnd, float value)
		{
			return AnimationCurve.Linear(timeStart, value, timeEnd, value);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00005BA0 File Offset: 0x00003DA0
		public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd)
		{
			bool flag = timeStart == timeEnd;
			AnimationCurve result;
			if (flag)
			{
				Keyframe keyframe = new Keyframe(timeStart, valueStart);
				result = new AnimationCurve(new Keyframe[]
				{
					keyframe
				});
			}
			else
			{
				float num = (valueEnd - valueStart) / (timeEnd - timeStart);
				Keyframe[] keys = new Keyframe[]
				{
					new Keyframe(timeStart, valueStart, 0f, num),
					new Keyframe(timeEnd, valueEnd, num, 0f)
				};
				result = new AnimationCurve(keys);
			}
			return result;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00005C1C File Offset: 0x00003E1C
		public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd)
		{
			bool flag = timeStart == timeEnd;
			AnimationCurve result;
			if (flag)
			{
				Keyframe keyframe = new Keyframe(timeStart, valueStart);
				result = new AnimationCurve(new Keyframe[]
				{
					keyframe
				});
			}
			else
			{
				Keyframe[] keys = new Keyframe[]
				{
					new Keyframe(timeStart, valueStart, 0f, 0f),
					new Keyframe(timeEnd, valueEnd, 0f, 0f)
				};
				result = new AnimationCurve(keys);
			}
			return result;
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000347 RID: 839
		// (set) Token: 0x06000348 RID: 840
		public extern WrapMode preWrapMode { [NativeMethod("GetPreInfinity", IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetPreInfinity", IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000349 RID: 841
		// (set) Token: 0x0600034A RID: 842
		public extern WrapMode postWrapMode { [NativeMethod("GetPostInfinity", IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; [NativeMethod("SetPostInfinity", IsThreadSafe = true)] [MethodImpl(MethodImplOptions.InternalCall)] set; }

		// Token: 0x0600034B RID: 843 RVA: 0x00005C93 File Offset: 0x00003E93
		public AnimationCurve(params Keyframe[] keys)
		{
			this.m_Ptr = AnimationCurve.Internal_Create(keys);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00005CA9 File Offset: 0x00003EA9
		[RequiredByNativeCode]
		public AnimationCurve()
		{
			this.m_Ptr = AnimationCurve.Internal_Create(null);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00005CC0 File Offset: 0x00003EC0
		public override bool Equals(object o)
		{
			bool flag = o == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this == o;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = o.GetType() != base.GetType();
					result = (!flag3 && this.Equals((AnimationCurve)o));
				}
			}
			return result;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00005D14 File Offset: 0x00003F14
		public bool Equals(AnimationCurve other)
		{
			bool flag = other == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this == other;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = this.m_Ptr.Equals(other.m_Ptr);
					result = (flag3 || this.Internal_Equals(other.m_Ptr));
				}
			}
			return result;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00005D6C File Offset: 0x00003F6C
		public override int GetHashCode()
		{
			return this.m_Ptr.GetHashCode();
		}

		// Token: 0x06000350 RID: 848
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int AddKey_Internal_Injected(ref Keyframe key);

		// Token: 0x06000351 RID: 849
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int MoveKey_Injected(int index, ref Keyframe key);

		// Token: 0x06000352 RID: 850
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetKey_Injected(int index, out Keyframe ret);

		// Token: 0x0400029A RID: 666
		internal IntPtr m_Ptr;
	}
}
