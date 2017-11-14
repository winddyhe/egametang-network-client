using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Model
{
	public static class DllHelper
	{
		public static Assembly LoadHotfixAssembly()
		{
			GameObject code = (GameObject)Resources.Load("Code");
			byte[] assBytes = code.Get<TextAsset>("Hotfix.dll").bytes;
			byte[] mdbBytes = code.Get<TextAsset>("Hotfix.mdb").bytes;
			Assembly assembly = Assembly.Load(assBytes, mdbBytes);
			return assembly;
		}

		public static Type[] GetHotfixTypes()
		{
            return new Type[0];

            //if (ObjectEvents.Instance.HotfixAssembly == null)
            //{
            //    return new Type[0];
            //}
            //return ObjectEvents.Instance.HotfixAssembly.GetTypes();
        }

        public static Type[] GetMonoTypes()
		{
			List<Type> types = new List<Type>();
			//foreach (Assembly assembly in ObjectEvents.Instance.GetAll())
			//{
			//	types.AddRange(assembly.GetTypes());
			//}
			return types.ToArray();
		}
	}
}