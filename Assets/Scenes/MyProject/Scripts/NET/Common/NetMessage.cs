using Unity.Networking.Transport;
using UnityEngine;

public class NetMessage
{
    public string ContentBox = "";
    public OpCode Code { set; get; }

    // guiwri tới server
    public void Serialize(ref DataStreamWriter writer)
    {
        // byte, int , bytes
        // opcode, kích thước mảng, mảng
        writer.WriteByte((byte)Code); 
        byte[] chatBytes = System.Text.Encoding.UTF8.GetBytes(ContentBox);
        int lenght = chatBytes.Length;
        writer.WriteInt(lenght);
        for (int i = 0; i < lenght; i++)
        {
            writer.WriteByte(chatBytes[i]);
        }
    }
    //nhân từ server
    public void Deserialize(DataStreamReader reader)
    {
        int lenght = reader.ReadInt();
        byte[] chatBytes = new byte[lenght];
        for (int i = 0; i < lenght; i++)
        {
            chatBytes[i] = reader.ReadByte();
        }
        ContentBox = System.Text.Encoding.UTF8.GetString(chatBytes);
    }
    public virtual void ReceivedOnClient() { }
    public virtual void ReceivedOnServer(NetworkConnection cnn) { }
}
