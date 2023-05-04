using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz!"); //Burada "RuleFor(x => x.CategoryName)." dan sonra doğrulama kuralları eklenir.
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterAbout).MinimumLength(3).WithMessage("Hakkında Kısmını Boş Bırakamazsınız!");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Hakkında Kısmını 100 Karakterden fazla giremezsiniz!");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Ünvan Kısmını 50 Karakterden fazla giremezsiniz!");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Lütfen En az 2 karakter girişi yapınız!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen En 50 karakterden fazla değer girişi yapmayın!");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında kısmında en az bir defa a harfi kullanılmalıdır");
        }
        

        private bool IsAboutValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a,A])");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
