using ActivitiesDataBase.ViewModels;
using FluentValidation;


namespace OrganizationActivityManager.Validators
{
    public class ActivityValidator : AbstractValidator<ActivityViewModel>
    {
        public ActivityValidator()
        {
            RuleFor(activity => activity.Quota).Must(quota => quota > 0).WithMessage("Geçerli Kontenjan Bilgisi Giriniz");
        }
    }
}
