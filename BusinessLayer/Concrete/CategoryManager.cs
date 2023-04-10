using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;      //türü ICategoryDal dan gelen, _categoryDal adında bir field ım var.

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;     //CategoryManager sınıfına ait yapıcı method oluşmuş oldu.
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id); //id den gelen değerler eşitse işlemler gerçekleşecek
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
                        
    }
}
