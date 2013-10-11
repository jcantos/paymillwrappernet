﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PaymillWrapper.Models;
using PaymillWrapper.Service;

namespace PaymillWrapper.Query
{
    public class Query<T>
        where T: BaseModel
    {
        private readonly AbstractService<T> _service;
        private readonly Encoding _charset;
        private readonly Dictionary<string, object> _data;

        internal Query(AbstractService<T> service)
        {
            _service = service;
            _charset = Encoding.UTF8;
            _data = new Dictionary<string, object>();
        }

        internal void Add(string key, object value)
        {
            _data[key] = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var pair in _data)
            {
                var value = pair.Value;
                if (value != null)
                    AddKeyValuePair(sb, pair.Key, value);
            }

            return sb.ToString();
        }

        public async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await _service.GetAsync(this);
        }

        private void AddKeyValuePair(StringBuilder sb, string key, object value)
        {
            var reply = "";

            if (value == null) return;

            try
            {

                key = HttpUtility.UrlEncode(key.ToLower(), _charset);

                if (value.GetType().IsEnum)
                {
                    reply = value.ToString().ToLower();
                }
                else if (value is DateTime)
                {
                    if (value.Equals(DateTime.MinValue)) reply = "";
                }
                else
                {
                    reply = HttpUtility.UrlEncode(value.ToString(), _charset);
                }

                if (!string.IsNullOrEmpty(reply))
                {
                    if (sb.Length > 0)
                        sb.Append("&");

                    sb.Append(String.Format("{0}={1}", key, reply));
                }

            }
            catch
            {
                throw new PaymillException(
                    String.Format("Unsupported or invalid character set encoding '{0}'.", _charset));
            }

        }
    }
}