﻿using System;
using Newtonsoft.Json;

namespace Lace.Shared.Helpers
{
    public static class JsonFunctions
    {
        public static string ObjectToJson<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {

                return string.Empty;
            }

        }
    }
}
