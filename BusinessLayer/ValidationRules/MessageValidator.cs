using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezsiniz!"); //Burada "RuleFor(x => x.CategoryName)." dan sonra doğrulama kuralları eklenir.
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz!");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli Bir e-mail adresi Giriniz!"); ; //Girilen ifadenin bir mail adresi olduğunu doğrulama yapılacak
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En az 3 karakter girişi yapınız!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen En az 100 karakterden fazla değer girişi yapmayınız!");

        }


    }
}
