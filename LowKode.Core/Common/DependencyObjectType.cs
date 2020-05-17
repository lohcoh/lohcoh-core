using System;
using System.Collections.Generic;

namespace LowKode.Core.Common
{
    public class DependencyObjectType
    {
		private static Dictionary<Type, DependencyObjectType> typeMap = new Dictionary<Type, DependencyObjectType>();
		private static int current_id;

		private int id;
		private Type systemType;

		private DependencyObjectType(int id, Type systemType)
		{
			this.id = id;
			this.systemType = systemType;
		}

		public DependencyObjectType BaseType
		{
			get { return DependencyObjectType.FromSystemType(systemType.BaseType); }
		}

		public int Id
		{
			get { return id; }
		}

		public string Name
		{
			get { return systemType.Name; }
		}

		public Type SystemType
		{
			get { return systemType; }
		}

		public static DependencyObjectType FromSystemType(Type systemType)
		{
			if (typeMap.ContainsKey(systemType))
				return typeMap[systemType];

			DependencyObjectType dot;

			typeMap[systemType] = dot = new DependencyObjectType(current_id++, systemType);

			return dot;
		}

		public bool IsInstanceOfType(DependencyObject dependencyObject)
		{
			return systemType.IsInstanceOfType(dependencyObject);
		}

		public bool IsSubclassOf(DependencyObjectType dependencyObjectType)
		{
			return systemType.IsSubclassOf(dependencyObjectType.SystemType);
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}