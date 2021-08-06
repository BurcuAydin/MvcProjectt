using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAddBL(Category category);
        void CategoryDelete(Category category);
        Category GetById(int id);
        void CategoryUpdate(Category category);
    }
}
