using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(MatrixOperationsXamarinForms.Droid.Localize))]
namespace MatrixOperationsXamarinForms.Droid
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            try
            {
                var androidLocale = Java.Util.Locale.Default;
                var netLanguage = androidLocale.ToString().Replace("_", "-");
                return new CultureInfo(netLanguage);
            }
            catch
            {
                return new CultureInfo("en-US");
            }
        }
    }
}