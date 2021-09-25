using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTest
{
    public static class UserSort
    {
        public enum UserSortOrder : Int16
        {
            NameAsc = 1,
            NameDesc = 2,
            EmailAsc = 3,
            EmailDesc = 4,
            BirthdayAsc = 5,
            BirthdayDesc = 6,
            SalaryAsc = 7,
            SalaryDesc = 8,
            LastModifiedDateAsc = 9,
            LastModifiedDateDesc = 10
        }
        public static IQueryable<Models.User> Order(this IQueryable<Models.User> query, UserSortOrder? Order)
        {
            switch (Order)
            {
                case UserSortOrder.NameAsc: return query.OrderBy(ob => ob.UserName);
                case UserSortOrder.NameDesc: return query.OrderByDescending(ob => ob.UserName);
                case UserSortOrder.EmailAsc: return query.OrderBy(ob => ob.Email);
                case UserSortOrder.EmailDesc: return query.OrderByDescending(ob => ob.Email);
                case UserSortOrder.BirthdayAsc: return query.OrderBy(ob => ob.Birthday);
                case UserSortOrder.BirthdayDesc: return query.OrderByDescending(ob => ob.Birthday);
                case UserSortOrder.SalaryAsc: return query.OrderBy(ob => ob.Salary);
                case UserSortOrder.SalaryDesc: return query.OrderByDescending(ob => ob.Salary);
                case UserSortOrder.LastModifiedDateAsc: return query.OrderBy(ob => ob.LastModifiedDate);
                case UserSortOrder.LastModifiedDateDesc: return query.OrderByDescending(ob => ob.LastModifiedDate);
                default: return query;
            }
        }
        public static bool IsNameOrderAsc(UserSortOrder? order)
        {
            return order == null || order != UserSort.UserSortOrder.NameAsc;
        }
        public static bool IsEmailOrderAsc(UserSortOrder? order)
        {
            return order == null || order != UserSort.UserSortOrder.EmailAsc;
        }
        public static bool IsBirthdayOrderAsc(UserSortOrder? order)
        {
            return order == null || order != UserSort.UserSortOrder.BirthdayAsc;
        }
        public static bool IsSalaryOrderAsc(UserSortOrder? order)
        {
            return order == null || order != UserSort.UserSortOrder.SalaryAsc;
        }
        public static bool IsLastModifiedDateOrderAsc(UserSortOrder? order)
        {
            return order == null || order != UserSort.UserSortOrder.LastModifiedDateAsc;
        }
    }
}