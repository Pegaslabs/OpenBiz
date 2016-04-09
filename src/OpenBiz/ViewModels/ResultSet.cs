using OpenBiz.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenBiz.ViewModels
{
    public class ResultSet
    {
        public List<Product> GetResult(string search, string sortOrder, int start, int length, List<Product> dtResult, List<string> columnFilters)
        {
            string[] orderParam = sortOrder.Split(' ');

            if (string.IsNullOrWhiteSpace(orderParam[1]))
                return FilterResult(search, dtResult, columnFilters).OrderBy(i => i.GetType().GetProperty(orderParam[0].Trim()).GetValue(i, null)).Skip(start).Take(length).ToList();

            return FilterResult(search, dtResult, columnFilters).OrderByDescending(i => i.GetType().GetProperty(orderParam[0].Trim()).GetValue(i, null)).Skip(start).Take(length).ToList();

        }

        public int Count(string search, List<Product> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).Count();
        }

        private IQueryable<Product> FilterResult(string search, List<Product> dtResult, List<string> columnFilters)
        {
            IQueryable<Product> results = dtResult.AsQueryable();

            results = results.Where(p => (search == null || (p.ProductName != null && p.ProductName.ToLower().Contains(search.ToLower()) || p.Category.CategoryName != null && p.Category.CategoryName.ToLower().Contains(search.ToLower())
                || p.ProductPrice != -1 && p.ProductPrice.Equals(search) || p.QuantityOnHand != -1 && p.QuantityOnHand.Equals(search.ToLower()) || p.DateOut != null && p.DateOut.ToString().ToLower().Contains(search.ToLower())
                && (columnFilters[0] == null || (p.ProductName != null && p.ProductName.ToLower().Contains(columnFilters[0].ToLower())))
                && (columnFilters[1] == null || (p.Category.CategoryName != null && p.Category.CategoryName.ToLower().Contains(columnFilters[1].ToLower())))
                && (columnFilters[2] == null || (p.ProductPrice != -1 && p.ProductPrice.Equals(columnFilters[2])))
                && (columnFilters[3] == null || (p.QuantityOnHand != -1 && p.QuantityOnHand.Equals(columnFilters[3])))
                && (columnFilters[4] == null || (p.DateOut != null && p.DateOut.ToString().ToLower().Contains(columnFilters[4].ToLower())))
                )
                )
                );


            return results;
        }
    }

}
