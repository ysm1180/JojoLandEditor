using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace LandEditor
{
    internal class E5FileData : IDisposable
    {
        private FileStream e5File;
        private string filePath;
        private bool disposed = false;
        private int tnC = 0;
        private int tC = 0;

        public E5FileData(String filePath)
        {
            this.filePath = filePath;
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                e5File = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            else
            {
                e5File = file.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool bManage)
        {
            if (disposed) return;
            disposed = true;
            if (bManage)
            {
            }
            e5File.Close();
        }

        ~E5FileData()
        {
            Dispose(false);
        }

        public int Length
        {
            get
            {
                return (int)e5File.Length;
            }
        }

        public int ReadInt(int offset)
        {
            var temp = new byte[4];
            e5File.Seek(offset, SeekOrigin.Begin);
            e5File.Read(temp, 0, 4);
            return temp[0] * 16777216 + temp[1] * 65536 + temp[2] * 256 + temp[3];
        }

        public byte[] ReadByteArr(int offset, int count)
        {
            var temp = new byte[count];
            e5File.Seek(offset, SeekOrigin.Begin);
            e5File.Read(temp, 0, count);
            return temp;
        }

        public void WriteByte(int offset, byte data)
        {
            e5File.Seek(offset, SeekOrigin.Begin);
            e5File.Write(BitConverter.GetBytes(data), 0, 1);
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public void WriteInt(int offset, int data)
        {
            var bytes = BitConverter.GetBytes(data);
            Swap<byte>(ref bytes[0], ref bytes[3]);
            Swap<byte>(ref bytes[1], ref bytes[2]);
            e5File.Seek(offset, SeekOrigin.Begin);
            e5File.Write(bytes, 0, 4);
        }

        public void WriteByteArr(int offset, byte[] data)
        {
            e5File.Seek(offset, SeekOrigin.Begin);
            e5File.Write(data, 0, data.Length);
        }

        public int GetItemCount()
        {
            return (GetOffset(0) - 0x110) / 12;
        }

        public int GetOffset(int index)
        {
            return ReadInt(index * 12 + 0x118);
        }

        public int GetItemSize(int index)
        {
            return ReadInt(index * 12 + 0x114);
        }

        public byte[] GetItemBytes(int index)
        {
            int offset = GetOffset(index), size = GetItemSize(index);
            int compressionSize = ReadInt(index * 12 + 0x110);
            if (compressionSize == size)
            {
                return ReadByteArr(offset, size);
            }
            else
            {
                return Decode(index);
            }
        }

        public void SetOffset(int index, int offset)
        {
            WriteInt(index * 12 + 0x118, offset);
        }

        public void SetItemSize(int index, int size)
        {
            WriteInt(index * 12 + 0x114, size);
        }

        public void SetItemBytes(int index, byte[] data)
        {
            int offset = GetOffset(index);
            WriteByteArr(offset, data);
        }

        public void AddItem(byte[] data)
        {
        }

        public void DeleteItem(int index)
        {
        }

        private byte[] Decode(int index)
        {
            int c = 0, nc = 0, t = 0;
            int size = GetItemSize(index);
            byte[] dest = new byte[size];
            byte[] datas = new byte[256];
            e5File.Seek(0x10, SeekOrigin.Begin);
            e5File.Read(datas, 0, 256);

            e5File.Seek(GetOffset(index), SeekOrigin.Begin);
            while (size > 0)
            {
                t = GetCode();
                if (t >= 256)
                {
                    t -= 256;
                    nc = GetCode() + 3;
                    for (int i = 0; i < nc; i++)
                    {
                        dest[c] = dest[c - t];
                        c++;
                    }
                    size -= nc;
                }
                else
                {
                    dest[c] = datas[t];
                    c++;
                    size--;
                }
            }

            return dest;
        }

        private int GetCode()
        {
            int t = 0, t2 = 0, n = 0;
            do
            {
                t2 = GetBit(1);
                t = t * 2 + t2;
                n++;
            } while (t2 != 0);
            t2 = GetBit(n);
            return t + t2;
        }

        private int GetBit(int n)
        {
            int result = 0;
            while (n > 0)
            {
                if (tnC == 0)
                {
                    tC = e5File.ReadByte();
                    tnC = 8;
                }
                tnC++;
                result += result;
                if (tC >= 128)
                {
                    result++;
                    tC -= 128;
                }
                tC += tC;
                n--;
            }
            return result;
        }
    }
}