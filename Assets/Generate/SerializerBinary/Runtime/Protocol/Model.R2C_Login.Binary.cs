using System.IO;
using Core;
using Core.Serializer;
using Game.Serializer;


/// <summary>
/// 文件自动生成无需又该！如果出现编译错误，删除文件后会自动生成
/// </summary>
namespace Model
{
public partial class R2C_Login
{
	public override void Serialize(BinaryWriter rWriter)
	{
		base.Serialize(rWriter);
		rWriter.Serialize(this.Address);
		rWriter.Serialize(this.Key);
	}
	public override void Deserialize(BinaryReader rReader)
	{
		base.Deserialize(rReader);
		this.Address = rReader.Deserialize(this.Address);
		this.Key = rReader.Deserialize(this.Key);
	}
}
}
