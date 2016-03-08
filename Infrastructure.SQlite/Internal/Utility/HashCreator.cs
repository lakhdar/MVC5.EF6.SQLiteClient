﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.SQlite.Utility
{
    internal static class HashCreator
    {
        public static string CreateHash(string data)
        {
            byte[] dataBytes = Encoding.ASCII.GetBytes(data);
            SHA512 sha512 = new SHA512Managed();
            byte[] hashBytes = sha512.ComputeHash(dataBytes);
            string hash = Convert.ToBase64String(hashBytes);
            return hash;
        }
    }
}
