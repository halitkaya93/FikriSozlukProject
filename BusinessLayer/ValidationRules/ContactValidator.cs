using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Usermail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz!"); //Burada "RuleFor(x => x.CategoryName)." dan sonra doğrulama kuralları eklenir.
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En az 3 Karakter giriniz!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen En az 3 karakter girişi yapınız!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen En az 50 karakterden fazla değer girişi yapmayınız!");

        }

    }
}
