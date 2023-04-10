using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz!"); //Burada "RuleFor(x => x.CategoryName)." dan sonra doğrulama kuralları eklenir.
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz!");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen En Fazla 20 Karakter giriniz!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En az 3 karakter girişi yapınız!");

        }
    }
}
