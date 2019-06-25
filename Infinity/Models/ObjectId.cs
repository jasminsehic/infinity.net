using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Infinity.Util;

namespace Infinity.Models
{
    /// <summary>
    /// A SHA-1 ID of a Git object.
    /// </summary>
    public class ObjectId
    {
        private const int Length = 20;

        byte[] id = new byte[Length];

        /// <summary>
        /// Create a Git object ID.
        /// </summary>
        /// <param name="str">The object ID string</param>
        public ObjectId(string str)
        {
            Assert.NotNull(str, "id");

            if (str.Length != Length * 2)
            {
                throw new ArgumentException("Invalid object id");
            }

            for (int i = 0, j = 0; i < Length; i++, j+=2)
            {
                id[i] = (byte)((byte)(HexValue(str[j]) << 4) | HexValue(str[j + 1]));
            }
        }

        private byte HexValue(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (byte)(c - '0');
            }
            if (c >= 'a' && c <= 'f')
            {
                return (byte)((c - 'a') + 10);
            }
            if (c >= 'A' && c <= 'F')
            {
                return (byte)((c - 'a') + 10);
            }

            throw new ArgumentException(String.Format("Invalid character in hex string '{0}'", c));
        }

        /// <summary>
        /// Gets the ID bytes.
        /// </summary>
        public byte[] Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets the ASCII armored ID string.
        /// </summary>
        /// <returns>The ID string</returns>
        public override string ToString()
        {
            char[] str = new char[Length * 2];

            for (int i = 0, j = 0; i < Length; i++, j+=2)
            {
                str[j] = CharValue((byte)((id[i] & 0xf0) >> 4));
                str[j+1] = CharValue((byte)(id[i] & 0x0f));
            }

            return new string(str);
        }

        private char CharValue(byte b)
        {
            return (char)(b > 9 ? (b - 10) + 'a' : b + '0');
        }

        /// <summary>
        /// Determine if two object IDs are equal
        /// </summary>
        /// <param name="obj">The other object ID</param>
        /// <returns>Whether the object IDs are equal</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null || !(obj is ObjectId))
            {
                return false;
            }

            ObjectId other = (ObjectId)obj;

            for (int i = 0; i < Length; i++)
            {
                if (id[i] != other.id[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Get the hash code of the object
        /// </summary>
        /// <returns>The hash code of the object</returns>
        public override int GetHashCode()
        {
            return id[0] << 24 | id[1] << 16 | id[2] << 8 | id[3];
        }

        internal class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (typeof(ObjectId).Equals(objectType) ||
                    typeof(IEnumerable<ObjectId>).Equals(objectType) ||
                    typeof(IList<ObjectId>).Equals(objectType) ||
                    typeof(List<ObjectId>).Equals(objectType));
            }

            public override object ReadJson(
                JsonReader reader,
                Type objectType,
                object existingValue,
                JsonSerializer serializer)
            {
                if (typeof(IEnumerable<ObjectId>).Equals(objectType) ||
                    typeof(IList<ObjectId>).Equals(objectType) ||
                    typeof(List<ObjectId>).Equals(objectType))
                {
                    List<ObjectId> result = new List<ObjectId>();

                    foreach (string id in (IEnumerable<string>)serializer.Deserialize(reader, typeof(IEnumerable<string>)))
                    {
                        result.Add(new ObjectId(id));
                    }

                    return result;
                }
                else
                {
                    return new ObjectId((String)reader.Value);
                }
            }

            public override void WriteJson(
                JsonWriter writer,
                object value,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
