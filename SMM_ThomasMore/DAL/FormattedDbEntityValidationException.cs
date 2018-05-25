using System.Data.Entity.Validation;

namespace SMM_ThomasMore.DAL
{
  internal class FormattedDbEntityValidationException
  {
    private DbEntityValidationException e;

    public FormattedDbEntityValidationException(DbEntityValidationException e)
    {
      this.e = e;
    }
  }
}