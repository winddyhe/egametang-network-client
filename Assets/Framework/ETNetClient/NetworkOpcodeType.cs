using System;
using Core;

namespace Model
{
	public class NetworkOpcodeType : TSingleton<NetworkOpcodeType>
	{
		private DoubleMap<ushort, Type> mOpcodeTypes = new DoubleMap<ushort, Type>();

        private NetworkOpcodeType()
        {
        }

		public void Initialize()
		{
			Type[] monoTypes = DllHelper.GetMonoTypes();
			foreach (Type monoType in monoTypes)
			{
				object[] attrs = monoType.GetCustomAttributes(typeof(MessageAttribute), false);
				if (attrs.Length == 0)
				{
					continue;
				}
				MessageAttribute messageAttribute = attrs[0] as MessageAttribute;
				if (messageAttribute == null)
				{
					continue;
				}
				this.mOpcodeTypes.Add(messageAttribute.Opcode, monoType);
			}
		}

		public ushort GetOpcode(Type type)
		{
            if (type == typeof(Model.C2R_Login))
            {
                return 101;
            }
            else if (type == typeof(Model.C2G_LoginGate))
            {
                return 104;
            }
			return this.mOpcodeTypes.GetKeyByValue(type);
		}

		public Type GetType(ushort opcode)
		{
            if (opcode == 102)
            {
                return typeof(Model.R2C_Login);
            }
            else if (opcode == 105)
            {
                return typeof(Model.G2C_LoginGate);
            }
			return this.mOpcodeTypes.GetValueByKey(opcode);
		}
	}
}