using Btcamp.Crowdfunding.Core.Entitys;
using Btcamp.Crowdfunding.Core.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class CommonExtensions
    {
        public static string ToMd5String(this string str)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(hashmd5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToUpper();
        }
        public static UserInfo GetCurrentUser(this IDictionary dic)
        {
            if (dic.Contains("currentUser"))
            {
                var user = dic["currentUser"] as UserInfo;
                return user;
            }
            return null;
        }

        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, Page page)
        {
            return queryable.Skip(page.Skip).Take(page.PageSize);
        }
    }
}
